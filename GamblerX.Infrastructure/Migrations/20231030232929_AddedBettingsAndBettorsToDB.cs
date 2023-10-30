using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamblerX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedBettingsAndBettorsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumBetValue = table.Column<double>(type: "float", nullable: false),
                    BetCountTeam1 = table.Column<int>(type: "int", nullable: false),
                    BetCountTeam2 = table.Column<int>(type: "int", nullable: false),
                    TotalBetValueTeam1 = table.Column<double>(type: "float", nullable: false),
                    TotalBetValueTeam2 = table.Column<double>(type: "float", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bettors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BettingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountBet = table.Column<double>(type: "float", nullable: false),
                    TeamSelected = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bettors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bettings");

            migrationBuilder.DropTable(
                name: "Bettors");
        }
    }
}
