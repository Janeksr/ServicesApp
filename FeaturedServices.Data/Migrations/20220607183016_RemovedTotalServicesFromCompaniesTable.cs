using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class RemovedTotalServicesFromCompaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalServices",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "9d1c3b29-19a8-4779-aa1a-3e9067ae133d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "9d9ec500-5afa-47c5-80c7-f4bbcfa729dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "d5e1a41b-90e3-40b9-9af6-9d96e970f181");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "2703ffd5-e679-47bf-aa2e-79bcf3aeb965");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "005da9e1-47d9-41db-81d1-0be36402f9ca", "AQAAAAEAACcQAAAAECpPi1Skbollq4COlmmNc6KHpmdL1H/CzpP82sUk//L9dxKN+B8wT99Bc0A4++Luig==", "71dcacd5-35f4-451d-803a-810acbad4f69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1d88647-7bb6-4ca1-9f29-8f7fb8d26a62", "AQAAAAEAACcQAAAAEHt9e0SfsFHJ3Th6MM208H+uk27iQaFXbvc8GZoG+foc+WR4j90zH9TXYS5r4eOvIQ==", "1b4edb75-160b-440d-b300-fb032adb51b6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalServices",
                table: "Companies",
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
    }
}
