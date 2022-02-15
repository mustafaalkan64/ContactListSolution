using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class IDtoUUIDConvertingv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("1a72b8c2-8fec-464f-933e-ad60f38a8d1c"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("1e1ff757-137f-4182-935f-c40e3f4291f8"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("7c11be34-1773-435b-b7b0-b84d0c18eb39"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("c44b45ab-2907-4bca-a84f-3a6b0b1dfb38"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("03ca753f-eefd-46f5-b268-bf5fd7021971"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("dad62457-1466-40e7-8d47-bb91f583cabb"));

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Company", "CreatedDate", "Name", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"), "TestCompany", new DateTime(2022, 2, 15, 10, 0, 25, 89, DateTimeKind.Local).AddTicks(8959), "Mustafa", "Alkan", null },
                    { new Guid("0506db6a-b729-492d-86fd-d44f3bbf51be"), "TestCompany1", new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(3026), "Ahmet", "Alkan", null }
                });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "Email", "Info", "Lat", "Long", "PersonId", "Phone", "Town", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d1bbfb72-f58a-4552-8548-026a8c33f395"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(8261), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"), "+905553332211", "Çiğli", null },
                    { new Guid("5da4b2f8-55b0-4d08-8c7a-d7d343ea7109"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(8297), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"), "+905553332212", "Bornova", null },
                    { new Guid("51ae353c-14e7-428d-a6a2-d89c4f6a7450"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(8309), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"), "+905553332212", "Bornova", null },
                    { new Guid("c8827037-a183-40b9-a7ab-0e489548c577"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 10, 0, 25, 94, DateTimeKind.Local).AddTicks(8305), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("0506db6a-b729-492d-86fd-d44f3bbf51be"), "+905553332211", "Çiğli", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("51ae353c-14e7-428d-a6a2-d89c4f6a7450"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("5da4b2f8-55b0-4d08-8c7a-d7d343ea7109"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("c8827037-a183-40b9-a7ab-0e489548c577"));

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: new Guid("d1bbfb72-f58a-4552-8548-026a8c33f395"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("0506db6a-b729-492d-86fd-d44f3bbf51be"));

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("a36f226f-bb10-46bb-b4e4-f2e6517b88d7"));

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Company", "CreatedDate", "Name", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("dad62457-1466-40e7-8d47-bb91f583cabb"), "TestCompany", new DateTime(2022, 2, 15, 9, 44, 36, 394, DateTimeKind.Local).AddTicks(2859), "Mustafa", "Alkan", null },
                    { new Guid("03ca753f-eefd-46f5-b268-bf5fd7021971"), "TestCompany1", new DateTime(2022, 2, 15, 9, 44, 36, 398, DateTimeKind.Local).AddTicks(6303), "Ahmet", "Alkan", null }
                });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "Email", "Info", "Lat", "Long", "PersonId", "Phone", "Town", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7c11be34-1773-435b-b7b0-b84d0c18eb39"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 9, 44, 36, 399, DateTimeKind.Local).AddTicks(2974), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("dad62457-1466-40e7-8d47-bb91f583cabb"), "+905553332211", "Çiğli", null },
                    { new Guid("1a72b8c2-8fec-464f-933e-ad60f38a8d1c"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 9, 44, 36, 399, DateTimeKind.Local).AddTicks(3017), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("dad62457-1466-40e7-8d47-bb91f583cabb"), "+905553332212", "Bornova", null },
                    { new Guid("1e1ff757-137f-4182-935f-c40e3f4291f8"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 9, 44, 36, 399, DateTimeKind.Local).AddTicks(3058), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("dad62457-1466-40e7-8d47-bb91f583cabb"), "+905553332212", "Bornova", null },
                    { new Guid("c44b45ab-2907-4bca-a84f-3a6b0b1dfb38"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 9, 44, 36, 399, DateTimeKind.Local).AddTicks(3027), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("03ca753f-eefd-46f5-b268-bf5fd7021971"), "+905553332211", "Çiğli", null }
                });
        }
    }
}
