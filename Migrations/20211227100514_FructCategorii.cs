using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectAprozar.Migrations
{
    public partial class FructCategorii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FructCategorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FructID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FructCategorie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FructCategorie_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FructCategorie_Fruct_FructID",
                        column: x => x.FructID,
                        principalTable: "Fruct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FructCategorie_CategorieID",
                table: "FructCategorie",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_FructCategorie_FructID",
                table: "FructCategorie",
                column: "FructID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FructCategorie");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
