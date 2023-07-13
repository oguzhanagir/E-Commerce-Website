using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class createdSubCategoryLangs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryARId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryENId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryRUId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubCategoryARs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryARs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoryARs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryENs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryENs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoryENs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryRUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryRUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoryRUs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryARId",
                table: "Products",
                column: "SubCategoryARId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryENId",
                table: "Products",
                column: "SubCategoryENId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryRUId",
                table: "Products",
                column: "SubCategoryRUId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryARs_CategoryId",
                table: "SubCategoryARs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryENs_CategoryId",
                table: "SubCategoryENs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryRUs_CategoryId",
                table: "SubCategoryRUs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategoryARs_SubCategoryARId",
                table: "Products",
                column: "SubCategoryARId",
                principalTable: "SubCategoryARs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategoryENs_SubCategoryENId",
                table: "Products",
                column: "SubCategoryENId",
                principalTable: "SubCategoryENs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategoryRUs_SubCategoryRUId",
                table: "Products",
                column: "SubCategoryRUId",
                principalTable: "SubCategoryRUs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategoryARs_SubCategoryARId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategoryENs_SubCategoryENId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategoryRUs_SubCategoryRUId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "SubCategoryARs");

            migrationBuilder.DropTable(
                name: "SubCategoryENs");

            migrationBuilder.DropTable(
                name: "SubCategoryRUs");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryARId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryENId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryRUId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryARId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryENId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryRUId",
                table: "Products");
        }
    }
}
