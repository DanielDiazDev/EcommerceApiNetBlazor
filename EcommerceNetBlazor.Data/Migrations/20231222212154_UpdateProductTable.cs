using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceNetBlazor.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriaId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Products",
                newName: "CategoriyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoriaId",
                table: "Products",
                newName: "IX_Products_CategoriyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriyId",
                table: "Products",
                column: "CategoriyId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriyId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoriyId",
                table: "Products",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoriyId",
                table: "Products",
                newName: "IX_Products_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriaId",
                table: "Products",
                column: "CategoriaId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
