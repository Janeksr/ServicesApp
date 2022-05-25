using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedMainImageColumnToImageCompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MainImage",
                table: "ImageCompanies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "2ac3d8e6-fa33-45ba-b4e5-30dcad409914");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "bdd03bf7-3776-4ec3-9e4b-c89b0129d8be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "c3e4be34-7820-47f6-a1b2-8642be372da5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "c7e3a972-14ef-43ba-b60c-b86697af5958");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7672e791-875b-433c-93fa-e124ebde59d3", "AQAAAAEAACcQAAAAEHkqHQkFzKuXOgyfTwgBuWztpiux2IhTcMbDIdL6+9RcJWzWLcOiZaGd+Obg/e92LA==", "e132311c-aec1-4805-b3f9-5035be1bf51d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff4b73b0-3c8d-4eb6-a2cc-718a1204fd76", "AQAAAAEAACcQAAAAEElzoBo0TkXUAWG45IYCDjdOrNJjckD3eED4WgoygM9Ar/0Pw4285UsgUyaheHVkwg==", "c1b262d4-79e2-4086-b6f7-cca944afbb6e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "ImageCompanies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "8ac14b4c-00b9-49af-b439-c0fa6c8f5f04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "bb80895a-5b2d-4b62-b1c0-cf7b2f3fbced");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "75f1414f-9f1e-4086-81a0-dd029b555fb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "15f16b18-a7be-4031-b00a-dd3470c7e10e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1f1f403-635e-474f-8e2e-689a65f8dd9e", "AQAAAAEAACcQAAAAEHGDgRYbBlau0Crj7arRmWPCBrbnsdCy67YgokbCysP2n0E7CFJsfkVFjEBe+ke0ew==", "7fb79d9f-ff3e-4456-92ba-2b6041851162" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a96766e-ef97-4ca3-8461-a42ad483f0e6", "AQAAAAEAACcQAAAAEAZsxo6aRtyB+lOIbnHlX13S1u0PQcJ+BN6uf3wu4Y0dvNpRbJA32jz9DkAVgU18SQ==", "c37c9798-571e-4e01-8b39-be2c1db3f4c6" });
        }
    }
}
