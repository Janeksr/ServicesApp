using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedValueColumnToServicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "5f1ee0af-6ac1-40c5-a28b-a8e8822c95d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "d8605f84-c431-4cce-8600-3deb7cbaf273");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "99bbfb2a-30d8-42b9-b2aa-f6eeaecfa8c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "0b668d76-ef73-422e-865f-964d40b0cf18");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dce50ef4-ba64-4eed-ae1e-80cd89b820be", "AQAAAAEAACcQAAAAEEPwripwULQcQ4jS/khQl239JQ6lQqZqBOeJP5T7QXoDATmXJTm023JAR45u14BK0g==", "78fde2d6-f549-4bec-b401-50590347aee4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f69c83e9-fa6b-4b8c-ad89-6015c248ca84", "AQAAAAEAACcQAAAAEDRRRDWqHACkmmJz4GvHqHf16a8FK21cyaF5S1PW3WJTnGsQQwyUJCXq4Oyipn5U4A==", "79cd8fef-beff-4956-8f73-d62878d39572" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "9725fe9f-c2a7-4fde-8e28-31cbaf7b6136");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "95e75bcc-2643-492e-9c40-77b7bf2c2fb8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "d078f6e4-8926-4659-8919-ad4805a0f012");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "1b82edbf-16ed-4ecc-9178-a0d514498cf1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96c8b493-1c65-40af-991e-5f7492c5b956", "AQAAAAEAACcQAAAAECQQKyLt3aqTG95BzW8j3GH9vfqH5jDawq83oVyP+Qpp9pZO9HqG/0p7+7eUNpVTCg==", "8810dabc-6bad-49cb-869d-8bc973296631" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70d398d1-4165-41e1-a025-2ab8e77c090d", "AQAAAAEAACcQAAAAEBi3Ma73a5y7Pf9yOQISuZd9giZwnpe2AZw961p03yZEyo+Q2CNDqWt6ESpiJetZMg==", "4cd8162b-8b07-4f97-a861-77556ff7578b" });
        }
    }
}
