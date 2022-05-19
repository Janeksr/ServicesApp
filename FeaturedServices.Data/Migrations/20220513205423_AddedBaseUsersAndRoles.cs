using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedBaseUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f6121ad-b6be-49ff-9d02-6c442008ace4", "f54285ee-4377-4248-86bb-9ceff7b8290f", "Administrator", "ADMINISTRATOR" },
                    { "0f61aaac-b21e-a9ff-9e02-64432001abe4", "0f36c088-3a2d-4b59-8c9e-1d74cafd7f21", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "408121ad-b63e-49ff-1d02-6c221af8ace4", 0, "52ccc145-0b30-4dce-be93-965ca142dd15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", true, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEGVOVEkTS0wKhxXLIZMG6j+sJrHQNqwOmc3psjU2XKe65j6wBY0buh2CXaYEU04o7w==", null, false, "ead06f35-d7b9-4183-8693-c9118d7ee3a6", false, "admin@localhost.com" },
                    { "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4", 0, "c50dc287-07f6-49be-b0e5-4567d2db5113", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", true, "System", "User", false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEF9U968JgWSYtJz0zBWEcznLUKdKQggk78NN7FtKz72mHOUPHmEfrffTcKhUFoUsPw==", null, false, "103d17f8-e62d-4788-9f5d-5210b5f96bf1", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0f6121ad-b6be-49ff-9d02-6c442008ace4", "408121ad-b63e-49ff-1d02-6c221af8ace4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0f61aaac-b21e-a9ff-9e02-64432001abe4", "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f6121ad-b6be-49ff-9d02-6c442008ace4", "408121ad-b63e-49ff-1d02-6c221af8ace4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0f61aaac-b21e-a9ff-9e02-64432001abe4", "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4");
        }
    }
}
