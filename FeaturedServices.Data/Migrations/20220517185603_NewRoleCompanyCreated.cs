using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class NewRoleCompanyCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "5f8e73f9-7eb1-437b-9d7b-a7240663ab49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "95b2f5e7-c5ac-41db-a1eb-be46dce2fd43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "16c8b19b-5802-440f-949d-8c4534a0072e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6261baec-128e-a0ab-ae32-164f20a1bced", "55cec046-0a1a-425a-a4b8-ac6c6c03cfea", "CompanyCreated", "COMPANYCREATED" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c358cf39-77a9-4759-bcf9-e6eec55c1b22", "AQAAAAEAACcQAAAAEDBYB/CHHr3xC9/3VmUMIj5a3zSFCLekpkPqGZh+1Wx8AQaNvLU1rgXBBXllY/z67w==", "36e763af-3967-42eb-8377-f8ded51e2811" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "175ac77b-246d-4cdb-b09d-79ad0f63f0b7", "AQAAAAEAACcQAAAAEJN6BYCTL60Vevc9Em6vRl+GVAA5gNdu43hK2WOA5wIOyTp4+B8RnCbLTovffBXgrQ==", "6735c04e-1fba-4862-bd87-95197b84e0f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "94a1d83c-d909-4b36-91d9-193de43442b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "8a5b37c9-d84d-43a8-a2df-f5baaff98b97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "878a5998-1ff4-4696-a037-c615637a2240");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c813141-c641-4a2e-9af3-d1d02d3d2941", "AQAAAAEAACcQAAAAEGwqWVhm8teZhvhKnI0deLPAgEBJ04UM+rZO4XXqdeAf2ONjQ0iR+3ClC/XULmVnhg==", "69b58eb7-f5a0-4196-a856-c50f0b782109" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07576f5c-dd4d-43d8-9018-d7da80502f7f", "AQAAAAEAACcQAAAAEGp1Su0JQ1egO/1mvDYyiCvcCbhzdTZJj22hl9FbsspQbYRk4qU41DoH12WqVRQaUA==", "e9cd4686-c4fc-4892-a903-b4b929684c17" });
        }
    }
}
