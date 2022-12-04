using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLocalPages.Domain.Migrations
{
    public partial class MyLocalPagesIntialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessDirectories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDirectories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectoryCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BusinessDirectoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectoryCategories_BusinessDirectories_BusinessDirectoryId",
                        column: x => x.BusinessDirectoryId,
                        principalTable: "BusinessDirectories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryCategories_BusinessDirectoryId",
                table: "DirectoryCategories",
                column: "BusinessDirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectoryCategories");

            migrationBuilder.DropTable(
                name: "BusinessDirectories");
        }
    }
}
