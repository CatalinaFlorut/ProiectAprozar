using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectAprozar.Migrations
{
    public partial class FructData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FructDataID",
                table: "FructCategorie",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FructDataID",
                table: "Fruct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FructDataID",
                table: "Categorie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FructData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FructData", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FructCategorie_FructDataID",
                table: "FructCategorie",
                column: "FructDataID");

            migrationBuilder.CreateIndex(
                name: "IX_Fruct_FructDataID",
                table: "Fruct",
                column: "FructDataID");

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_FructDataID",
                table: "Categorie",
                column: "FructDataID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorie_FructData_FructDataID",
                table: "Categorie",
                column: "FructDataID",
                principalTable: "FructData",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fruct_FructData_FructDataID",
                table: "Fruct",
                column: "FructDataID",
                principalTable: "FructData",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FructCategorie_FructData_FructDataID",
                table: "FructCategorie",
                column: "FructDataID",
                principalTable: "FructData",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorie_FructData_FructDataID",
                table: "Categorie");

            migrationBuilder.DropForeignKey(
                name: "FK_Fruct_FructData_FructDataID",
                table: "Fruct");

            migrationBuilder.DropForeignKey(
                name: "FK_FructCategorie_FructData_FructDataID",
                table: "FructCategorie");

            migrationBuilder.DropTable(
                name: "FructData");

            migrationBuilder.DropIndex(
                name: "IX_FructCategorie_FructDataID",
                table: "FructCategorie");

            migrationBuilder.DropIndex(
                name: "IX_Fruct_FructDataID",
                table: "Fruct");

            migrationBuilder.DropIndex(
                name: "IX_Categorie_FructDataID",
                table: "Categorie");

            migrationBuilder.DropColumn(
                name: "FructDataID",
                table: "FructCategorie");

            migrationBuilder.DropColumn(
                name: "FructDataID",
                table: "Fruct");

            migrationBuilder.DropColumn(
                name: "FructDataID",
                table: "Categorie");
        }
    }
}
