using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class RemovedAddressFromCompaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Companies");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "55b86690-b84f-4db5-b3e0-9c3e4bdc96b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "9e5e2b0c-f3a7-4bcb-80a9-9a7a681cdda4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "99e20245-b43f-49a1-be89-f5077b8851d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4096db6-df4a-43ab-ac98-6bae19d1be1a", "AQAAAAEAACcQAAAAELH+ST8HTFIhvMoXXf5NDlBfIJQYxc+VAMrbyLzsNMqLiglx+HOGg8zRvJXIP1ciuA==", "90dfc3a5-602a-445e-b7c2-8ebbf98c7963" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0628c1db-f665-4660-91e5-946ae0647fc5", "AQAAAAEAACcQAAAAEGVkwSx/8U2xsL7eS+1MoFTeT4vOV4Hyy4UUaQGHz+kgO9g8Ug1R6Jar9uXBwB1H3Q==", "ce1e413c-ca9d-4e39-bcd1-410bd458f8f1" });
        }
    }
}
