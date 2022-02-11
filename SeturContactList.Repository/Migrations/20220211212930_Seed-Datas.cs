using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class SeedDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "Email", "Info", "Lat", "Long", "PersonId", "Phone", "Town", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 12, 0, 29, 29, 441, DateTimeKind.Local).AddTicks(6199), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, 1, "+905553332211", "Çiğli", null },
                    { 2, "İzmir Bornova", "İzmir", new DateTime(2022, 2, 12, 0, 29, 29, 441, DateTimeKind.Local).AddTicks(6270), "mustafaalkan64@gmail.com", "Test Info", 35m, 28m, 1, "+905553332212", "Bornova", null }
                });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 12, 0, 29, 29, 436, DateTimeKind.Local).AddTicks(8068), new Guid("e496d53f-3af2-40c3-be8a-6f6984262851") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 11, 23, 55, 58, 77, DateTimeKind.Local).AddTicks(5578), new Guid("76e13291-4318-480f-bd8f-3f77137b9ed6") });
        }
    }
}
