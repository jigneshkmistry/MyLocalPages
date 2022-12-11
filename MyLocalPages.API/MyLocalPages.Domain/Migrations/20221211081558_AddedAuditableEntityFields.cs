using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLocalPages.Domain.Migrations
{
    public partial class AddedAuditableEntityFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DirectoryCategories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DirectoryCategories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DirectoryCategories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "DirectoryCategories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BusinessDirectories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "BusinessDirectories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BusinessDirectories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "BusinessDirectories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "BusinessDirectories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("6ef5c444-6098-4934-bb3a-360cdab46e15"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arts, Crafts & Collectables", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "BusinessDirectories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("d8c5947e-0e57-4d59-9f9a-3da64933ac27"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accommodation, Travel & Tours", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "BusinessDirectories",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("f0e1f767-f97b-434c-a59d-6b0b2f5c0563"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Animals & Pets", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("46b525d9-4e6e-4b27-969c-df6b4d58d50d"), new Guid("d8c5947e-0e57-4d59-9f9a-3da64933ac27"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accommodation Booking & Inquiry Services", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("5514e49b-43c9-4f23-887a-11ce99757fa0"), new Guid("f0e1f767-f97b-434c-a59d-6b0b2f5c0563"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aquaponics", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("a82053ec-ca1e-4220-ade5-f171658855da"), new Guid("6ef5c444-6098-4934-bb3a-360cdab46e15"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antiques Auctions & Dealers", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("ad211ec4-7867-41b5-a1c6-a262679be6a4"), new Guid("6ef5c444-6098-4934-bb3a-360cdab46e15"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aboriginal Art & Crafts", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("c3b8009b-5033-48ab-8a89-ecd3010b42d9"), new Guid("d8c5947e-0e57-4d59-9f9a-3da64933ac27"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adventure Tours & Holidays Packages", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "DirectoryCategories",
                columns: new[] { "Id", "BusinessDirectoryId", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("cea58b0e-98fd-4836-ad21-82a0f8405196"), new Guid("f0e1f767-f97b-434c-a59d-6b0b2f5c0563"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Animal Welfare", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("46b525d9-4e6e-4b27-969c-df6b4d58d50d"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("5514e49b-43c9-4f23-887a-11ce99757fa0"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("a82053ec-ca1e-4220-ade5-f171658855da"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("ad211ec4-7867-41b5-a1c6-a262679be6a4"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("c3b8009b-5033-48ab-8a89-ecd3010b42d9"));

            migrationBuilder.DeleteData(
                table: "DirectoryCategories",
                keyColumn: "Id",
                keyValue: new Guid("cea58b0e-98fd-4836-ad21-82a0f8405196"));

            migrationBuilder.DeleteData(
                table: "BusinessDirectories",
                keyColumn: "Id",
                keyValue: new Guid("6ef5c444-6098-4934-bb3a-360cdab46e15"));

            migrationBuilder.DeleteData(
                table: "BusinessDirectories",
                keyColumn: "Id",
                keyValue: new Guid("d8c5947e-0e57-4d59-9f9a-3da64933ac27"));

            migrationBuilder.DeleteData(
                table: "BusinessDirectories",
                keyColumn: "Id",
                keyValue: new Guid("f0e1f767-f97b-434c-a59d-6b0b2f5c0563"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DirectoryCategories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DirectoryCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DirectoryCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "DirectoryCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BusinessDirectories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BusinessDirectories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BusinessDirectories");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "BusinessDirectories");

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
    }
}
