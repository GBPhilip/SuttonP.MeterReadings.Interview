using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuttonP.MeterReadings.Data.Migrations
{
    public partial class initialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetersReadings",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Taken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetersReadings", x => new { x.AccountId, x.Taken });
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "2344", "Tommy", "Test" },
                    { "1246", "Jo", "Test" },
                    { "1245", "Neville", "Test" },
                    { "1244", "Tony", "Test" },
                    { "1243", "Graham", "Test" },
                    { "1242", "Tim", "Test" },
                    { "1241", "Lara", "Test" },
                    { "1240", "Archie", "Test" },
                    { "1239", "Noddy", "Test" },
                    { "1234", "Freya", "Test" },
                    { "4534", "JOSH", "TEST" },
                    { "6776", "Laura", "Test" },
                    { "1247", "Jim", "Test" },
                    { "2356", "Craig", "Test" },
                    { "2353", "Tony", "Test" },
                    { "2352", "Greg", "Test" },
                    { "2351", "Gladys", "Test" },
                    { "2350", "Colin", "Test" },
                    { "2349", "Simon", "Test" },
                    { "2348", "Tammy", "Test" },
                    { "2347", "Tara", "Test" },
                    { "2346", "Ollie", "Test" },
                    { "2345", "Jerry", "Test" },
                    { "8766", "Sally", "Test" },
                    { "2233", "Barry", "Test" },
                    { "2355", "Arthur", "Test" },
                    { "1248", "Pam", "Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "MetersReadings");
        }
    }
}
