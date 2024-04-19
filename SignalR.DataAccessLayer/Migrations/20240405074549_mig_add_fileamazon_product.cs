using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig_add_fileamazon_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileAmazonID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FileAmazonID",
                table: "Products",
                column: "FileAmazonID",
                unique: true,
                filter: "[FileAmazonID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FileAmazons_FileAmazonID",
                table: "Products",
                column: "FileAmazonID",
                principalTable: "FileAmazons",
                principalColumn: "FileAmazonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FileAmazons_FileAmazonID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FileAmazonID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FileAmazonID",
                table: "Products");
        }
    }
}
