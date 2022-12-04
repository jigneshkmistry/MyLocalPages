using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLocalPages.Domain.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BusinessDirectories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("17e4e315-cdf5-436e-8851-f219f0f54081"), "Accommodation, Travel & Tours" });

            migrationBuilder.InsertData(
                table: "BusinessDirectories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("583c52b3-3238-4452-ab53-b1ab8edf0188"), "Animals & Pets" });

            migrationBuilder.InsertData(
                table: "BusinessDirectories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6e1c009f-8cea-4c0b-9db6-b109f1da2a58"), "Arts, Crafts & Collectables" });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "Name" },
                values: new object[] { new Guid("0ab4c79b-27f6-46f6-b07d-50491abaaa18"), new Guid("583c52b3-3238-4452-ab53-b1ab8edf0188"), "Aquaponics" });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "Name" },
                values: new object[] { new Guid("1ea72204-db2f-4f1d-addb-61337618d2b1"), new Guid("583c52b3-3238-4452-ab53-b1ab8edf0188"), "Animal Welfare" });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "Name" },
                values: new object[] { new Guid("28c751b1-87a7-4392-9bc9-a6d1e3935317"), new Guid("6e1c009f-8cea-4c0b-9db6-b109f1da2a58"), "Aboriginal Art & Crafts" });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "Name" },
                values: new object[] { new Guid("50ae7fcb-4aaa-4ed7-a74a-15ea9f0e8749"), new Guid("6e1c009f-8cea-4c0b-9db6-b109f1da2a58"), "Antiques Auctions & Dealers" });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "Name" },
                values: new object[] { new Guid("b80fed0e-db42-419d-9ef6-a7cfd0a07140"), new Guid("17e4e315-cdf5-436e-8851-f219f0f54081"), "Accommodation Booking & Inquiry Services" });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "Name" },
                values: new object[] { new Guid("caa52878-f8e7-451f-8d22-ebc8480906d3"), new Guid("17e4e315-cdf5-436e-8851-f219f0f54081"), "Adventure Tours & Holidays Packages" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("0ab4c79b-27f6-46f6-b07d-50491abaaa18"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("1ea72204-db2f-4f1d-addb-61337618d2b1"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("28c751b1-87a7-4392-9bc9-a6d1e3935317"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("50ae7fcb-4aaa-4ed7-a74a-15ea9f0e8749"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("b80fed0e-db42-419d-9ef6-a7cfd0a07140"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("caa52878-f8e7-451f-8d22-ebc8480906d3"));

            migrationBuilder.DeleteData(
                table: "BusinessDirectories",
                keyColumn: "Id",
                keyValue: new Guid("17e4e315-cdf5-436e-8851-f219f0f54081"));

            migrationBuilder.DeleteData(
                table: "BusinessDirectories",
                keyColumn: "Id",
                keyValue: new Guid("583c52b3-3238-4452-ab53-b1ab8edf0188"));

            migrationBuilder.DeleteData(
                table: "BusinessDirectories",
                keyColumn: "Id",
                keyValue: new Guid("6e1c009f-8cea-4c0b-9db6-b109f1da2a58"));
        }
    }
}
