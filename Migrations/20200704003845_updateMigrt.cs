using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrugVerizone.Migrations
{
    public partial class updateMigrt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Manufacturers_manufacturerId",
                table: "Drugs");

            migrationBuilder.AlterColumn<Guid>(
                name: "manufacturerId",
                table: "Drugs",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "DrugCreateDto",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "manufacturerId",
                table: "DrugCreateDto",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Manufacturers_manufacturerId",
                table: "Drugs",
                column: "manufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Manufacturers_manufacturerId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "DrugCreateDto");

            migrationBuilder.DropColumn(
                name: "manufacturerId",
                table: "DrugCreateDto");

            migrationBuilder.AlterColumn<Guid>(
                name: "manufacturerId",
                table: "Drugs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Manufacturers_manufacturerId",
                table: "Drugs",
                column: "manufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
