using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class IDtoUUIDConvertingv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "identifier",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "identifier",
                table: "ReportDetail",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "identifier",
                table: "Persons",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "identifier",
                table: "PersonContacts",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Reports",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ReportDetail",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Persons",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PersonContacts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "uuid_generate_v4()");

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
    }
}
