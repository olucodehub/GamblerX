using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamblerX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventImageUrlToBetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventImageUrl",
                table: "Bettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventImageUrl",
                table: "Bettings");
        }
    }
}
