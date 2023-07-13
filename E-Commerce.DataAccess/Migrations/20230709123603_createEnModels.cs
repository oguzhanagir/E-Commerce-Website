using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class createEnModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryENId",
                table: "SubCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryENId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductENId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductENId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductENId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AboutENs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutENs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogENs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogENs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryENs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryENs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductENs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialProduct = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductENs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductENs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryENId",
                table: "SubCategory",
                column: "CategoryENId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryENId",
                table: "Products",
                column: "CategoryENId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductENId",
                table: "ProductImages",
                column: "ProductENId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductENId",
                table: "OrderItems",
                column: "ProductENId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductENId",
                table: "Comments",
                column: "ProductENId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductENs_CategoryId",
                table: "ProductENs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ProductENs_ProductENId",
                table: "Comments",
                column: "ProductENId",
                principalTable: "ProductENs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductENs_ProductENId",
                table: "OrderItems",
                column: "ProductENId",
                principalTable: "ProductENs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductENs_ProductENId",
                table: "ProductImages",
                column: "ProductENId",
                principalTable: "ProductENs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryENs_CategoryENId",
                table: "Products",
                column: "CategoryENId",
                principalTable: "CategoryENs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_CategoryENs_CategoryENId",
                table: "SubCategory",
                column: "CategoryENId",
                principalTable: "CategoryENs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ProductENs_ProductENId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductENs_ProductENId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductENs_ProductENId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryENs_CategoryENId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_CategoryENs_CategoryENId",
                table: "SubCategory");

            migrationBuilder.DropTable(
                name: "AboutENs");

            migrationBuilder.DropTable(
                name: "BlogENs");

            migrationBuilder.DropTable(
                name: "CategoryENs");

            migrationBuilder.DropTable(
                name: "ProductENs");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryENId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryENId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductENId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductENId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductENId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CategoryENId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryENId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductENId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductENId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductENId",
                table: "Comments");
        }
    }
}
