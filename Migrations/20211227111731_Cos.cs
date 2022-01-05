using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectAprozar.Migrations
{
    public partial class Cos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FructID = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    Cantitate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cos_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cos_Fruct_FructID",
                        column: x => x.FructID,
                        principalTable: "Fruct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cos_ClientID",
                table: "Cos",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Cos_FructID",
                table: "Cos",
                column: "FructID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cos");
        }
    }
}
