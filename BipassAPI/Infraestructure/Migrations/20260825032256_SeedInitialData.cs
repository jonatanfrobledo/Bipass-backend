using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1, "Av. Figueroa Alcorta 7597", 84000, "Estadio River Plate" },
                    { 2, "Humboldt 450", 15000, "Movistar Arena" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "ImageUrl", "IsStreaming", "Name", "StreamingUrl", "VenueId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), "El festival de rock más grande del año con bandas invitadas nacionales e internacionales.", "https://images.unsplash.com/photo-1470225620780-dba8ba36b745?q=80&w=600", false, "Rock Festival 2026", null, 1 },
                    { 2, new DateTime(2026, 10, 5, 21, 30, 0, 0, DateTimeKind.Unspecified), "Una velada íntima con los mejores exponentes del Jazz en vivo.", "https://images.unsplash.com/photo-1511192336575-5a79af67a629?q=80&w=600", true, "Noche de Jazz & Soul", "https://streaming.bipass.com/jazz-night", 2 }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "EventId", "Name", "Price", "QuantityAvailable" },
                values: new object[,]
                {
                    { 1, 1, "General", 25000.00m, 150 },
                    { 2, 1, "Campo VIP", 50000.00m, 50 },
                    { 3, 2, "Platea Preferencial", 18000.00m, 80 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
