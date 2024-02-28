using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater.Data.Migrations
{
    public partial class ProblemSwagger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Users_UserId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Session_SessionId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Shows_ShowId",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Session",
                newName: "Sessions");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Session_ShowId",
                table: "Sessions",
                newName: "IX_Sessions_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SessionId",
                table: "Seats",
                newName: "IX_Seats_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ReservationId",
                table: "Seats",
                newName: "IX_Seats_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_UserId",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "SeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Reservations_ReservationId",
                table: "Seats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Sessions_SessionId",
                table: "Seats",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Shows_ShowId",
                table: "Sessions",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Reservations_ReservationId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Sessions_SessionId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Shows_ShowId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Sessions",
                newName: "Session");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_ShowId",
                table: "Session",
                newName: "IX_Session_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_SessionId",
                table: "Seat",
                newName: "IX_Seat_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_ReservationId",
                table: "Seat",
                newName: "IX_Seat_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "Reservation",
                newName: "IX_Reservation_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session",
                table: "Session",
                column: "SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "SeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Users_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Shows_ShowId",
                table: "Session",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId");
        }
    }
}
