using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Locamoto.Infra.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "locamoto",
                table: "CostPlan",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "locamoto",
                table: "CostPlan",
                columns: new[] { "Id", "AdditionalCostPerDay", "CostPerDay", "Description", "EndDay", "PercentageFine", "StartDay" },
                values: new object[,]
                {
                    { new Guid("9d1e5149-cc43-440c-9f0f-93b9b80b37b8"), 50m, 28m, "Fifteen Days Plan", 15, 40m, 15 },
                    { new Guid("a424ebe5-4e62-4ead-b70a-875f3eaad7fb"), 50m, 22m, "Thirty Days Plan", 30, 60m, 30 },
                    { new Guid("b0174e5b-b8de-4b83-a30b-af958cb508ce"), 50m, 30m, "Seven Days Plan", 7, 20m, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "locamoto",
                table: "CostPlan",
                keyColumn: "Id",
                keyValue: new Guid("9d1e5149-cc43-440c-9f0f-93b9b80b37b8"));

            migrationBuilder.DeleteData(
                schema: "locamoto",
                table: "CostPlan",
                keyColumn: "Id",
                keyValue: new Guid("a424ebe5-4e62-4ead-b70a-875f3eaad7fb"));

            migrationBuilder.DeleteData(
                schema: "locamoto",
                table: "CostPlan",
                keyColumn: "Id",
                keyValue: new Guid("b0174e5b-b8de-4b83-a30b-af958cb508ce"));

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "locamoto",
                table: "CostPlan");
        }
    }
}
