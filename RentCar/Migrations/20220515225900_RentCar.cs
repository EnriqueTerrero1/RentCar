using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCar.Migrations
{
    public partial class RentCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identificationCard = table.Column<int>(type: "int", nullable: false),
                    tarjetaCrNumber = table.Column<int>(type: "int", nullable: false),
                    creditLimit = table.Column<double>(type: "float", nullable: false),
                    PersonKind = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identificationCard = table.Column<int>(type: "int", nullable: false),
                    workingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionPercentage = table.Column<double>(type: "float", nullable: false),
                    datedateOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fuel_Types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuel_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicule_Types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicule_Types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehiculemodels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brandid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculemodels", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehiculemodels_brands_brandid",
                        column: x => x.brandid,
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicule",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chasisNumber = table.Column<int>(type: "int", nullable: false),
                    motorNumber = table.Column<int>(type: "int", nullable: false),
                    plateNumber = table.Column<int>(type: "int", nullable: false),
                    vehicule_Typeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brandid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    modelid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fuel_typeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vehicule_brands_brandid",
                        column: x => x.brandid,
                        principalTable: "brands",
                        principalColumn: "id"
                        );
                    table.ForeignKey(
                        name: "FK_Vehicule_fuel_Types_fuel_typeId",
                        column: x => x.fuel_typeId,
                        principalTable: "fuel_Types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicule_vehicule_Types_vehicule_Typeid",
                        column: x => x.vehicule_Typeid,
                        principalTable: "vehicule_Types",
                        principalColumn: "id"
                     );
                    table.ForeignKey(
                        name: "FK_Vehicule_vehiculemodels_modelid",
                        column: x => x.modelid,
                        principalTable: "vehiculemodels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "inspections",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vehiculeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    scratch = table.Column<bool>(type: "bit", nullable: false),
                    amountOfFuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    replacementTire = table.Column<bool>(type: "bit", nullable: false),
                    jack = table.Column<bool>(type: "bit", nullable: false),
                    glassBreaked = table.Column<bool>(type: "bit", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employeeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspections", x => x.id);
                    table.ForeignKey(
                        name: "FK_inspections_clients_clientid",
                        column: x => x.clientid,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inspections_employees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inspections_Vehicule_vehiculeid",
                        column: x => x.vehiculeid,
                        principalTable: "Vehicule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rentAndReturns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Employeeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vehiculeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    returnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    costPerDay = table.Column<double>(type: "float", nullable: false),
                    rentDays = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentAndReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rentAndReturns_clients_clientid",
                        column: x => x.clientid,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rentAndReturns_employees_Employeeid",
                        column: x => x.Employeeid,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rentAndReturns_Vehicule_Vehiculeid",
                        column: x => x.Vehiculeid,
                        principalTable: "Vehicule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inspections_clientid",
                table: "inspections",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_inspections_employeeid",
                table: "inspections",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_inspections_vehiculeid",
                table: "inspections",
                column: "vehiculeid");

            migrationBuilder.CreateIndex(
                name: "IX_rentAndReturns_clientid",
                table: "rentAndReturns",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_rentAndReturns_Employeeid",
                table: "rentAndReturns",
                column: "Employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_rentAndReturns_Vehiculeid",
                table: "rentAndReturns",
                column: "Vehiculeid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_brandid",
                table: "Vehicule",
                column: "brandid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_fuel_typeId",
                table: "Vehicule",
                column: "fuel_typeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_modelid",
                table: "Vehicule",
                column: "modelid");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_vehicule_Typeid",
                table: "Vehicule",
                column: "vehicule_Typeid");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculemodels_brandid",
                table: "vehiculemodels",
                column: "brandid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inspections");

            migrationBuilder.DropTable(
                name: "rentAndReturns");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "Vehicule");

            migrationBuilder.DropTable(
                name: "fuel_Types");

            migrationBuilder.DropTable(
                name: "vehicule_Types");

            migrationBuilder.DropTable(
                name: "vehiculemodels");

            migrationBuilder.DropTable(
                name: "brands");
        }
    }
}
