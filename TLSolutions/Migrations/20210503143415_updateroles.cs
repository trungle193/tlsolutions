using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLSolutions.Migrations
{
    public partial class updateroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_AppUserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_AppUserId",
                table: "UserRoles");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("07277cb6-aa72-4cd6-b9b2-05235043bef4"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("08cfa1fb-d20c-437b-94ff-eeaaac5e92c1"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("1a03ffce-36b2-47ac-90e0-390876eac731"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("212bcb60-2378-4768-9b7a-52d0c1bd65c4"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("4e567353-1c3d-456e-9319-e0aba3e355b9"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("52dce99d-0c14-487e-abb4-8183f7c71d8a"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("7b007393-6285-4191-b952-403d35e6d6d2"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("d312390f-0c4b-455e-a6c2-256c5ea38133"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c168a1b8-a56b-409d-ad85-b4427e7347c8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cda46e4f-ce81-4ef9-b509-183eefa17f0e"));

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserRoles");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "PermissionClaim",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("212bcb60-2378-4768-9b7a-52d0c1bd65c4"), "role.view" },
                    { new Guid("d312390f-0c4b-455e-a6c2-256c5ea38133"), "role.create" },
                    { new Guid("4e567353-1c3d-456e-9319-e0aba3e355b9"), "role.edit" },
                    { new Guid("08cfa1fb-d20c-437b-94ff-eeaaac5e92c1"), "role.delete" },
                    { new Guid("07277cb6-aa72-4cd6-b9b2-05235043bef4"), "category.view" },
                    { new Guid("1a03ffce-36b2-47ac-90e0-390876eac731"), "category.create" },
                    { new Guid("52dce99d-0c14-487e-abb4-8183f7c71d8a"), "category.edit" },
                    { new Guid("7b007393-6285-4191-b952-403d35e6d6d2"), "category.delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c168a1b8-a56b-409d-ad85-b4427e7347c8"), "06023da8-b143-4635-819d-3670022fc666", "Admin", null },
                    { new Guid("cda46e4f-ce81-4ef9-b509-183eefa17f0e"), "ba86a1fa-aa09-408d-81e0-07b065f8081b", "Manager", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_AppUserId",
                table: "UserRoles",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_AppUserId",
                table: "UserRoles",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
