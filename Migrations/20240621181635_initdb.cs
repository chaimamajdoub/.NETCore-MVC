using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP11Core.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "souscategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_souscategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_souscategories_categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SousCategorieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.ProduitId);
                    table.ForeignKey(
                        name: "FK_Produits_souscategories_SousCategorieId",
                        column: x => x.SousCategorieId,
                        principalTable: "souscategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategorieProduit",
                columns: table => new
                {
                    ProduitId = table.Column<int>(type: "int", nullable: false),
                    categoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieProduit", x => new { x.ProduitId, x.categoriesId });
                    table.ForeignKey(
                        name: "FK_CategorieProduit_categorie_categoriesId",
                        column: x => x.categoriesId,
                        principalTable: "categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieProduit_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieProduit_categoriesId",
                table: "CategorieProduit",
                column: "categoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_SousCategorieId",
                table: "Produits",
                column: "SousCategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_souscategories_CategorieId",
                table: "souscategories",
                column: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieProduit");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "souscategories");

            migrationBuilder.DropTable(
                name: "categorie");
        }
    }
}
