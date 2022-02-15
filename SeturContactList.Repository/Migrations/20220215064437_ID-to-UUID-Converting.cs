using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SeturContactList.Repository.Migrations
{
    public partial class IDtoUUIDConverting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Reports",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReportId",
                table: "ReportDetail",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ReportDetail",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Persons",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "PersonContacts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PersonContacts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reports",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "ReportDetail",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ReportDetail",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Persons",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PersonContacts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PersonContacts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Company", "CreatedDate", "Name", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "TestCompany", new DateTime(2022, 2, 13, 17, 29, 46, 965, DateTimeKind.Local).AddTicks(2354), "Mustafa", "Alkan", null },
                    { 2, "TestCompany1", new DateTime(2022, 2, 13, 17, 29, 46, 969, DateTimeKind.Local).AddTicks(5856), "Ahmet", "Alkan", null }
                });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "Email", "Info", "Lat", "Long", "PersonId", "Phone", "Town", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 13, 17, 29, 46, 970, DateTimeKind.Local).AddTicks(3724), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, 1, "+905553332211", "Çiğli", null },
                    { 2, "İzmir Bornova", "İzmir", new DateTime(2022, 2, 13, 17, 29, 46, 970, DateTimeKind.Local).AddTicks(3747), "mustafaalkan64@gmail.com", "Test Info", 35m, 28m, 1, "+905553332212", "Bornova", null },
                    { 3, "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 13, 17, 29, 46, 970, DateTimeKind.Local).AddTicks(3751), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, 2, "+905553332211", "Çiğli", null },
                    { 4, "İzmir Bornova", "İzmir", new DateTime(2022, 2, 13, 17, 29, 46, 970, DateTimeKind.Local).AddTicks(3753), "mustafaalkan64@gmail.com", "Test Info", 35m, 28m, 2, "+905553332212", "Bornova", null }
                });
        }
    }
}
