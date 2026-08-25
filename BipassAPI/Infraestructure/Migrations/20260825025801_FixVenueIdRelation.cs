using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class FixVenueIdRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId1",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_VenueId1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VenueId1",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueId1",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId1",
                table: "Events",
                column: "VenueId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId1",
                table: "Events",
                column: "VenueId1",
                principalTable: "Venues",
                principalColumn: "Id");
        }
    }
}
