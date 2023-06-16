using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagement.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sites_ManagerHumanId",
                table: "Sites",
                column: "ManagerHumanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Humans_ManagerHumanId",
                table: "Sites",
                column: "ManagerHumanId",
                principalTable: "Humans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Humans_ManagerHumanId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Sites_ManagerHumanId",
                table: "Sites");
        }
    }
}
