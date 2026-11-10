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

        public BipassDbContext(DbContextOptions<BipassDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => MapDatabaseRoleToEnum(v)
                );


            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TicketType>()
                .Property(tt => tt.Price)
                .HasPrecision(18, 2);


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


            modelBuilder.Entity<Venue>().HasData(

                new Venue
                {
                    Id = 1,
                    Name = "Anfiteatro Municipal Humberto de Nito",
                    Address = "Av. Diario La Capital 1750, Rosario, Santa Fe",
                    Capacity = 10000
                },

                new Venue
                {
                    Id = 2,
                    Name = "Centro de Convenciones Metropolitano",
                    Address = "Junín 501, Rosario, Santa Fe",
                    Capacity = 8000
                },

                new Venue
                {
                    Id = 3,
                    Name = "Teatro Broadway Rosario",
                    Address = "San Lorenzo 1223, Rosario, Santa Fe",
                    Capacity = 1200
                },

                new Venue
                {
                    Id = 4,
                    Name = "Sala de las Artes",
                    Address = "Suipacha 98, Rosario, Santa Fe",
                    Capacity = 1200
                },

                new Venue
                {
                    Id = 5,
                    Name = "Galpón 11",
                    Address = "Estévez Boero 980, Rosario, Santa Fe",
                    Capacity = 700
                },

                new Venue
                {
                    Id = 6,
                    Name = "Teatro Plataforma Lavardén",
                    Address = "Mendoza 1085, Rosario, Santa Fe",
                    Capacity = 700
                },

                new Venue
                {
                    Id = 9001,
                    Name = "Movistar Arena",
                    Address = "Humboldt 450, Villa Crespo, CABA",
                    Capacity = 15000
                },

                new Venue
                {
                    Id = 9002,
                    Name = "Teatro Gran Rex",
                    Address = "Av. Corrientes 857, CABA",
                    Capacity = 3200
                }
            );


            modelBuilder.Entity<Event>().HasData(

                new Event
                {
                    Id = 1,
                    Name = "Rosario Suena 2026 - Festival de Música",
                    Description =
                        "Una jornada dedicada a la música en vivo con bandas " +
                        "nacionales, artistas emergentes y propuestas alternativas. " +
                        "El festival contará con múltiples presentaciones, " +
                        "escenario principal, sector gastronómico y espacios VIP.",
                    Date = new DateTime(2026, 11, 21, 18, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1501386761578-eac5c94b800a?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/eventos/rosario-suena-2026",
                    VenueId = 1
                },

                new Event
                {
                    Id = 2,
                    Name = "Jazz Sessions - Música en Vivo",
                    Description =
                        "Una experiencia musical íntima con músicos de jazz, " +
                        "soul y blues. El espectáculo combina interpretaciones " +
                        "instrumentales, voces en vivo y una ambientación " +
                        "especialmente diseñada para disfrutar de la música.",
                    Date = new DateTime(2026, 12, 5, 21, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1511192336575-5a79af67a629?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/eventos/jazz-sessions",
                    VenueId = 5
                },

                new Event
                {
                    Id = 3,
                    Name = "Rosario Tech Summit 2027",
                    Description =
                        "Encuentro de tecnología e innovación orientado a " +
                        "desarrolladores, estudiantes, emprendedores y profesionales. " +
                        "Contará con conferencias sobre Inteligencia Artificial, " +
                        "desarrollo de software, ciberseguridad, Cloud Computing " +
                        "y transformación digital.",
                    Date = new DateTime(2027, 1, 16, 9, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1540575467063-178a50c2df87?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/eventos/tech-summit-2027",
                    VenueId = 2
                },

                new Event
                {
                    Id = 4,
                    Name = "La Última Función - Teatro",
                    Description =
                        "Una propuesta teatral que combina drama, humor " +
                        "y suspenso a través de una historia sobre decisiones, " +
                        "relaciones personales y segundas oportunidades. " +
                        "Una producción escénica con elenco profesional.",
                    Date = new DateTime(2026, 12, 12, 20, 30, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1507676184212-d03ab07a01bf?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 3
                },

                new Event
                {
                    Id = 5,
                    Name = "Boiler Sessions Rosario",
                    Description =
                        "Una noche dedicada a la música electrónica underground. " +
                        "DJs invitados, visuales inmersivos, sonido profesional " +
                        "y una puesta de luces especialmente diseñada para la ocasión. " +
                        "El evento contará con sector General, acceso VIP " +
                        "y transmisión exclusiva para usuarios de BIPASS.",
                    Date = new DateTime(2026, 12, 19, 23, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1470225620780-dba8ba36b745?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/eventos/boiler-sessions",
                    VenueId = 4
                },

                new Event
                {
                    Id = 6,
                    Name = "Stand Up Night - Sin Filtro",
                    Description =
                        "Una noche de comedia en vivo con distintos referentes " +
                        "del circuito de stand-up nacional. Monólogos, humor " +
                        "cotidiano e improvisación en un espectáculo pensado " +
                        "para disfrutar en compañía.",
                    Date = new DateTime(2027, 1, 23, 21, 30, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1585699324551-f6c309eedeca?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 6
                },

                new Event
                {
                    Id = 7,
                    Name = "Sabores del Litoral - Feria Gastronómica",
                    Description =
                        "Una feria gastronómica que reúne restaurantes, " +
                        "productores regionales, chefs y emprendimientos " +
                        "de Santa Fe y alrededores. Los visitantes podrán " +
                        "disfrutar de degustaciones, cocina en vivo, productos " +
                        "artesanales y propuestas gastronómicas para toda la familia.",
                    Date = new DateTime(2027, 2, 6, 12, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 2
                },

                new Event
                {
                    Id = 8,
                    Name = "Argentina Gaming Championship 2027",
                    Description =
                        "Campeonato competitivo de videojuegos con torneos " +
                        "de esports, equipos invitados, comentaristas, " +
                        "actividades para el público y premios para los ganadores. " +
                        "El evento contará con escenario principal, pantallas " +
                        "de alta definición y transmisión online en directo.",
                    Date = new DateTime(2027, 2, 20, 15, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1542751371-adc38448a05e?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/eventos/gaming-championship",
                    VenueId = 2
                },

                new Event
                {
                    Id = 9,
                    Name = "Indie Sessions - Rosario",
                    Description =
                        "Un encuentro musical dedicado a la escena independiente. " +
                        "Bandas emergentes, nuevos sonidos y artistas locales " +
                        "compartirán escenario en una noche de música alternativa. " +
                        "La experiencia estará disponible presencialmente " +
                        "y mediante acceso virtual exclusivo.",
                    Date = new DateTime(2027, 3, 6, 20, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1459749411175-04bf5292ceea?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/eventos/indie-sessions",
                    VenueId = 5
                },

                new Event
                {
                    Id = 10,
                    Name = "Danza en Escena - Festival 2027",
                    Description =
                        "Festival artístico que reúne diferentes expresiones " +
                        "de danza contemporánea, urbana y clásica. Participarán " +
                        "compañías y bailarines invitados en una producción " +
                        "que combina coreografías originales e iluminación escénica.",
                    Date = new DateTime(2027, 3, 13, 20, 30, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1504609813442-a8924e83f76e?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 3
                },

                new Event
                {
                    Id = 9001,
                    Name = "Rosario Running Experience 2027",
                    Description =
                        "Jornada deportiva abierta a corredores de todos " +
                        "los niveles. La competencia contará con circuitos " +
                        "de 5K y 10K, puestos de hidratación, asistencia médica, " +
                        "cronometraje electrónico y entrega de medallas.",
                    Date = new DateTime(2027, 4, 10, 8, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1461896836934-ffe607ba8211?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = false,
                    StreamingUrl = null,
                    VenueId = 1
                },

                new Event
                {
                    Id = 9002,
                    Name = "Live Music Experience 2027",
                    Description =
                        "Un espectáculo musical de gran formato que reúne " +
                        "artistas invitados, producción audiovisual, " +
                        "escenografía de última generación y sonido profesional. " +
                        "El público podrá seleccionar diferentes sectores " +
                        "de ubicación y disfrutar del espectáculo también " +
                        "mediante la modalidad de acceso virtual BIPASS.",
                    Date = new DateTime(2027, 4, 24, 21, 0, 0),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1506157786151-b8491531f063?auto=format&fit=crop&w=1920&q=90",
                    IsStreaming = true,
                    StreamingUrl = "https://streaming.bipass.com/eventos/live-music-experience",
                    VenueId = 9001
                }
            );

            modelBuilder.Entity<TicketType>().HasData(

                new TicketType
                {
                    Id = 1,
                    Name = "General",
                    Price = 38000m,
                    QuantityAvailable = 2500,
                    EventId = 1
                },

                new TicketType
                {
                    Id = 2,
                    Name = "Campo VIP",
                    Price = 65000m,
                    QuantityAvailable = 500,
                    EventId = 1
                },

                new TicketType
                {
                    Id = 3,
                    Name = "Acceso Virtual HD",
                    Price = 12000m,
                    QuantityAvailable = 2000,
                    EventId = 1
                },

                new TicketType
                {
                    Id = 4,
                    Name = "Entrada General",
                    Price = 22000m,
                    QuantityAvailable = 300,
                    EventId = 2
                },

                new TicketType
                {
                    Id = 5,
                    Name = "Pase Streaming",
                    Price = 9000m,
                    QuantityAvailable = 1000,
                    EventId = 2
                },

                new TicketType
                {
                    Id = 6,
                    Name = "Pase Completo Presencial",
                    Price = 55000m,
                    QuantityAvailable = 1500,
                    EventId = 3
                },

                new TicketType
                {
                    Id = 7,
                    Name = "Acceso Virtual",
                    Price = 18000m,
                    QuantityAvailable = 3000,
                    EventId = 3
                },

                new TicketType
                {
                    Id = 8,
                    Name = "Platea Preferencial",
                    Price = 28000m,
                    QuantityAvailable = 350,
                    EventId = 4
                },

                new TicketType
                {
                    Id = 9,
                    Name = "Pullman",
                    Price = 22000m,
                    QuantityAvailable = 250,
                    EventId = 4
                },

                new TicketType
                {
                    Id = 10,
                    Name = "General Dancefloor",
                    Price = 45000m,
                    QuantityAvailable = 700,
                    EventId = 5
                },

                new TicketType
                {
                    Id = 11,
                    Name = "VIP Experience",
                    Price = 90000m,
                    QuantityAvailable = 100,
                    EventId = 5
                },

                new TicketType
                {
                    Id = 12,
                    Name = "Streaming Exclusivo",
                    Price = 15000m,
                    QuantityAvailable = 1500,
                    EventId = 5
                },

                new TicketType
                {
                    Id = 13,
                    Name = "Platea General",
                    Price = 20000m,
                    QuantityAvailable = 400,
                    EventId = 6
                },

                new TicketType
                {
                    Id = 14,
                    Name = "Platea Preferencial",
                    Price = 26000m,
                    QuantityAvailable = 150,
                    EventId = 6
                },

                new TicketType
                {
                    Id = 15,
                    Name = "Acceso General",
                    Price = 15000m,
                    QuantityAvailable = 2500,
                    EventId = 7
                },

                new TicketType
                {
                    Id = 9001,
                    Name = "Experiencia Degustación",
                    Price = 32000m,
                    QuantityAvailable = 500,
                    EventId = 7
                },

                new TicketType
                {
                    Id = 9002,
                    Name = "Entrada Presencial",
                    Price = 25000m,
                    QuantityAvailable = 1500,
                    EventId = 8
                },

                new TicketType
                {
                    Id = 9003,
                    Name = "Pase Streaming HD",
                    Price = 8000m,
                    QuantityAvailable = 3000,
                    EventId = 8
                },

                new TicketType
                {
                    Id = 9004,
                    Name = "General",
                    Price = 30000m,
                    QuantityAvailable = 450,
                    EventId = 9
                },

                new TicketType
                {
                    Id = 9005,
                    Name = "Acceso Virtual HD",
                    Price = 10000m,
                    QuantityAvailable = 1200,
                    EventId = 9
                },

                new TicketType
                {
                    Id = 9006,
                    Name = "Platea General",
                    Price = 18000m,
                    QuantityAvailable = 500,
                    EventId = 10
                },

                new TicketType
                {
                    Id = 9007,
                    Name = "Inscripción 5K",
                    Price = 18000m,
                    QuantityAvailable = 1500,
                    EventId = 9001
                },

                new TicketType
                {
                    Id = 9008,
                    Name = "Inscripción 10K",
                    Price = 25000m,
                    QuantityAvailable = 1000,
                    EventId = 9001
                },

                new TicketType
                {
                    Id = 9009,
                    Name = "Campo General",
                    Price = 48000m,
                    QuantityAvailable = 5000,
                    EventId = 9002
                },

                new TicketType
                {
                    Id = 9010,
                    Name = "Platea Preferencial",
                    Price = 75000m,
                    QuantityAvailable = 1500,
                    EventId = 9002
                },

                new TicketType
                {
                    Id = 9011,
                    Name = "Acceso Virtual HD",
                    Price = 16000m,
                    QuantityAvailable = 3000,
                    EventId = 9002
                }
            );


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
        private static UserRole MapDatabaseRoleToEnum(string roleString)
        {
            if (string.IsNullOrEmpty(roleString)) return UserRole.User;

            if (string.Equals(roleString, "Client", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(roleString, "User", StringComparison.OrdinalIgnoreCase))
            {
                return UserRole.User;
            }

            if (string.Equals(roleString, "Organizer", StringComparison.OrdinalIgnoreCase))
            {
                return UserRole.Organizer;
            }

            if (string.Equals(roleString, "Admin", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(roleString, "SuperAdmin", StringComparison.OrdinalIgnoreCase))
            {
                return UserRole.SuperAdmin;
            }

            return UserRole.User;
        }
    }
}