﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lialikLartisana.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderProductId",
                table: "Products",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProducts_OrderProductId",
                table: "Products",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProducts_OrderProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
