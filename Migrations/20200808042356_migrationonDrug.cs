using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrugVerizone.Migrations
{
    public partial class migrationonDrug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DrugTypeId",
                table: "Drugs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_DrugTypeId",
                table: "Drugs",
                column: "DrugTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_DrugType_DrugTypeId",
                table: "Drugs",
                column: "DrugTypeId",
                principalTable: "DrugType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_DrugType_DrugTypeId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_DrugTypeId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "DrugTypeId",
                table: "Drugs");
        }
    }
}
