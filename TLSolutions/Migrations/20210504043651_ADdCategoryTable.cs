using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLSolutions.Migrations
{
    public partial class ADdCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("01107254-7756-4a80-a490-bb6bb1005409"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("0155da14-bc69-42a6-b126-60694e9f6f38"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("3a587687-3cb3-4e31-a721-eb9699126756"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("43791db7-3497-42d4-af0d-953414d1f1cb"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("782987b9-1f47-4c17-8658-50b280c3240e"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("de885ab9-739f-47ad-adae-05123c2c3b96"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("eb1bd8e3-fa51-4d15-a513-20c2555aed2c"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("fed99d98-7467-4390-a902-957e6d8910b8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("01bf8310-927d-4557-95a3-5b909077a0e4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("058a88ea-2418-48c0-ae49-4e3f0e06fed7"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PermissionClaim",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ceeaff61-0804-4c3a-ae1b-5de7d274bfde"), "role.view" },
                    { new Guid("023c0f93-7d04-4e4f-bd08-b779185c76ac"), "role.create" },
                    { new Guid("e3302cf8-a1d1-4bb0-8def-5badf4be05a7"), "role.edit" },
                    { new Guid("86ac1fda-b9d4-49fa-a356-ee8155fd2ee3"), "role.delete" },
                    { new Guid("32ad100b-3e32-4a0c-959c-a8c8117d1a8c"), "category.view" },
                    { new Guid("5d228319-142b-4c3e-85d1-6b4a55cb90b9"), "category.create" },
                    { new Guid("fb5e8443-2660-4fd4-861b-e75cfe5ef5c2"), "category.edit" },
                    { new Guid("e82388ee-5d88-4399-8f32-5530618226aa"), "category.delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c849d697-e5a3-4e4b-99b4-b2af8e44afdc"), "de396ddf-cc7c-440b-b324-c8508d551226", "Admin", null },
                    { new Guid("703cf446-4b9f-4f46-a7cb-db909a5ea4e5"), "fed3d754-eaaa-4734-b310-18b9d313d4d3", "Manager", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("023c0f93-7d04-4e4f-bd08-b779185c76ac"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("32ad100b-3e32-4a0c-959c-a8c8117d1a8c"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("5d228319-142b-4c3e-85d1-6b4a55cb90b9"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("86ac1fda-b9d4-49fa-a356-ee8155fd2ee3"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("ceeaff61-0804-4c3a-ae1b-5de7d274bfde"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("e3302cf8-a1d1-4bb0-8def-5badf4be05a7"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("e82388ee-5d88-4399-8f32-5530618226aa"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("fb5e8443-2660-4fd4-861b-e75cfe5ef5c2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("703cf446-4b9f-4f46-a7cb-db909a5ea4e5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c849d697-e5a3-4e4b-99b4-b2af8e44afdc"));

            migrationBuilder.InsertData(
                table: "PermissionClaim",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("43791db7-3497-42d4-af0d-953414d1f1cb"), "role.view" },
                    { new Guid("de885ab9-739f-47ad-adae-05123c2c3b96"), "role.create" },
                    { new Guid("3a587687-3cb3-4e31-a721-eb9699126756"), "role.edit" },
                    { new Guid("eb1bd8e3-fa51-4d15-a513-20c2555aed2c"), "role.delete" },
                    { new Guid("0155da14-bc69-42a6-b126-60694e9f6f38"), "category.view" },
                    { new Guid("01107254-7756-4a80-a490-bb6bb1005409"), "category.create" },
                    { new Guid("782987b9-1f47-4c17-8658-50b280c3240e"), "category.edit" },
                    { new Guid("fed99d98-7467-4390-a902-957e6d8910b8"), "category.delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01bf8310-927d-4557-95a3-5b909077a0e4"), "de5c59e1-cfb6-42f4-bce4-2ecaaf083329", "Admin", null },
                    { new Guid("058a88ea-2418-48c0-ae49-4e3f0e06fed7"), "622fb5ce-3e66-4036-8b33-364e8f8f6876", "Manager", null }
                });
        }
    }
}
