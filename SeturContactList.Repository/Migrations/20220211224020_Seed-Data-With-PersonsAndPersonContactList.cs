using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class SeedDataWithPersonsAndPersonContactList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 12, 1, 40, 19, 943, DateTimeKind.Local).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 12, 1, 40, 19, 943, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 12, 1, 40, 19, 937, DateTimeKind.Local).AddTicks(8986), new Guid("b6f3c214-12bb-4d39-a22c-74e4e4b0a59f") });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Company", "CreatedDate", "Name", "Surname", "UUID", "UpdatedDate" },
                values: new object[] { 2, "TestCompany1", new DateTime(2022, 2, 12, 1, 40, 19, 942, DateTimeKind.Local).AddTicks(8696), "Ahmet", "Alkan", new Guid("221b7e08-f32e-4af4-b3dd-5783a14d3381"), null });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "Email", "Info", "Lat", "Long", "PersonId", "Phone", "Town", "UpdatedDate" },
                values: new object[,]
                {
                    { 3, "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 12, 1, 40, 19, 943, DateTimeKind.Local).AddTicks(9846), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, 2, "+905553332211", "Çiğli", null },
                    { 4, "İzmir Bornova", "İzmir", new DateTime(2022, 2, 12, 1, 40, 19, 943, DateTimeKind.Local).AddTicks(9850), "mustafaalkan64@gmail.com", "Test Info", 35m, 28m, 2, "+905553332212", "Bornova", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 12, 0, 29, 29, 441, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 12, 0, 29, 29, 441, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 12, 0, 29, 29, 436, DateTimeKind.Local).AddTicks(8068), new Guid("e496d53f-3af2-40c3-be8a-6f6984262851") });
        }
    }
}
