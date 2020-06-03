using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrugVerizone.Migrations
{
    public partial class secondDbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    certificateOfReg = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsSuperAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NafdacNo = table.Column<string>(nullable: true),
                    ManFactureDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    manufacturerId = table.Column<Guid>(nullable: true),
                    RegisteredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drugs_Manufacturers_manufacturerId",
                        column: x => x.manufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NafDac_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsInUse = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    verifyPin = table.Column<string>(nullable: true),
                    CreatedByNavigationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pins_Admins_CreatedByNavigationId",
                        column: x => x.CreatedByNavigationId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleId",
                table: "Admins",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_manufacturerId",
                table: "Drugs",
                column: "manufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pins_CreatedByNavigationId",
                table: "Pins",
                column: "CreatedByNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Pins");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
