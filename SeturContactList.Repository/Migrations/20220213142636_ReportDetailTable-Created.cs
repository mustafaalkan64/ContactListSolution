using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SeturContactList.Repository.Migrations
{
    public partial class ReportDetailTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UUID",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UUID",
                table: "Persons");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDate",
                table: "Reports",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "PersonContacts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "ReportDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegisteredPersonCount = table.Column<int>(type: "integer", nullable: false),
                    RegisteredPhoneCount = table.Column<int>(type: "integer", nullable: false),
                    ReportId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportDetail_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetail_ReportId",
                table: "ReportDetail",
                column: "ReportId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportDetail");

            migrationBuilder.DropColumn(
                name: "RequestedDate",
                table: "Reports");

            migrationBuilder.AddColumn<Guid>(
                name: "UUID",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UUID",
                table: "Persons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "PersonContacts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
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
    }
}
