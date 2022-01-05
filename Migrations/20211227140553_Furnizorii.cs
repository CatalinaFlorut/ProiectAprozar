using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectAprozar.Migrations
{
    public partial class Furnizorii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FurnizorID",
                table: "Fruct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fruct_FurnizorID",
                table: "Fruct",
                column: "FurnizorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruct_Furnizor_FurnizorID",
                table: "Fruct",
                column: "FurnizorID",
                principalTable: "Furnizor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruct_Furnizor_FurnizorID",
                table: "Fruct");

            migrationBuilder.DropIndex(
                name: "IX_Fruct_FurnizorID",
                table: "Fruct");

            migrationBuilder.DropColumn(
                name: "FurnizorID",
                table: "Fruct");
        }
    }
}
