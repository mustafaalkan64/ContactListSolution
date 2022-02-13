using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class ReportDetailTableLatLongFieldsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Lat",
                table: "ReportDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Long",
                table: "ReportDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 29, 46, 970, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 29, 46, 970, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 29, 46, 970, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 29, 46, 970, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 29, 46, 965, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 29, 46, 969, DateTimeKind.Local).AddTicks(5856));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "ReportDetail");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "ReportDetail");

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 26, 35, 973, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 26, 35, 973, DateTimeKind.Local).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 26, 35, 973, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "PersonContacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 26, 35, 973, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 26, 35, 968, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 13, 17, 26, 35, 972, DateTimeKind.Local).AddTicks(2577));
        }
    }
}
