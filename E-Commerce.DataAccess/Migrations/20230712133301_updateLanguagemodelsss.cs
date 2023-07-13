using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class updateLanguagemodelsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_CategoryARs_CategoryARId",
                table: "SubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_CategoryENs_CategoryENId",
                table: "SubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_CategoryRUs_CategoryRUId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryARId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryENId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryRUId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryARId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryENId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryRUId",
                table: "SubCategory");

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
                name: "FK_SubCategoryARs_CategoryARs_CategoryARId",
                table: "SubCategoryARs",
                column: "CategoryARId",
                principalTable: "CategoryARs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryENs_CategoryENs_CategoryENId",
                table: "SubCategoryENs",
                column: "CategoryENId",
                principalTable: "CategoryENs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryRUs_CategoryRUs_CategoryRUId",
                table: "SubCategoryRUs",
                column: "CategoryRUId",
                principalTable: "CategoryRUs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryARs_CategoryARs_CategoryARId",
                table: "SubCategoryARs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryENs_CategoryENs_CategoryENId",
                table: "SubCategoryENs");

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

            migrationBuilder.AddColumn<int>(
                name: "CategoryARId",
                table: "SubCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryENId",
                table: "SubCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryRUId",
                table: "SubCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryARId",
                table: "SubCategory",
                column: "CategoryARId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryENId",
                table: "SubCategory",
                column: "CategoryENId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryRUId",
                table: "SubCategory",
                column: "CategoryRUId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_CategoryARs_CategoryARId",
                table: "SubCategory",
                column: "CategoryARId",
                principalTable: "CategoryARs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_CategoryENs_CategoryENId",
                table: "SubCategory",
                column: "CategoryENId",
                principalTable: "CategoryENs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_CategoryRUs_CategoryRUId",
                table: "SubCategory",
                column: "CategoryRUId",
                principalTable: "CategoryRUs",
                principalColumn: "Id");
        }
    }
}
