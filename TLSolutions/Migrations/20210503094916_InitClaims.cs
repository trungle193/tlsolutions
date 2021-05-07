using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLSolutions.Migrations
{
    public partial class InitClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77386af0-f76d-4cd8-bd01-fc118b5ed493"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bf22c5e8-10f3-460e-8bff-e11b5d066b26"));

            migrationBuilder.CreateTable(
                name: "PermissionClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionClaim", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PermissionClaim_Name",
                table: "PermissionClaim",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionClaim");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3f5772d8-beef-4fd4-9b2d-c1a0e616b37e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b4d77c69-5209-4163-96b4-15e84ff5a277"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("77386af0-f76d-4cd8-bd01-fc118b5ed493"), "a34e8766-11db-459b-9b72-57a2aa60b173", "Admin", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("bf22c5e8-10f3-460e-8bff-e11b5d066b26"), "69fdcd8c-dd21-4fa1-ab05-b614e6c8c560", "Manager", null });
        }
    }
}
