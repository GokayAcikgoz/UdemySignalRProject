using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig_remove_fileamazon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FileAmazons_FileAmazonID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FileAmazons");

            migrationBuilder.DropIndex(
                name: "IX_Products_FileAmazonID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FileAmazonID",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileAmazonID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileAmazons",
                columns: table => new
                {
                    FileAmazonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAmazons", x => x.FileAmazonID);
                });

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
    }
}
