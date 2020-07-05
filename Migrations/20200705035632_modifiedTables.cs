using Microsoft.EntityFrameworkCore.Migrations;

namespace DrugVerizone.Migrations
{
    public partial class modifiedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Manufacturers_manufacturerId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Manufacturers");

            migrationBuilder.RenameColumn(
                name: "manufacturerId",
                table: "Drugs",
                newName: "ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_manufacturerId",
                table: "Drugs",
                newName: "IX_Drugs_ManufacturerId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Manufacturers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Manufacturers_ManufacturerId",
                table: "Drugs",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Manufacturers_ManufacturerId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Manufacturers");

            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "Drugs",
                newName: "manufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Drugs_ManufacturerId",
                table: "Drugs",
                newName: "IX_Drugs_manufacturerId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Manufacturers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Manufacturers_manufacturerId",
                table: "Drugs",
                column: "manufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
