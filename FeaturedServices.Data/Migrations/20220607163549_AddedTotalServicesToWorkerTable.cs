using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedTotalServicesToWorkerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalServices",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "04106f32-e577-43e4-a7df-e8dbfe177cf5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "262ad095-05de-4d44-b561-5d34f871fa60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "878abd9c-bb84-4f79-8cf1-6f7bac6920b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "1f11a5e3-c9e0-4cec-8905-bfa17b1f61c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be7f1bba-bb02-48cf-b86d-7287f8e661be", "AQAAAAEAACcQAAAAENr5vE+CF12f+peuD3DtxC1ofx7H+CMK74FcfuQtInv5OPUlGUrXrIj2c9D8eoahbA==", "754153e1-2a59-4a25-88ad-ab4b3238c74e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d66fa56b-f2e4-4a8b-a5c1-92d417b1b897", "AQAAAAEAACcQAAAAEIf80VSn+7VwFGix167W7hXrfBoAzO+eUZlJKE8w3hk8oxnaWkoE64v78dgrDKuqGw==", "185c80c5-4ead-422e-9228-bb467353b037" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalServices",
                table: "Workers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "415eaa81-2d77-4239-9c76-aea8d04ce623");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "58729659-453e-4b01-90c2-dbf114e1ebbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "2126364d-e5ab-4329-b9e9-3f115100d229");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "81100c04-f6b0-470d-9b49-44cf2282a0fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86a4bfaf-f836-4401-bec0-342ae6ea768a", "AQAAAAEAACcQAAAAEHRPxA9ZN0qUVuXFsSpIvF2EjPiv5/AzOihp4my8BPI326MjPKSCrjpoMb+PGbQQEA==", "10d24d3e-4a8d-46b2-98aa-b812c52d4354" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5948869d-8a80-4dd7-b905-0c1990b143db", "AQAAAAEAACcQAAAAEJUxJPLeeLK9538X8wuAspGPjFMPoO2APIFJvX/CVkLGUAaNQfKfGcbx/QcCF7VAXQ==", "8fc4a55f-ee13-49f2-a129-3374ba677199" });
        }
    }
}
