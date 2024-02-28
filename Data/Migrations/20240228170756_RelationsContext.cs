using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater.Data.Migrations
{
    public partial class RelationsContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Shows_ShowId",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SessionId",
                table: "Reservations",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Sessions_SessionId",
                table: "Reservations",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Shows_ShowId",
                table: "Sessions",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Sessions_SessionId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Shows_ShowId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SessionId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Shows_ShowId",
                table: "Sessions",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId");
        }
    }
}
