using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLSolutions.Migrations
{
    public partial class changenameuserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("42cc7191-44ec-4d7c-9eb4-e2e167d9ab73"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("591d8156-6627-453d-a490-5d4b4c3870ea"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("6f3d7262-ab10-46b4-b41a-413317765517"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("9240a56c-ab0b-41b6-afa5-df200e3bbf87"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("b49bee85-f6f7-4b2b-9e98-d0392fbce1d7"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("d0fa6b7c-6550-4de8-bd35-8a7b34c44a2a"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("d9159ca6-9841-42c0-8dec-e410f1c336ae"));

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: new Guid("f7a0972a-f584-4725-ad16-fb4173c35c1f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3f5772d8-beef-4fd4-9b2d-c1a0e616b37e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b4d77c69-5209-4163-96b4-15e84ff5a277"));

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

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
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_AppUserId",
                table: "UserRoles",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_AppUserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
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

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.InsertData(
                table: "PermissionClaim",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d0fa6b7c-6550-4de8-bd35-8a7b34c44a2a"), "role.view" },
                    { new Guid("f7a0972a-f584-4725-ad16-fb4173c35c1f"), "role.create" },
                    { new Guid("42cc7191-44ec-4d7c-9eb4-e2e167d9ab73"), "role.edit" },
                    { new Guid("9240a56c-ab0b-41b6-afa5-df200e3bbf87"), "role.delete" },
                    { new Guid("b49bee85-f6f7-4b2b-9e98-d0392fbce1d7"), "category.view" },
                    { new Guid("591d8156-6627-453d-a490-5d4b4c3870ea"), "category.create" },
                    { new Guid("6f3d7262-ab10-46b4-b41a-413317765517"), "category.edit" },
                    { new Guid("d9159ca6-9841-42c0-8dec-e410f1c336ae"), "category.delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3f5772d8-beef-4fd4-9b2d-c1a0e616b37e"), "8b573a33-cc9c-4dd3-aa62-a673cca16358", "Admin", null },
                    { new Guid("b4d77c69-5209-4163-96b4-15e84ff5a277"), "bbaf72c0-b057-4eb1-80a7-0e7f0ef96ab5", "Manager", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
