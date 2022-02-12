using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class TableConfigurationsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "PersonContacts",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PersonContacts",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "PersonContacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PersonContacts",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

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
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 12, 1, 40, 19, 943, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 12, 1, 40, 19, 943, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 12, 1, 40, 19, 937, DateTimeKind.Local).AddTicks(8986), new Guid("b6f3c214-12bb-4d39-a22c-74e4e4b0a59f") });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2022, 2, 12, 1, 40, 19, 942, DateTimeKind.Local).AddTicks(8696), new Guid("221b7e08-f32e-4af4-b3dd-5783a14d3381") });
        }
    }
}
