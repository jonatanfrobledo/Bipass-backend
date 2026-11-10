using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBipassEventCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl" },
                values: new object[] { new DateTime(2026, 11, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), "Una jornada dedicada a la música en vivo con bandas nacionales, artistas emergentes y propuestas alternativas. El festival contará con múltiples presentaciones, escenario principal, sector gastronómico y espacios VIP.", "https://images.unsplash.com/photo-1501386761578-eac5c94b800a?auto=format&fit=crop&w=1920&q=90", true, "Rosario Suena 2026 - Festival de Música", "https://streaming.bipass.com/eventos/rosario-suena-2026" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { new DateTime(2026, 12, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), "Una experiencia musical íntima con músicos de jazz, soul y blues. El espectáculo combina interpretaciones instrumentales, voces en vivo y una ambientación especialmente diseñada para disfrutar de la música.", "https://images.unsplash.com/photo-1511192336575-5a79af67a629?auto=format&fit=crop&w=1920&q=90", "Jazz Sessions - Música en Vivo", "https://streaming.bipass.com/eventos/jazz-sessions", 5 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { new DateTime(2027, 1, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), "Encuentro de tecnología e innovación orientado a desarrolladores, estudiantes, emprendedores y profesionales. Contará con conferencias sobre Inteligencia Artificial, desarrollo de software, ciberseguridad, Cloud Computing y transformación digital.", "https://images.unsplash.com/photo-1540575467063-178a50c2df87?auto=format&fit=crop&w=1920&q=90", "Rosario Tech Summit 2027", "https://streaming.bipass.com/eventos/tech-summit-2027", 2 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "VenueId" },
                values: new object[] { new DateTime(2026, 12, 12, 20, 30, 0, 0, DateTimeKind.Unspecified), "Una propuesta teatral que combina drama, humor y suspenso a través de una historia sobre decisiones, relaciones personales y segundas oportunidades. Una producción escénica con elenco profesional.", "https://images.unsplash.com/photo-1507676184212-d03ab07a01bf?auto=format&fit=crop&w=1920&q=90", "La Última Función - Teatro", 3 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "StreamingUrl" },
                values: new object[] { new DateTime(2026, 12, 19, 23, 0, 0, 0, DateTimeKind.Unspecified), "Una noche dedicada a la música electrónica underground. DJs invitados, visuales inmersivos, sonido profesional y una puesta de luces especialmente diseñada para la ocasión. El evento contará con sector General, acceso VIP y transmisión exclusiva para usuarios de BIPASS.", "https://images.unsplash.com/photo-1470225620780-dba8ba36b745?auto=format&fit=crop&w=1920&q=90", "Boiler Sessions Rosario", "https://streaming.bipass.com/eventos/boiler-sessions" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "VenueId" },
                values: new object[] { new DateTime(2027, 1, 23, 21, 30, 0, 0, DateTimeKind.Unspecified), "Una noche de comedia en vivo con distintos referentes del circuito de stand-up nacional. Monólogos, humor cotidiano e improvisación en un espectáculo pensado para disfrutar en compañía.", "https://images.unsplash.com/photo-1585699324551-f6c309eedeca?auto=format&fit=crop&w=1920&q=90", "Stand Up Night - Sin Filtro", 6 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "VenueId" },
                values: new object[] { new DateTime(2027, 2, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), "Una feria gastronómica que reúne restaurantes, productores regionales, chefs y emprendimientos de Santa Fe y alrededores. Los visitantes podrán disfrutar de degustaciones, cocina en vivo, productos artesanales y propuestas gastronómicas para toda la familia.", "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?auto=format&fit=crop&w=1920&q=90", "Sabores del Litoral - Feria Gastronómica", 2 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "StreamingUrl" },
                values: new object[] { new DateTime(2027, 2, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), "Campeonato competitivo de videojuegos con torneos de esports, equipos invitados, comentaristas, actividades para el público y premios para los ganadores. El evento contará con escenario principal, pantallas de alta definición y transmisión online en directo.", "https://images.unsplash.com/photo-1542751371-adc38448a05e?auto=format&fit=crop&w=1920&q=90", "Argentina Gaming Championship 2027", "https://streaming.bipass.com/eventos/gaming-championship" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { new DateTime(2027, 3, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), "Un encuentro musical dedicado a la escena independiente. Bandas emergentes, nuevos sonidos y artistas locales compartirán escenario en una noche de música alternativa. La experiencia estará disponible presencialmente y mediante acceso virtual exclusivo.", "https://images.unsplash.com/photo-1459749411175-04bf5292ceea?auto=format&fit=crop&w=1920&q=90", true, "Indie Sessions - Rosario", "https://streaming.bipass.com/eventos/indie-sessions", 5 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { new DateTime(2027, 3, 13, 20, 30, 0, 0, DateTimeKind.Unspecified), "Festival artístico que reúne diferentes expresiones de danza contemporánea, urbana y clásica. Participarán compañías y bailarines invitados en una producción que combina coreografías originales e iluminación escénica.", "https://images.unsplash.com/photo-1504609813442-a8924e83f76e?auto=format&fit=crop&w=1920&q=90", false, "Danza en Escena - Festival 2027", null, 3 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageUrl", "IsStreaming", "Name", "OrganizerId", "StreamingUrl", "VenueId" },
                values: new object[] { 9001, new DateTime(2027, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Jornada deportiva abierta a corredores de todos los niveles. La competencia contará con circuitos de 5K y 10K, puestos de hidratación, asistencia médica, cronometraje electrónico y entrega de medallas.", "https://images.unsplash.com/photo-1461896836934-ffe607ba8211?auto=format&fit=crop&w=1920&q=90", false, "Rosario Running Experience 2027", null, null, 1 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "QuantityAvailable" },
                values: new object[] { 38000m, 2500 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "QuantityAvailable" },
                values: new object[] { 65000m, 500 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 1, "Acceso Virtual HD", 12000m, 2000 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Price", "QuantityAvailable" },
                values: new object[] { "Entrada General", 22000m, 300 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 2, "Pase Streaming", 9000m, 1000 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Price", "QuantityAvailable" },
                values: new object[] { "Pase Completo Presencial", 55000m, 1500 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EventId", "Name", "QuantityAvailable" },
                values: new object[] { 3, "Acceso Virtual", 3000 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 4, "Platea Preferencial", 28000m, 350 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 4, "Pullman", 22000m, 250 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 5, "General Dancefloor", 45000m, 700 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 5, "VIP Experience", 90000m, 100 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 5, "Streaming Exclusivo", 15000m, 1500 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 6, "Platea General", 20000m, 400 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 6, "Platea Preferencial", 26000m, 150 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 7, "Acceso General", 15000m, 2500 });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[,]
                {
                    { 9001, 7, "Experiencia Degustación", 32000m, 500 },
                    { 9002, 8, "Entrada Presencial", 25000m, 1500 },
                    { 9003, 8, "Pase Streaming HD", 8000m, 3000 },
                    { 9004, 9, "General", 30000m, 450 },
                    { 9005, 9, "Acceso Virtual HD", 10000m, 1200 },
                    { 9006, 10, "Platea General", 18000m, 500 }
                });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Av. Diario La Capital 1750, Rosario, Santa Fe", 10000, "Anfiteatro Municipal Humberto de Nito" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Junín 501, Rosario, Santa Fe", 8000, "Centro de Convenciones Metropolitano" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "San Lorenzo 1223, Rosario, Santa Fe", 1200, "Teatro Broadway Rosario" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Suipacha 98, Rosario, Santa Fe", 1200, "Sala de las Artes" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Estévez Boero 980, Rosario, Santa Fe", 700, "Galpón 11" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Mendoza 1085, Rosario, Santa Fe", 700, "Teatro Plataforma Lavardén" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "Capacity", "Name" },
                values: new object[,]
                {
                    { 9001, "Humboldt 450, Villa Crespo, CABA", 15000, "Movistar Arena" },
                    { 9002, "Av. Corrientes 857, CABA", 3200, "Teatro Gran Rex" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageUrl", "IsStreaming", "Name", "OrganizerId", "StreamingUrl", "VenueId" },
                values: new object[] { 9002, new DateTime(2027, 4, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), "Un espectáculo musical de gran formato que reúne artistas invitados, producción audiovisual, escenografía de última generación y sonido profesional. El público podrá seleccionar diferentes sectores de ubicación y disfrutar del espectáculo también mediante la modalidad de acceso virtual BIPASS.", "https://images.unsplash.com/photo-1506157786151-b8491531f063?auto=format&fit=crop&w=1920&q=90", true, "Live Music Experience 2027", null, "https://streaming.bipass.com/eventos/live-music-experience", 9001 });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[,]
                {
                    { 9007, 9001, "Inscripción 5K", 18000m, 1500 },
                    { 9008, 9001, "Inscripción 10K", 25000m, 1000 },
                    { 9009, 9002, "Campo General", 48000m, 5000 },
                    { 9010, 9002, "Platea Preferencial", 75000m, 1500 },
                    { 9011, 9002, "Acceso Virtual HD", 16000m, 3000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9001);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9002);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9003);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9004);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9005);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9006);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9007);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9008);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9009);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9010);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9011);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 9002);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9001);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9002);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 9001);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl" },
                values: new object[] { new DateTime(2026, 11, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), "El festival de rock más esperado del año con bandas nacionales e internacionales en vivo.", "https://images.unsplash.com/photo-1470225620780-dba8ba36b745?q=80&w=800", false, "Rock Festival 2026", null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { new DateTime(2026, 10, 5, 21, 30, 0, 0, DateTimeKind.Unspecified), "Una velada íntima para disfrutar de grandes intérpretes y cuartetos en formato acústico.", "https://images.unsplash.com/photo-1511192336575-5a79af67a629?q=80&w=800", "Noche de Jazz & Soul", "https://streaming.bipass.com/jazz-night", 2 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { new DateTime(2026, 9, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Conferencia de desarrollo de software, Inteligencia Artificial y Cloud Computing.", "https://images.unsplash.com/photo-1540575467063-178a50c2df87?q=80&w=800", "Tech Future Summit 2026", "https://streaming.bipass.com/tech-summit", 6 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "VenueId" },
                values: new object[] { new DateTime(2026, 10, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), "La Orquesta Sinfónica interpretará los mejores clásicos del cine en un concierto al aire libre.", "https://images.unsplash.com/photo-1465847899084-d164df4dedc6?q=80&w=800", "Sinfonía bajo las Estrellas", 5 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "StreamingUrl" },
                values: new object[] { new DateTime(2026, 12, 31, 23, 0, 0, 0, DateTimeKind.Unspecified), "Doce horas continuas de música electrónica con los mejores DJs internacionales del momento.", "https://images.unsplash.com/photo-1516450360452-9312f5e86fc7?q=80&w=800", "Electronic Sunrise Festival", "https://streaming.bipass.com/electronic-sunrise" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "VenueId" },
                values: new object[] { new DateTime(2026, 9, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), "Una noche a pura risa con los mejores referentes del Stand-Up nacional.", "https://images.unsplash.com/photo-1585699324551-f6c309eedeca?q=80&w=800", "Comedy Night Live", 3 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "VenueId" },
                values: new object[] { new DateTime(2026, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Feria gastronómica con chefs destacados, catas de vinos premium y maridajes exóticos.", "https://images.unsplash.com/photo-1510812431401-41d2bd2722f3?q=80&w=800", "Gourmet & Wine Expo", 4 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Date", "Description", "ImageUrl", "Name", "StreamingUrl" },
                values: new object[] { new DateTime(2026, 10, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "La gran final de League of Legends y Counter-Strike 2 disputada en escenario principal.", "https://images.unsplash.com/photo-1542751371-adc38448a05e?q=80&w=800", "Championship Finals: eSports 2026", "https://streaming.bipass.com/esports-finals" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { new DateTime(2026, 10, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), "Una pieza dramática premiada internacionalmente que deslumbrará al espectador.", "https://images.unsplash.com/photo-1507676184212-d03ab07a01bf?q=80&w=800", false, "Obra Teatral: Sombras e Ilusiones", null, 3 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { new DateTime(2026, 11, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), "Presentación exclusiva de bandas emergentes del circuito independiente.", "https://images.unsplash.com/photo-1459749411175-04bf5292ceea?q=80&w=800", true, "Indie Pop Night", "https://streaming.bipass.com/indie-pop-night", 5 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "QuantityAvailable" },
                values: new object[] { 35000.00m, 500 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "QuantityAvailable" },
                values: new object[] { 75000.00m, 120 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 2, "Platea Preferencial", 22000.00m, 80 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Price", "QuantityAvailable" },
                values: new object[] { "Pase Streaming", 8000.00m, 1000 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 3, "Pase Completo (Presencial)", 45000.00m, 250 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Price", "QuantityAvailable" },
                values: new object[] { "Acceso Virtual", 15000.00m, 500 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EventId", "Name", "QuantityAvailable" },
                values: new object[] { 4, "Entrada General", 300 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 5, "General Dancefloor", 40000.00m, 400 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 5, "VIP Backstage", 110000.00m, 40 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 6, "Plateas", 16000.00m, 150 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 7, "Degustación General", 28000.00m, 200 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 8, "Pase Fan Gamer", 25000.00m, 350 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 8, "Ticket Virtual HD", 6000.00m, 1500 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 9, "Platea Baja", 20000.00m, 90 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 10, "General", 14000.00m, 180 });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Av. Figueroa Alcorta 7597, CABA", 84000, "Estadio River Plate" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Humboldt 450, CABA", 15000, "Movistar Arena" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Av. Corrientes 857, CABA", 3200, "Teatro Gran Rex" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Av. Santa Fe 4201, CABA", 25000, "La Rural - Predio Ferial" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Parque Urquiza, Rosario", 10000, "Anfiteatro Humberto de Nito" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "Capacity", "Name" },
                values: new object[] { "Junín 501, Rosario", 8000, "Centro de Convenciones Metropolitano" });
        }
    }
}
