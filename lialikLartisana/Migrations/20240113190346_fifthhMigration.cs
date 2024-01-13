using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lialikLartisana.Migrations
{
    public partial class fifthhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProductsToBuyOrderProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductsToBuyOrderProductId",
                table: "Products",
                column: "ProductsToBuyOrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProducts_ProductsToBuyOrderProductId",
                table: "Products",
                column: "ProductsToBuyOrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProducts_ProductsToBuyOrderProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductsToBuyOrderProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsToBuyOrderProductId",
                table: "Products");

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
    }
}
