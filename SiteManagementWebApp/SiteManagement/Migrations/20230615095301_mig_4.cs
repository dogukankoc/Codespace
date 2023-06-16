using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagement.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HomeOwnerId",
                table: "Apartments",
                column: "HomeOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Humans_HomeOwnerId",
                table: "Apartments",
                column: "HomeOwnerId",
                principalTable: "Humans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Humans_HomeOwnerId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_HomeOwnerId",
                table: "Apartments");
        }
    }
}
