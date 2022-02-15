using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturContactList.Repository.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Company = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReportStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Info = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Town = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Lat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Long = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContacts_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    RegisteredPersonCount = table.Column<int>(type: "integer", nullable: false),
                    RegisteredPhoneCount = table.Column<int>(type: "integer", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    Lat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Long = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Company", "CreatedDate", "Name", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("8d7f8dee-5004-4798-ac79-5dfb17d52e65"), "TestCompany", new DateTime(2022, 2, 15, 11, 35, 41, 788, DateTimeKind.Local).AddTicks(7361), "Mustafa", "Alkan", null },
                    { new Guid("76d4ee7e-8745-4ea0-83f6-55f73cb0fc3d"), "TestCompany1", new DateTime(2022, 2, 15, 11, 35, 41, 792, DateTimeKind.Local).AddTicks(2627), "Ahmet", "Alkan", null }
                });

            migrationBuilder.InsertData(
                table: "PersonContacts",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "Email", "Info", "Lat", "Long", "PersonId", "Phone", "Town", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5f8c91a9-4060-4aed-bd93-594eefe0f542"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 11, 35, 41, 792, DateTimeKind.Local).AddTicks(7466), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("8d7f8dee-5004-4798-ac79-5dfb17d52e65"), "+905553332211", "Çiğli", null },
                    { new Guid("4229bc48-8d65-4768-89ac-6b1173976aed"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 11, 35, 41, 792, DateTimeKind.Local).AddTicks(7502), "mustafaalkan64@gmail.com", "Test Info", 34m, 27m, new Guid("8d7f8dee-5004-4798-ac79-5dfb17d52e65"), "+905553332212", "Bornova", null },
                    { new Guid("a036e73c-0b13-4eae-a731-8559b554e5cc"), "İzmir Bornova", "İzmir", new DateTime(2022, 2, 15, 11, 35, 41, 792, DateTimeKind.Local).AddTicks(7512), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("8d7f8dee-5004-4798-ac79-5dfb17d52e65"), "+905553332212", "Bornova", null },
                    { new Guid("8a19f8a0-8a7c-4932-9cd9-d4dff9cd219a"), "İzmir Çiğli", "İzmir", new DateTime(2022, 2, 15, 11, 35, 41, 792, DateTimeKind.Local).AddTicks(7508), "mustafaalkan64@gmail.com", "Test Info", 38m, 26m, new Guid("76d4ee7e-8745-4ea0-83f6-55f73cb0fc3d"), "+905553332211", "Çiğli", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_PersonId",
                table: "PersonContacts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetail_ReportId",
                table: "ReportDetail",
                column: "ReportId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonContacts");

            migrationBuilder.DropTable(
                name: "ReportDetail");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
