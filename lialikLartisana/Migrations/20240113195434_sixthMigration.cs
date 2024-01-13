using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lialikLartisana.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProducts_ProductsToBuyOrderProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsShipped",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductsToBuyOrderProductId",
                table: "Products",
                newName: "OrderProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductsToBuyOrderProductId",
                table: "Products",
                newName: "IX_Products_OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProducts_OrderProductId",
                table: "Products",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProducts_OrderProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OrderProductId",
                table: "Products",
                newName: "ProductsToBuyOrderProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OrderProductId",
                table: "Products",
                newName: "IX_Products_ProductsToBuyOrderProductId");

            migrationBuilder.AddColumn<bool>(
                name: "IsShipped",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProducts_ProductsToBuyOrderProductId",
                table: "Products",
                column: "ProductsToBuyOrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderProductId");
        }
    }
}
