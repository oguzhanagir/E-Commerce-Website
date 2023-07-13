using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class createARandRUModelsas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "ProductENs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductENs_SubCategoryId",
                table: "ProductENs",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductENs_SubCategory_SubCategoryId",
                table: "ProductENs",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductENs_SubCategory_SubCategoryId",
                table: "ProductENs");

            migrationBuilder.DropIndex(
                name: "IX_ProductENs_SubCategoryId",
                table: "ProductENs");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "ProductENs");
        }
    }
}
