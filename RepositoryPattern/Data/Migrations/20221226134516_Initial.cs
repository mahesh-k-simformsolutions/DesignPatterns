﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryPattern.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Categories", x => x.Category_PK);
                });

            _ = migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<float>(type: "real", nullable: true),
                    Category_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Products", x => x.Product_PK);
                    _ = table.ForeignKey(
                        name: "FK_Products_Categories_Category_FK",
                        column: x => x.Category_FK,
                        principalTable: "Categories",
                        principalColumn: "Category_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_Products_Category_FK",
                table: "Products",
                column: "Category_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "Products");

            _ = migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
