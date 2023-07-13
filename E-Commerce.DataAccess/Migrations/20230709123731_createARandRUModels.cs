using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class createARandRUModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryARId",
                table: "SubCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryRUId",
                table: "SubCategory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryARId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryRUId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductARId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductRUId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductARId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductRUId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductARId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductRUId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AboutARs",
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
                    table.PrimaryKey("PK_AboutARs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutRUs",
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
                    table.PrimaryKey("PK_AboutRUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogARs",
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
                    table.PrimaryKey("PK_BlogARs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogRUs",
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
                    table.PrimaryKey("PK_BlogRUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryARs",
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
                    table.PrimaryKey("PK_CategoryARs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRUs",
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
                    table.PrimaryKey("PK_CategoryRUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductARs",
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
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductARs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductARs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductARs_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductRUs",
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
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRUs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRUs_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryARId",
                table: "SubCategory",
                column: "CategoryARId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryRUId",
                table: "SubCategory",
                column: "CategoryRUId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryARId",
                table: "Products",
                column: "CategoryARId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryRUId",
                table: "Products",
                column: "CategoryRUId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductARId",
                table: "ProductImages",
                column: "ProductARId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductRUId",
                table: "ProductImages",
                column: "ProductRUId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductARId",
                table: "OrderItems",
                column: "ProductARId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductRUId",
                table: "OrderItems",
                column: "ProductRUId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductARId",
                table: "Comments",
                column: "ProductARId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductRUId",
                table: "Comments",
                column: "ProductRUId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductARs_CategoryId",
                table: "ProductARs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductARs_SubCategoryId",
                table: "ProductARs",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRUs_CategoryId",
                table: "ProductRUs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRUs_SubCategoryId",
                table: "ProductRUs",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ProductARs_ProductARId",
                table: "Comments",
                column: "ProductARId",
                principalTable: "ProductARs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ProductRUs_ProductRUId",
                table: "Comments",
                column: "ProductRUId",
                principalTable: "ProductRUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductARs_ProductARId",
                table: "OrderItems",
                column: "ProductARId",
                principalTable: "ProductARs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductRUs_ProductRUId",
                table: "OrderItems",
                column: "ProductRUId",
                principalTable: "ProductRUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductARs_ProductARId",
                table: "ProductImages",
                column: "ProductARId",
                principalTable: "ProductARs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductRUs_ProductRUId",
                table: "ProductImages",
                column: "ProductRUId",
                principalTable: "ProductRUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryARs_CategoryARId",
                table: "Products",
                column: "CategoryARId",
                principalTable: "CategoryARs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryRUs_CategoryRUId",
                table: "Products",
                column: "CategoryRUId",
                principalTable: "CategoryRUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_CategoryARs_CategoryARId",
                table: "SubCategory",
                column: "CategoryARId",
                principalTable: "CategoryARs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_CategoryRUs_CategoryRUId",
                table: "SubCategory",
                column: "CategoryRUId",
                principalTable: "CategoryRUs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ProductARs_ProductARId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ProductRUs_ProductRUId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductARs_ProductARId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductRUs_ProductRUId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductARs_ProductARId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductRUs_ProductRUId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryARs_CategoryARId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryRUs_CategoryRUId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_CategoryARs_CategoryARId",
                table: "SubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_CategoryRUs_CategoryRUId",
                table: "SubCategory");

            migrationBuilder.DropTable(
                name: "AboutARs");

            migrationBuilder.DropTable(
                name: "AboutRUs");

            migrationBuilder.DropTable(
                name: "BlogARs");

            migrationBuilder.DropTable(
                name: "BlogRUs");

            migrationBuilder.DropTable(
                name: "CategoryARs");

            migrationBuilder.DropTable(
                name: "CategoryRUs");

            migrationBuilder.DropTable(
                name: "ProductARs");

            migrationBuilder.DropTable(
                name: "ProductRUs");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryARId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryRUId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryARId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryRUId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductARId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductRUId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductARId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductRUId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductARId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProductRUId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CategoryARId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryRUId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryARId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryRUId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductARId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductRUId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductARId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductRUId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductARId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProductRUId",
                table: "Comments");
        }
    }
}
