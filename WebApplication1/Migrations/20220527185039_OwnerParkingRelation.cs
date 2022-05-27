using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class OwnerParkingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "parkings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_parkings_OwnerId",
                table: "parkings",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_parkings_Owners_OwnerId",
                table: "parkings",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parkings_Owners_OwnerId",
                table: "parkings");

            migrationBuilder.DropIndex(
                name: "IX_parkings_OwnerId",
                table: "parkings");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "parkings");
        }
    }
}
