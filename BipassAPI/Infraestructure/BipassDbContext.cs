using System;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class BipassDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Venue> Venues => Set<Venue>();
        public DbSet<TicketType> TicketTypes => Set<TicketType>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        public BipassDbContext(DbContextOptions<BipassDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Guardar Enum como string ignorando mayúsculas/minúsculas
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserRole)Enum.Parse(typeof(UserRole), v, true)
                );

            // --- Precisiones para importes monetarios ---
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TicketType>()
                .Property(tt => tt.Price)
                .HasPrecision(18, 2);

            // --- Relaciones y claves foráneas ---
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TicketType>()
                .HasOne(tt => tt.Event)
                .WithMany(e => e.TicketTypes)
                .HasForeignKey(tt => tt.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.TicketType)
                .WithMany()
                .HasForeignKey(oi => oi.TicketTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // =========================================================================
            // 🛠️ SEED DATA (DATOS DE PRUEBA REALISTAS)
            // =========================================================================

            // 1. Lugares (Venues)
            modelBuilder.Entity<Venue>().HasData(
                new Venue { Id = 1, Name = "Estadio River Plate", Address = "Av. Figueroa Alcorta 7597, CABA", Capacity = 84000 },
                new Venue { Id = 2, Name = "Movistar Arena", Address = "Humboldt 450, CABA", Capacity = 15000 },
                new Venue { Id = 3, Name = "Teatro Gran Rex", Address = "Av. Corrientes 857, CABA", Capacity = 3200 },
                new Venue { Id = 4, Name = "La Rural - Predio Ferial", Address = "Av. Santa Fe 4201, CABA", Capacity = 25000 },
                new Venue { Id = 5, Name = "Anfiteatro Humberto de Nito", Address = "Parque Urquiza, Rosario", Capacity = 10000 },
                new Venue { Id = 6, Name = "Centro de Convenciones Metropolitano", Address = "Junín 501, Rosario", Capacity = 8000 }
            );

            // 2. Eventos (Events - 10 Ítems variados)
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Rock Festival 2026",
                    Description = "El festival de rock más esperado del año con bandas nacionales e internacionales en vivo.",
                    Date = new DateTime(2026, 11, 15, 20, 0, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1470225620780-dba8ba36b745?q=80&w=800",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 1
                },
                new Event
                {
                    Id = 2,
                    Name = "Noche de Jazz & Soul",
                    Description = "Una velada íntima para disfrutar de grandes intérpretes y cuartetos en formato acústico.",
                    Date = new DateTime(2026, 10, 5, 21, 30, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1511192336575-5a79af67a629?q=80&w=800",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/jazz-night",
                    VenueId = 2
                },
                new Event
                {
                    Id = 3,
                    Name = "Tech Future Summit 2026",
                    Description = "Conferencia de desarrollo de software, Inteligencia Artificial y Cloud Computing.",
                    Date = new DateTime(2026, 9, 12, 09, 0, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?q=80&w=800",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/tech-summit",
                    VenueId = 6
                },
                new Event
                {
                    Id = 4,
                    Name = "Sinfonía bajo las Estrellas",
                    Description = "La Orquesta Sinfónica interpretará los mejores clásicos del cine en un concierto al aire libre.",
                    Date = new DateTime(2026, 10, 20, 20, 30, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1465847899084-d164df4dedc6?q=80&w=800",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 5
                },
                new Event
                {
                    Id = 5,
                    Name = "Electronic Sunrise Festival",
                    Description = "Doce horas continuas de música electrónica con los mejores DJs internacionales del momento.",
                    Date = new DateTime(2026, 12, 31, 23, 0, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1516450360452-9312f5e86fc7?q=80&w=800",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/electronic-sunrise",
                    VenueId = 4
                },
                new Event
                {
                    Id = 6,
                    Name = "Comedy Night Live",
                    Description = "Una noche a pura risa con los mejores referentes del Stand-Up nacional.",
                    Date = new DateTime(2026, 9, 25, 22, 0, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1585699324551-f6c309eedeca?q=80&w=800",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 3
                },
                new Event
                {
                    Id = 7,
                    Name = "Gourmet & Wine Expo",
                    Description = "Feria gastronómica con chefs destacados, catas de vinos premium y maridajes exóticos.",
                    Date = new DateTime(2026, 11, 01, 13, 0, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1510812431401-41d2bd2722f3?q=80&w=800",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 4
                },
                new Event
                {
                    Id = 8,
                    Name = "Championship Finals: eSports 2026",
                    Description = "La gran final de League of Legends y Counter-Strike 2 disputada en escenario principal.",
                    Date = new DateTime(2026, 10, 10, 15, 0, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1542751371-adc38448a05e?q=80&w=800",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/esports-finals",
                    VenueId = 2
                },
                new Event
                {
                    Id = 9,
                    Name = "Obra Teatral: Sombras e Ilusiones",
                    Description = "Una pieza dramática premiada internacionalmente que deslumbrará al espectador.",
                    Date = new DateTime(2026, 10, 18, 20, 0, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1507676184212-d03ab07a01bf?q=80&w=800",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 3
                },
                new Event
                {
                    Id = 10,
                    Name = "Indie Pop Night",
                    Description = "Presentación exclusiva de bandas emergentes del circuito independiente.",
                    Date = new DateTime(2026, 11, 28, 21, 0, 0),
                    ImageUrl = "https://images.unsplash.com/photo-1459749411175-04bf5292ceea?q=80&w=800",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/indie-pop-night",
                    VenueId = 5
                }
            );

            // 3. Tipos de Entradas (TicketTypes para cada evento)
            modelBuilder.Entity<TicketType>().HasData(
                // Evento 1
                new TicketType { Id = 1, Name = "General", Price = 35000.00m, QuantityAvailable = 500, EventId = 1 },
                new TicketType { Id = 2, Name = "Campo VIP", Price = 75000.00m, QuantityAvailable = 120, EventId = 1 },

                // Evento 2
                new TicketType { Id = 3, Name = "Platea Preferencial", Price = 22000.00m, QuantityAvailable = 80, EventId = 2 },
                new TicketType { Id = 4, Name = "Pase Streaming", Price = 8000.00m, QuantityAvailable = 1000, EventId = 2 },

                // Evento 3
                new TicketType { Id = 5, Name = "Pase Completo (Presencial)", Price = 45000.00m, QuantityAvailable = 250, EventId = 3 },
                new TicketType { Id = 6, Name = "Acceso Virtual", Price = 15000.00m, QuantityAvailable = 500, EventId = 3 },

                // Evento 4
                new TicketType { Id = 7, Name = "Entrada General", Price = 18000.00m, QuantityAvailable = 300, EventId = 4 },

                // Evento 5
                new TicketType { Id = 8, Name = "General Dancefloor", Price = 40000.00m, QuantityAvailable = 400, EventId = 5 },
                new TicketType { Id = 9, Name = "VIP Backstage", Price = 110000.00m, QuantityAvailable = 40, EventId = 5 },

                // Evento 6
                new TicketType { Id = 10, Name = "Plateas", Price = 16000.00m, QuantityAvailable = 150, EventId = 6 },

                // Evento 7
                new TicketType { Id = 11, Name = "Degustación General", Price = 28000.00m, QuantityAvailable = 200, EventId = 7 },

                // Evento 8
                new TicketType { Id = 12, Name = "Pase Fan Gamer", Price = 25000.00m, QuantityAvailable = 350, EventId = 8 },
                new TicketType { Id = 13, Name = "Ticket Virtual HD", Price = 6000.00m, QuantityAvailable = 1500, EventId = 8 },

                // Evento 9
                new TicketType { Id = 14, Name = "Platea Baja", Price = 20000.00m, QuantityAvailable = 90, EventId = 9 },

                // Evento 10
                new TicketType { Id = 15, Name = "General", Price = 14000.00m, QuantityAvailable = 180, EventId = 10 }
            );

            // 4. Usuario Semilla (SuperAdmin)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 999,
                    FirstName = "Super",
                    LastName = "Admin",
                    Email = "admin@bipass.com",
                    PasswordHash = "Admin12345!",
                    PhoneNumber = "3416212725",
                    Role = UserRole.SuperAdmin
                }
            );
        }
    }
}