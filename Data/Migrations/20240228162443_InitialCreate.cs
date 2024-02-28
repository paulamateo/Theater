using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Shows_ShowId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "QuantitySeats",
                table: "Shows");

            migrationBuilder.RenameColumn(
                name: "ShowId",
                table: "Seat",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ShowId",
                table: "Seat",
                newName: "IX_Seat_SessionId");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Seat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSession = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantitySeats = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Session_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ReservationId",
                table: "Seat",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_ShowId",
                table: "Session",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Session_SessionId",
                table: "Seat",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Session_SessionId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Seat_ReservationId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Seat");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Seat",
                newName: "ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SessionId",
                table: "Seat",
                newName: "IX_Seat_ShowId");

            migrationBuilder.AddColumn<int>(
                name: "QuantitySeats",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Shows_ShowId",
                table: "Seat",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId");
        }
    }
}
