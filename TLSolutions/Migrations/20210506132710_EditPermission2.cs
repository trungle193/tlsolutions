using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLSolutions.Migrations
{
    public partial class EditPermission2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6b18f75c-e8e5-45ad-919a-d96244d5df60"));

            //migrationBuilder.DeleteData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: new Guid("fad30797-4e8f-4c7b-acae-c1f79e52fbf9"));

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

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { new Guid("27344af3-3221-4535-9648-34531539f1e0"), "9375682a-64bc-4f89-bf04-d277afd84723", "Admin", "Admin" },
            //        { new Guid("6e319b5d-7209-4de3-a9da-621d93250f15"), "5f6038a2-c3fd-4826-a125-48676dc0a7f7", "Manager", "Manager" }
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("27344af3-3221-4535-9648-34531539f1e0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6e319b5d-7209-4de3-a9da-621d93250f15"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6b18f75c-e8e5-45ad-919a-d96244d5df60"), "bf9d7a8f-f918-4d02-8c86-645bbe234021", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("fad30797-4e8f-4c7b-acae-c1f79e52fbf9"), "563eef25-51c3-4f4b-9e6e-fb83315f7af3", "Manager", "Manager" });
        }
    }
}
