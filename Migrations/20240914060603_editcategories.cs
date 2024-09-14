using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class editcategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIModelCategory_ModelCategories_CategoriesCategoryID",
                table: "AIModelCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelCategories",
                table: "ModelCategories");

            migrationBuilder.RenameTable(
                name: "ModelCategories",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_AIModelCategory_Categories_CategoriesCategoryID",
                table: "AIModelCategory",
                column: "CategoriesCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIModelCategory_Categories_CategoriesCategoryID",
                table: "AIModelCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "ModelCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelCategories",
                table: "ModelCategories",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_AIModelCategory_ModelCategories_CategoriesCategoryID",
                table: "AIModelCategory",
                column: "CategoriesCategoryID",
                principalTable: "ModelCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
