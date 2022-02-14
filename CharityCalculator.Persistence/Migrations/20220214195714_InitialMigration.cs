using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CharityCalculator.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplementInPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumDonationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateInPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RateType = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "DateCreated", "LastModified", "MaximumDonationAmount", "Name", "SupplementInPercentage" },
                values: new object[,]
                {
                    { new Guid("46c3a42c-e57c-4dd6-8d3f-a07049867d1d"), new DateTime(2022, 2, 14, 21, 57, 13, 750, DateTimeKind.Local).AddTicks(5514), new DateTime(2022, 2, 14, 21, 57, 13, 751, DateTimeKind.Local).AddTicks(5079), 100000m, "Sports", 5m },
                    { new Guid("a1d9e128-a54c-4ac5-a8d4-cbb902f05d45"), new DateTime(2022, 2, 14, 21, 57, 13, 751, DateTimeKind.Local).AddTicks(9720), new DateTime(2022, 2, 14, 21, 57, 13, 751, DateTimeKind.Local).AddTicks(9727), 100000m, "Political", 3m },
                    { new Guid("eaa00086-4626-4a46-8f7b-b4285e0b9950"), new DateTime(2022, 2, 14, 21, 57, 13, 751, DateTimeKind.Local).AddTicks(9739), new DateTime(2022, 2, 14, 21, 57, 13, 751, DateTimeKind.Local).AddTicks(9740), 100000m, "Other", 0m }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "DateCreated", "LastModified", "RateInPercentage", "RateType" },
                values: new object[] { new Guid("62ab6a74-e769-4f54-8e5c-5ef891d9b1f5"), new DateTime(2022, 2, 14, 21, 57, 13, 771, DateTimeKind.Local).AddTicks(7164), new DateTime(2022, 2, 14, 21, 57, 13, 771, DateTimeKind.Local).AddTicks(7189), 20m, 1 });

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
