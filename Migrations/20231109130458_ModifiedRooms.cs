using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotelum.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomsId",
                table: "Rooms",
                newName: "NumberOfRooms");

            migrationBuilder.RenameColumn(
                name: "NumberOfRooms",
                table: "Hotels",
                newName: "RoomsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfRooms",
                table: "Rooms",
                newName: "RoomsId");

            migrationBuilder.RenameColumn(
                name: "RoomsId",
                table: "Hotels",
                newName: "NumberOfRooms");
        }
    }
}
