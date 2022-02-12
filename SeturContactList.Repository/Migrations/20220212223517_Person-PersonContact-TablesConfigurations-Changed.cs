using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class PersonPersonContactTablesConfigurationsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "PersonContacts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Long",
                table: "PersonContacts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "PersonContacts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "PersonContacts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PersonContacts",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 1, 35, 16, 341, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 1, 35, 16, 341, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 1, 35, 16, 341, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 1, 35, 16, 341, DateTimeKind.Local).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 13, 1, 35, 16, 336, DateTimeKind.Local).AddTicks(8241), new Guid("130da54c-45c0-4092-8f3b-147ed61c5d38") });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 13, 1, 35, 16, 340, DateTimeKind.Local).AddTicks(7314), new Guid("92f99b9f-910b-49e8-aa89-48cd610c96ea") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "PersonContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "Long",
                table: "PersonContacts",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Lat",
                table: "PersonContacts",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "PersonContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PersonContacts",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 1, 23, 22, 477, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 1, 23, 22, 477, DateTimeKind.Local).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 1, 23, 22, 477, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 1, 23, 22, 477, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 13, 1, 23, 22, 471, DateTimeKind.Local).AddTicks(7550), new Guid("ed1730b5-6e1a-488d-8182-f449a72e229a") });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 13, 1, 23, 22, 475, DateTimeKind.Local).AddTicks(7520), new Guid("ab440d7b-d204-4a65-b4ba-8d34fbe92121") });
        }
    }
}
