using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagement.Migrations
{
    public partial class AddedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DistrcitId",
                table: "Sites",
                newName: "ManagerHumanId");

            migrationBuilder.AddColumn<int>(
                name: "DistrcitIdId",
                table: "Sites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApartmentDepts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    ElectricityDebt = table.Column<float>(type: "real", nullable: false),
                    GasDebt = table.Column<float>(type: "real", nullable: false),
                    WaterDept = table.Column<float>(type: "real", nullable: false),
                    DeptDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentDepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentDepts_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humans_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sites_DistrcitIdId",
                table: "Sites",
                column: "DistrcitIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_SiteId",
                table: "Blocks",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_BlockId",
                table: "Apartments",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentDepts_ApartmentId",
                table: "ApartmentDepts",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Humans_ApartmentId",
                table: "Humans",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_SiteId",
                table: "Workers",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Blocks_BlockId",
                table: "Apartments",
                column: "BlockId",
                principalTable: "Blocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Sites_SiteId",
                table: "Blocks",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Districts_DistrcitIdId",
                table: "Sites",
                column: "DistrcitIdId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Blocks_BlockId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Sites_SiteId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Districts_DistrcitIdId",
                table: "Sites");

            migrationBuilder.DropTable(
                name: "ApartmentDepts");

            migrationBuilder.DropTable(
                name: "Humans");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Sites_DistrcitIdId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_SiteId",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_BlockId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "DistrcitIdId",
                table: "Sites");

            migrationBuilder.RenameColumn(
                name: "ManagerHumanId",
                table: "Sites",
                newName: "DistrcitId");
        }
    }
}
