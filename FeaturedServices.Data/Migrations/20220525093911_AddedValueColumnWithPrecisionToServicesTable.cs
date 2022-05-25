using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedValueColumnWithPrecisionToServicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Services",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

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
    }
}
