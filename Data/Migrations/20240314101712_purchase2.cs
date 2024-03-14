using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater.Data.Migrations
{
    public partial class purchase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Purchases_PurchaseId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_PurchaseId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Seats");

            migrationBuilder.CreateTable(
                name: "SeatCreateDTO",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatIdReserved = table.Column<int>(type: "int", nullable: false),
                    IsDisponible = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatCreateDTO", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_SeatCreateDTO_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatCreateDTO_PurchaseId",
                table: "SeatCreateDTO",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatCreateDTO");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_PurchaseId",
                table: "Seats",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Purchases_PurchaseId",
                table: "Seats",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "PurchaseId");
        }
    }
}
