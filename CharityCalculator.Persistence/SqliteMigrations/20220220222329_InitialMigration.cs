using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CharityCalculator.Persistence.SqliteMigrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SupplementInPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    MaximumDonationAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RateInPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    RateType = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "DateCreated", "LastModified", "MaximumDonationAmount", "Name", "SupplementInPercentage" },
                values: new object[] { new Guid("d3f91375-114d-4e73-84a4-f70691df7571"), new DateTime(2022, 2, 21, 0, 23, 28, 598, DateTimeKind.Local).AddTicks(602), new DateTime(2022, 2, 21, 0, 23, 28, 598, DateTimeKind.Local).AddTicks(9700), 100000m, "Sports", 5m });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "DateCreated", "LastModified", "MaximumDonationAmount", "Name", "SupplementInPercentage" },
                values: new object[] { new Guid("6b651a9e-4c9a-41c1-915e-b5d913939d52"), new DateTime(2022, 2, 21, 0, 23, 28, 599, DateTimeKind.Local).AddTicks(4229), new DateTime(2022, 2, 21, 0, 23, 28, 599, DateTimeKind.Local).AddTicks(4237), 100000m, "Political", 3m });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "DateCreated", "LastModified", "MaximumDonationAmount", "Name", "SupplementInPercentage" },
                values: new object[] { new Guid("24cbf6e1-d896-4ac6-92c9-29c32807a3dd"), new DateTime(2022, 2, 21, 0, 23, 28, 599, DateTimeKind.Local).AddTicks(4249), new DateTime(2022, 2, 21, 0, 23, 28, 599, DateTimeKind.Local).AddTicks(4251), 100000m, "Other", 0m });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "DateCreated", "LastModified", "RateInPercentage", "RateType" },
                values: new object[] { new Guid("b588caa4-1c9d-4a79-b58a-b5a2b7ec0032"), new DateTime(2022, 2, 21, 0, 23, 28, 611, DateTimeKind.Local).AddTicks(9606), new DateTime(2022, 2, 21, 0, 23, 28, 611, DateTimeKind.Local).AddTicks(9628), 20m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_RateType",
                table: "Rates",
                column: "RateType",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Rates");
        }
    }
}
