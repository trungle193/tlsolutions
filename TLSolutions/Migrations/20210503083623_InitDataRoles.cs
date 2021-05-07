using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLSolutions.Migrations
{
    public partial class InitDataRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("77386af0-f76d-4cd8-bd01-fc118b5ed493"), "a34e8766-11db-459b-9b72-57a2aa60b173", "Admin", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("bf22c5e8-10f3-460e-8bff-e11b5d066b26"), "69fdcd8c-dd21-4fa1-ab05-b614e6c8c560", "Manager", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77386af0-f76d-4cd8-bd01-fc118b5ed493"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bf22c5e8-10f3-460e-8bff-e11b5d066b26"));
        }
    }
}
