using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater.Data.Migrations
{
    public partial class DataSessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "Hour", "Seats", "ShowId" },
                values: new object[] { 1, new TimeSpan(0, 10, 30, 0, 0), 54, 1 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "Hour", "Seats", "ShowId" },
                values: new object[] { 2, new TimeSpan(0, 21, 30, 0, 0), 54, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "SessionId",
                keyValue: 2);
        }
    }
}
