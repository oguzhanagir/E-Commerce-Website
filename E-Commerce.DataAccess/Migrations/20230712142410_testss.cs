using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class testss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductARs_SubCategory_SubCategoryId",
                table: "ProductARs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductENs_SubCategory_SubCategoryId",
                table: "ProductENs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRUs_SubCategory_SubCategoryId",
                table: "ProductRUs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryARs_Categories_CategoryId",
                table: "SubCategoryARs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryARs_CategoryARs_CategoryARId",
                table: "SubCategoryARs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryENs_Categories_CategoryId",
                table: "SubCategoryENs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryENs_CategoryENs_CategoryENId",
                table: "SubCategoryENs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryRUs_Categories_CategoryId",
                table: "SubCategoryRUs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryRUs_CategoryRUs_CategoryRUId",
                table: "SubCategoryRUs");

            migrationBuilder.DropIndex(
                name: "IX_SubCategoryRUs_CategoryRUId",
                table: "SubCategoryRUs");

            migrationBuilder.DropIndex(
                name: "IX_SubCategoryENs_CategoryENId",
                table: "SubCategoryENs");

            migrationBuilder.DropIndex(
                name: "IX_SubCategoryARs_CategoryARId",
                table: "SubCategoryARs");

            migrationBuilder.DropColumn(
                name: "CategoryRUId",
                table: "SubCategoryRUs");

            migrationBuilder.DropColumn(
                name: "CategoryENId",
                table: "SubCategoryENs");

            migrationBuilder.DropColumn(
                name: "CategoryARId",
                table: "SubCategoryARs");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductARs_SubCategoryARs_SubCategoryId",
                table: "ProductARs",
                column: "SubCategoryId",
                principalTable: "SubCategoryARs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductENs_SubCategoryENs_SubCategoryId",
                table: "ProductENs",
                column: "SubCategoryId",
                principalTable: "SubCategoryENs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRUs_SubCategoryRUs_SubCategoryId",
                table: "ProductRUs",
                column: "SubCategoryId",
                principalTable: "SubCategoryRUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryARs_CategoryARs_CategoryId",
                table: "SubCategoryARs",
                column: "CategoryId",
                principalTable: "CategoryARs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryENs_CategoryENs_CategoryId",
                table: "SubCategoryENs",
                column: "CategoryId",
                principalTable: "CategoryENs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryRUs_CategoryRUs_CategoryId",
                table: "SubCategoryRUs",
                column: "CategoryId",
                principalTable: "CategoryRUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductARs_SubCategoryARs_SubCategoryId",
                table: "ProductARs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductENs_SubCategoryENs_SubCategoryId",
                table: "ProductENs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRUs_SubCategoryRUs_SubCategoryId",
                table: "ProductRUs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryARs_CategoryARs_CategoryId",
                table: "SubCategoryARs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryENs_CategoryENs_CategoryId",
                table: "SubCategoryENs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryRUs_CategoryRUs_CategoryId",
                table: "SubCategoryRUs");

            migrationBuilder.AddColumn<int>(
                name: "CategoryRUId",
                table: "SubCategoryRUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryENId",
                table: "SubCategoryENs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryARId",
                table: "SubCategoryARs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryRUs_CategoryRUId",
                table: "SubCategoryRUs",
                column: "CategoryRUId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryENs_CategoryENId",
                table: "SubCategoryENs",
                column: "CategoryENId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryARs_CategoryARId",
                table: "SubCategoryARs",
                column: "CategoryARId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductARs_SubCategory_SubCategoryId",
                table: "ProductARs",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductENs_SubCategory_SubCategoryId",
                table: "ProductENs",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRUs_SubCategory_SubCategoryId",
                table: "ProductRUs",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryARs_Categories_CategoryId",
                table: "SubCategoryARs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryARs_CategoryARs_CategoryARId",
                table: "SubCategoryARs",
                column: "CategoryARId",
                principalTable: "CategoryARs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryENs_Categories_CategoryId",
                table: "SubCategoryENs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryENs_CategoryENs_CategoryENId",
                table: "SubCategoryENs",
                column: "CategoryENId",
                principalTable: "CategoryENs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryRUs_Categories_CategoryId",
                table: "SubCategoryRUs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryRUs_CategoryRUs_CategoryRUId",
                table: "SubCategoryRUs",
                column: "CategoryRUId",
                principalTable: "CategoryRUs",
                principalColumn: "Id");
        }
    }
}
