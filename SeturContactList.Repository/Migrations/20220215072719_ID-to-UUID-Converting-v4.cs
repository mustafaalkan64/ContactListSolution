using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class IDtoUUIDConvertingv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "identifier",
                keyValue: new Guid("42eb2eaa-28cf-4b61-814e-ffa4c9bb1a58"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "identifier",
                keyValue: new Guid("71a1a403-ee7f-47b3-938a-eb6e0a96179f"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "identifier",
                keyValue: new Guid("745d839f-b7b0-4212-835e-b430690c5dc3"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "identifier",
                keyValue: new Guid("9bac7aea-eba5-49ca-bad8-0e7cf06bfd74"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "identifier",
                keyValue: new Guid("6c18f769-1323-4837-88af-83b9cacb8e71"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "identifier",
                keyValue: new Guid("8d3c2b96-0030-468d-9873-abe1840b2bb1"));

            migrationBuilder.RenameColumn(
                name: "identifier",
                table: "Reports",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "identifier",
                table: "ReportDetail",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "identifier",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "identifier",
                table: "PersonContacts",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Company", "CreatedDate", "Name", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("f8e5d8ce-0259-41ef-8db9-1de0dc5ce904"), "TestCompany", new DateTime(2022, 2, 15, 10, 27, 19, 106, DateTimeKind.Local).AddTicks(2400), "Mustafa", "Alkan", null },
                    { new Guid("45881f50-4c69-4840-b588-1ed2a1a46e53"), "TestCompany1", new DateTime(2022, 2, 15, 10, 27, 19, 109, DateTimeKind.Local).AddTicks(4652), "Ahmet", "Alkan", null }
                });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "Email", "Info", "Lat", "Long", "PersonId", "Phone", "Town", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("ab2c1f81-fb35-4b92-87ae-d1aef68ea84c"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 10, 27, 19, 109, DateTimeKind.Local).AddTicks(9805), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("f8e5d8ce-0259-41ef-8db9-1de0dc5ce904"), "+905553332211", "Çiğli", null },
                    { new Guid("35a07a43-e05f-45a7-8e58-e2a6737fc7ed"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 10, 27, 19, 109, DateTimeKind.Local).AddTicks(9840), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("f8e5d8ce-0259-41ef-8db9-1de0dc5ce904"), "+905553332212", "Bornova", null },
                    { new Guid("70a273f6-c69d-42a2-ac95-4d2c9a2d9eee"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 10, 27, 19, 109, DateTimeKind.Local).AddTicks(9879), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("f8e5d8ce-0259-41ef-8db9-1de0dc5ce904"), "+905553332212", "Bornova", null },
                    { new Guid("08cc4476-20c1-40bf-ab83-f492de7b92af"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 10, 27, 19, 109, DateTimeKind.Local).AddTicks(9846), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("45881f50-4c69-4840-b588-1ed2a1a46e53"), "+905553332211", "Çiğli", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("08cc4476-20c1-40bf-ab83-f492de7b92af"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("35a07a43-e05f-45a7-8e58-e2a6737fc7ed"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("70a273f6-c69d-42a2-ac95-4d2c9a2d9eee"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("ab2c1f81-fb35-4b92-87ae-d1aef68ea84c"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("45881f50-4c69-4840-b588-1ed2a1a46e53"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("f8e5d8ce-0259-41ef-8db9-1de0dc5ce904"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reports",
                newName: "identifier");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReportDetail",
                newName: "identifier");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "identifier");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PersonContacts",
                newName: "identifier");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "identifier", "Company", "CreatedDate", "Name", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("8d3c2b96-0030-468d-9873-abe1840b2bb1"), "TestCompany", new DateTime(2022, 2, 15, 10, 10, 23, 322, DateTimeKind.Local).AddTicks(2260), "Mustafa", "Alkan", null },
                    { new Guid("6c18f769-1323-4837-88af-83b9cacb8e71"), "TestCompany1", new DateTime(2022, 2, 15, 10, 10, 23, 325, DateTimeKind.Local).AddTicks(3525), "Ahmet", "Alkan", null }
                });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "identifier", "Address", "City", "CreatedDate", "Email", "Info", "Lat", "Long", "PersonId", "Phone", "Town", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("71a1a403-ee7f-47b3-938a-eb6e0a96179f"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 10, 10, 23, 325, DateTimeKind.Local).AddTicks(8274), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("8d3c2b96-0030-468d-9873-abe1840b2bb1"), "+905553332211", "Çiğli", null },
                    { new Guid("9bac7aea-eba5-49ca-bad8-0e7cf06bfd74"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 10, 10, 23, 325, DateTimeKind.Local).AddTicks(8304), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("8d3c2b96-0030-468d-9873-abe1840b2bb1"), "+905553332212", "Bornova", null },
                    { new Guid("42eb2eaa-28cf-4b61-814e-ffa4c9bb1a58"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 10, 10, 23, 325, DateTimeKind.Local).AddTicks(8334), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("8d3c2b96-0030-468d-9873-abe1840b2bb1"), "+905553332212", "Bornova", null },
                    { new Guid("745d839f-b7b0-4212-835e-b430690c5dc3"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 10, 10, 23, 325, DateTimeKind.Local).AddTicks(8310), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("6c18f769-1323-4837-88af-83b9cacb8e71"), "+905553332211", "Çiğli", null }
                });
        }
    }
}
