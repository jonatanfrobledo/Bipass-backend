using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infraestructure;
using Infraestructure.Repository;
using Infraestructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using MercadoPago.Config;
using MercadoPago.Client.Preference;

var builder = WebApplication.CreateBuilder(args);

// -------------------------------------------------------------
// 1. Configuración de CORS (Permite peticiones desde el frontend)
// -------------------------------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy => policy
        .WithOrigins(
            "http://localhost:5173",
            "https://localhost:5173",
            "http://127.0.0.1:5173",
            "https://127.0.0.1:5173"
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// -------------------------------------------------------------
// 2. Swagger / OpenAPI con autenticación JWT
// -------------------------------------------------------------
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("v1", new OpenApiInfo { Title = "Bipass API", Version = "v1" });

    setupAction.AddSecurityDefinition("BipassApiBearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Ingresá tu Token JWT obtenido al autenticarte."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "BipassApiBearerAuth"
                }
            },
            new List<string>()
        }
    });
});

// -------------------------------------------------------------
// 3. Configuración de Base de Datos SQL Server
// -------------------------------------------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada en appsettings.json.");

builder.Services.AddDbContext<BipassDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

// -------------------------------------------------------------
// 4. Autenticación JWT
// -------------------------------------------------------------
var secretKey = builder.Configuration["AuthenticationService:SecretForKey"]
    ?? throw new InvalidOperationException("La clave secreta JWT 'AuthenticationService:SecretForKey' no está configurada.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["AuthenticationService:Issuer"],
            ValidAudience = builder.Configuration["AuthenticationService:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

builder.Services.AddAuthorization();

// 4.5. Configuración de Mercado Pago 
// -------------------------------------------------------------
var mpAccessToken = builder.Configuration["MercadoPago:AccessToken"]
    ?? throw new InvalidOperationException("El token de Mercado Pago 'MercadoPago:AccessToken' no está configurado.");

MercadoPagoConfig.AccessToken = mpAccessToken;

// Opcional: Registrar PreferenceClient para Inyección de Dependencias
builder.Services.AddScoped<PreferenceClient>();
// -------------------------------------------------------------
// 5. Inyección de Dependencias (Capa de Aplicación e Infraestructura)
// -------------------------------------------------------------
#region Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
#endregion

#region Services
builder.Services.AddScoped<ICustomAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<EventService, EventService>();
builder.Services.AddScoped<OrderService, OrderService>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<CheckoutService>();
#endregion

var app = builder.Build();

// -------------------------------------------------------------
// 6. Pipeline de Solicitudes HTTP
// -------------------------------------------------------------

// Migración y creación automática de la BD en desarrollo
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<BipassDbContext>();
        
        dbContext.Database.Migrate();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowReactApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();