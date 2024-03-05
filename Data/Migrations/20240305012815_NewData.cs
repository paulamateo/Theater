using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater.Data.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateSession",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "QuantitySeats",
                table: "Sessions",
                newName: "Seats");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Shows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Shows",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hour",
                table: "Sessions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 1,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/9d9e9eae70cef77f81c68fd38937b695/b_phantom.png", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "2h 30min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/07ae39b53a3acdc8968c013078a84841/p_thephantomoftheopera.jpeg", 20.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/2e9ae883a3dc891af2a99b7804ead214/s_phantom.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 2,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/5d4beb1235f03f615bcdb237230fac91/b_macbeth.png", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2h 40min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/ea5ad6e8925b91ef21b62088f648314a/p_macbeth.jpeg", 15.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/b71739051371095fb33f0c70d6f96de4/s_macbeth.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 3,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/d1b5777a32659e0dd7bab2dbde00a8f9/b_hamlet.png", new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "2h 15min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/9fbd3ea41e55810ca3336f994d0a48c6/p_hamlet.jpeg", 15.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/9dc454654e21699c2a1033a8a35bf042/s_hamlet.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 4,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/a9591f2ecfd2e4928eb7d3ffd374ca4a/b_thenutcracker.png", new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "2h 30min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/00c2e3e17214c2efa70d280d78233cd4/p_thenutcracker.jpeg", 20.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/30711ffe3387c6918b6ca8c35dc0e812/s_thenutcracker.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 5,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/f7ec4aaaeafb30de8db7aa06bf7ac08e/b_thedivinecomedy.png", new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "2h 30min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/1676a101744ff32be3d11e5fb3b8615b/p_thedivinecomedy.jpeg", 14.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/0bf9e00dde5f4fb94bf5044d2d1bbab5/s_thedivinecomedy.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 6,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/3522ef62c7f67a3afaf83d6fcb911fe2/b_oedipustheking.png", new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "2h 45min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/5db151c70121f5c2f80eb198ebdbba0d/p_oedipustheking.jpeg", 19.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/aea6c90f198b4f0ffd7276238c2b44c1/s_oedipustheking.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 7,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/e294cda3a370b5deea4fafd69e3466f9/b_romeoandjuliet.png", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "2h 30min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/acb9c14cc16797b00208ce227ee172f3/p_romeoandjuliet.jpeg", 9.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/29162ffd1bcd89c987c503a344307960/s_romeoandjuliet.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 8,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/a14cf3c7848810881350294b7214a2cd/b_camelot.png", new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "1h 50min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/a46e3f593a2193f455774a22b1f54ce3/p_camelot.jpeg", 29.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/6a3b478a11f81621fe65f1db10c92dc8/s_camelot.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 9,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/af886f5ff9d88e8c9d619dfd148427ad/b_ladies.png", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1h 30min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/1e9abaa74edce8f90bb2261d89f4f96a/p_ladies.jpeg", 16.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/7b33bf9ff3491b0230df25f7dd7f25ce/s_ladies.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 10,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/292aa53528be96d2eb0c61aee86a59c8/b_lacelestina.png", new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "2h 30min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/406d4bad91ab911da6d7728f0f88d24f/p_lacelestina.jpeg", 12.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/222794f7e04db9953ec35b2668a4fdc5/s_lacelestina.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 11,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/a786ada47aa8254ff8dfa547babe1cdf/b_anidealhusband.png", new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "1h 35min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/dab8afc2e4fcd8df3b04255035f8db66/p_anidealhusband.jpeg", 8.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/2004d6a6accf3ba509e0e9679ede962e/s_anidealhusband.png" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 12,
                columns: new[] { "Banner", "Date", "Length", "Poster", "Price", "Scene" },
                values: new object[] { "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/dd36636fdd06ef46ce1f6db22217862b/b_themousetrap.png", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "1h 45min", "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/fc3a921c4ea328191548e9bb390304be/p_themousetrap.jpeg", 8.99m, "https://storage.kraken.io/ZBONL73pVgSYgrww7BGD/69c7d98a881ef03de9efe739dc24d32f/s_themousetrap.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "Sessions",
                newName: "QuantitySeats");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSession",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 1,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1NGhwQlqgvWOIn57JcsqllUP66iM49Ia2/view?usp=drive_link", "https://drive.google.com/file/d/1y0n2XHUkZDIWD05QYoWkaT_9gCPMkNfc/view?usp=drive_link", "https://drive.google.com/file/d/1jqkJDVs061aXzFe-FXZpCcoqiy8dE2z4/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 2,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1ZOZLpbUGwXjRRvaYWVTz7h_ucWewv38_/view?usp=drive_link", "https://drive.google.com/file/d/1-gJpYA2C-H5xZlvOUZE77oKgPihBjDg4/view?usp=drive_link", "https://drive.google.com/file/d/1BjnQ80OFheoePkn9i3BpKbM5cUSajQ0K/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 3,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/17GWvt66xTo_n1viXyKmG0S4zIT1FUpUh/view?usp=drive_link", "https://drive.google.com/file/d/18h893tKSQQShPmN4VYa1KrzvPxq7mb1M/view?usp=drive_link", "https://drive.google.com/file/d/1oRJz3seD4ZWeHe6wZ7LnVnsYaDg7wY-q/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 4,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1QSDgZE7HwZHFwo4iIKHYRm5KkmJBbPSB/view?usp=drive_link", "https://drive.google.com/file/d/16_V6zHu2gpVnwF3rTJezT_Ktk6B-EzHw/view?usp=drive_link", "https://drive.google.com/file/d/1Brx4QJn7s_-TXOF7Iwd1woTW-SUYN7r6/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 5,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/19Dj84rZ4DO6Dj7iwpaYFccgfLY_2lCJJ/view?usp=drive_link", "https://drive.google.com/file/d/1LGR7FzcanTBBW01w_XtmsqEKj7JFVY8K/view?usp=drive_link", "https://drive.google.com/file/d/1UdOt-xBNm5L58GhnSeJ_Fwlgf31ZbIJb/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 6,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1qbLKuUyzSOYnuyBaOk1PSSbY4UU73vvi/view?usp=drive_link", "https://drive.google.com/file/d/1CTLJ4JGviv9uhGZI6QwEva8DbUJ5wv2R/view?usp=drive_link", "n" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 7,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1jKvBobDQ_pn7kzt3QZi02pJVIFcaSzUW/view?usp=drive_link", "https://drive.google.com/file/d/1PZ9cy2LlNhn_r2JM8z0UFQQK8-3Kka3s/view?usp=drive_link", "https://drive.google.com/file/d/1mbTMT9cVxGG6M8I6Y3vC9F2SHxxRwHFe/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 8,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1I9oB3EYMm_jVQhqoHHYxhLMXChta3uwS/view?usp=drive_link", "https://drive.google.com/file/d/1wNM6XE-jDR-h7Nhpc_WIHEnzi212rE87/view?usp=drive_link", "https://drive.google.com/file/d/1ZvyjfiCNJF1jAbP79G7YAFwWfTGNE3ho/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 9,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1ox73tXCUUo6shuuHzBUEuanichBNDhQw/view?usp=drive_link", "https://drive.google.com/file/d/1-u8OVywSajG863ZysYGQa3es6FIx4jz_/view?usp=drive_link", "https://drive.google.com/file/d/13kHTAqTMfP_DYj-GmjZZdmSoznW3R9KQ/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 10,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1FP3T9cm6ytOt8IikbdIgnb68KNc1_Rhy/view?usp=drive_link", "https://drive.google.com/file/d/11ZeGz4U1CzFBBjTqm3ItGRZ6xTwdpBpj/view?usp=drive_link", "https://drive.google.com/file/d/1TtL-dEo7yaXi1k3O3z6XN1vM-XC1UoBl/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 11,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1KheIyggXx2I1SKHfdASHdKs-d7OEqr2G/view?usp=drive_link", "https://drive.google.com/file/d/1QZHM1CS4svOh46zPjkXIS2FZX8-JTjrp/view?usp=drive_link", "https://drive.google.com/file/d/1eWRkNSJh6Jcmqy3tLno3R21APGdJLwsv/view?usp=drive_link" });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 12,
                columns: new[] { "Banner", "Poster", "Scene" },
                values: new object[] { "https://drive.google.com/file/d/1dcn5n3FuiP78V-lU6-xWx5dncN1dL9It/view?usp=drive_link", "https://drive.google.com/file/d/11lKDLzypERZiOHl0MGALoB6dBVNs3OfP/view?usp=drive_link", "https://drive.google.com/file/d/15FbPzaiMrUuv3NHk8PZvTbErAEWxxPjb/view?usp=drive_link" });
        }
    }
}
