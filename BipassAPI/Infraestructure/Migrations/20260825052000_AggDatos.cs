using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AggDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "El festival de rock más esperado del año con bandas nacionales e internacionales en vivo.", "https://images.unsplash.com/photo-1470225620780-dba8ba36b745?q=80&w=800" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Una velada íntima para disfrutar de grandes intérpretes y cuartetos en formato acústico.", "https://images.unsplash.com/photo-1511192336575-5a79af67a629?q=80&w=800" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl", "VenueId" },
                values: new object[] { 8, new DateTime(2026, 10, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "La gran final de League of Legends y Counter-Strike 2 disputada en escenario principal.", "https://images.unsplash.com/photo-1542751371-adc38448a05e?q=80&w=800", true, "Championship Finals: eSports 2026", "https://streaming.bipass.com/esports-finals", 2 });

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
                column: "Price",
                value: 22000.00m);

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[] { 4, 2, "Pase Streaming", 8000.00m, 1000 });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "Av. Figueroa Alcorta 7597, CABA");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Humboldt 450, CABA");

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "Capacity", "Name" },
                values: new object[,]
                {
                    { 3, "Av. Corrientes 857, CABA", 3200, "Teatro Gran Rex" },
                    { 4, "Av. Santa Fe 4201, CABA", 25000, "La Rural - Predio Ferial" },
                    { 5, "Parque Urquiza, Rosario", 10000, "Anfiteatro Humberto de Nito" },
                    { 6, "Junín 501, Rosario", 8000, "Centro de Convenciones Metropolitano" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl", "VenueId" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 9, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), "Conferencia de desarrollo de software, Inteligencia Artificial y Cloud Computing.", "https://images.unsplash.com/photo-1540575467063-178a50c2df87?q=80&w=800", true, "Tech Future Summit 2026", "https://streaming.bipass.com/tech-summit", 6 },
                    { 4, new DateTime(2026, 10, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), "La Orquesta Sinfónica interpretará los mejores clásicos del cine en un concierto al aire libre.", "https://images.unsplash.com/photo-1465847899084-d164df4dedc6?q=80&w=800", false, "Sinfonía bajo las Estrellas", null, 5 },
                    { 5, new DateTime(2026, 12, 31, 23, 0, 0, 0, DateTimeKind.Unspecified), "Doce horas continuas de música electrónica con los mejores DJs internacionales del momento.", "https://images.unsplash.com/photo-1516450360452-9312f5e86fc7?q=80&w=800", true, "Electronic Sunrise Festival", "https://streaming.bipass.com/electronic-sunrise", 4 },
                    { 6, new DateTime(2026, 9, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), "Una noche a pura risa con los mejores referentes del Stand-Up nacional.", "https://images.unsplash.com/photo-1585699324551-f6c309eedeca?q=80&w=800", false, "Comedy Night Live", null, 3 },
                    { 7, new DateTime(2026, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Feria gastronómica con chefs destacados, catas de vinos premium y maridajes exóticos.", "https://images.unsplash.com/photo-1510812431401-41d2bd2722f3?q=80&w=800", false, "Gourmet & Wine Expo", null, 4 },
                    { 9, new DateTime(2026, 10, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), "Una pieza dramática premiada internacionalmente que deslumbrará al espectador.", "https://images.unsplash.com/photo-1507676184212-d03ab07a01bf?q=80&w=800", false, "Obra Teatral: Sombras e Ilusiones", null, 3 },
                    { 10, new DateTime(2026, 11, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), "Presentación exclusiva de bandas emergentes del circuito independiente.", "https://images.unsplash.com/photo-1459749411175-04bf5292ceea?q=80&w=800", true, "Indie Pop Night", "https://streaming.bipass.com/indie-pop-night", 5 }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[,]
                {
                    { 12, 8, "Pase Fan Gamer", 25000.00m, 350 },
                    { 13, 8, "Ticket Virtual HD", 6000.00m, 1500 },
                    { 5, 3, "Pase Completo (Presencial)", 45000.00m, 250 },
                    { 6, 3, "Acceso Virtual", 15000.00m, 500 },
                    { 7, 4, "Entrada General", 18000.00m, 300 },
                    { 8, 5, "General Dancefloor", 40000.00m, 400 },
                    { 9, 5, "VIP Backstage", 110000.00m, 40 },
                    { 10, 6, "Plateas", 16000.00m, 150 },
                    { 11, 7, "Degustación General", 28000.00m, 200 },
                    { 14, 9, "Platea Baja", 20000.00m, 90 },
                    { 15, 10, "General", 14000.00m, 180 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "El festival de rock más grande del año con bandas invitadas nacionales e internacionales.", "https://images.unsplash.com/photo-1470225620780-dba8ba36b745?q=80&w=600" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Una velada íntima con los mejores exponentes del Jazz en vivo.", "https://images.unsplash.com/photo-1511192336575-5a79af67a629?q=80&w=600" });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "QuantityAvailable" },
                values: new object[] { 25000.00m, 150 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "QuantityAvailable" },
                values: new object[] { 50000.00m, 50 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 18000.00m);

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "Av. Figueroa Alcorta 7597");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Humboldt 450");
        }
    }
}
