using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locamoto.Infra.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "locamoto");

            migrationBuilder.CreateTable(
                name: "CostPlan",
                schema: "locamoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDay = table.Column<int>(type: "integer", nullable: false),
                    EndDay = table.Column<int>(type: "integer", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "numeric", nullable: false),
                    AdditionalCostPerDay = table.Column<decimal>(type: "numeric", nullable: false),
                    PercentageFine = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveryman",
                schema: "locamoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CnhImage = table.Column<string>(type: "text", nullable: false),
                    CnhNumber = table.Column<string>(type: "text", nullable: false),
                    CnhTipe = table.Column<int>(type: "integer", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveryman", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycle",
                schema: "locamoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Plate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "locamoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DeliverymanID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Deliveryman_DeliverymanID",
                        column: x => x.DeliverymanID,
                        principalSchema: "locamoto",
                        principalTable: "Deliveryman",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                schema: "locamoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpectedEndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ExpectedCost = table.Column<decimal>(type: "numeric", nullable: false),
                    FineCost = table.Column<decimal>(type: "numeric", nullable: false),
                    RealCost = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    MotorcycleID = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanID = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliverymanID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rent_CostPlan_PlanID",
                        column: x => x.PlanID,
                        principalSchema: "locamoto",
                        principalTable: "CostPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rent_Deliveryman_DeliverymanID",
                        column: x => x.DeliverymanID,
                        principalSchema: "locamoto",
                        principalTable: "Deliveryman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rent_Motorcycle_MotorcycleID",
                        column: x => x.MotorcycleID,
                        principalSchema: "locamoto",
                        principalTable: "Motorcycle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliverymanID",
                schema: "locamoto",
                table: "Order",
                column: "DeliverymanID");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_DeliverymanID",
                schema: "locamoto",
                table: "Rent",
                column: "DeliverymanID");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_MotorcycleID",
                schema: "locamoto",
                table: "Rent",
                column: "MotorcycleID");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_PlanID",
                schema: "locamoto",
                table: "Rent",
                column: "PlanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order",
                schema: "locamoto");

            migrationBuilder.DropTable(
                name: "Rent",
                schema: "locamoto");

            migrationBuilder.DropTable(
                name: "CostPlan",
                schema: "locamoto");

            migrationBuilder.DropTable(
                name: "Deliveryman",
                schema: "locamoto");

            migrationBuilder.DropTable(
                name: "Motorcycle",
                schema: "locamoto");
        }
    }
}
