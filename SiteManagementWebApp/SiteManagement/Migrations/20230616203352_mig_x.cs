using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagement.Migrations
{
    public partial class mig_x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sites_DistrictId",
                table: "Sites");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_DistrictId",
                table: "Sites",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sites_DistrictId",
                table: "Sites");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_DistrictId",
                table: "Sites",
                column: "DistrictId",
                unique: true);
        }
    }
}
