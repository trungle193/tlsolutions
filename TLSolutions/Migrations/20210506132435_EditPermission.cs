using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLSolutions.Migrations
{
    public partial class EditPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: "role.create");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: "role.delete");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: "role.edit");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: "role.view");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: "user.create");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: "user.delete");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: "user.edit");

            migrationBuilder.DeleteData(
                table: "PermissionClaim",
                keyColumn: "Id",
                keyValue: "user.view");

            //migrationBuilder.DeleteData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6d65ac73-2205-4c21-b494-60f7e9e61f2b"));

            //migrationBuilder.DeleteData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c46641c9-279f-4ad9-8690-3b6632cd1fd6"));

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { new Guid("6b18f75c-e8e5-45ad-919a-d96244d5df60"), "bf9d7a8f-f918-4d02-8c86-645bbe234021", "Admin", "Admin" });

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { new Guid("fad30797-4e8f-4c7b-acae-c1f79e52fbf9"), "563eef25-51c3-4f4b-9e6e-fb83315f7af3", "Manager", "Manager" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6b18f75c-e8e5-45ad-919a-d96244d5df60"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fad30797-4e8f-4c7b-acae-c1f79e52fbf9"));

            migrationBuilder.InsertData(
                table: "PermissionClaim",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "role.view", "Danh sách nhóm quyền" },
                    { "role.create", "Tạo nhóm quyền" },
                    { "role.edit", "Sửa nhóm quyền" },
                    { "role.delete", "Xoá nhóm quyền" },
                    { "user.view", "Xem người dùng" },
                    { "user.create", "Tạo người dùng" },
                    { "user.edit", "Sửa người dùng" },
                    { "user.delete", "Xoá người dùng" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6d65ac73-2205-4c21-b494-60f7e9e61f2b"), "858cd801-a63a-4962-8609-60d81ffe1f10", "Admin", "Admin" },
                    { new Guid("c46641c9-279f-4ad9-8690-3b6632cd1fd6"), "1369e6cd-f501-4be4-b140-2d5b359bcf87", "Manager", "Manager" }
                });
        }
    }
}
