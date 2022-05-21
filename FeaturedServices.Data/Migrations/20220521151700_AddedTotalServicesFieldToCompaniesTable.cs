using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedTotalServicesFieldToCompaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "2e85a326-f8c8-445a-b9b2-78fe523b8d5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "1d8c8411-b603-40e4-8792-9b085bf4e06f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "633f9fa9-05b5-4916-ae74-3478363a1238");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "df36cd75-aeea-4760-ac5d-173a84ea6b2c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "273aa1b9-bccf-47e8-9153-6840759bcfe7", "AQAAAAEAACcQAAAAECOU6JKBdNzRLWs3ae9so+rPNwqQyN2M2cKarOQ8uxTLl8kNToz7qEkJ5edd8qHSdQ==", "1dea4877-3039-4ef6-a2be-9fcacf2456bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d194daf-ad05-4f5d-af3f-b611d1463ad1", "AQAAAAEAACcQAAAAEFqVNnmeSe6aJAKzuJGgYxi90RpTUw/uyJx9Mehe9xxh5/0XlEOe+RMIpGdf80Tjog==", "27ce7f85-6e97-4c30-8894-1497a27b8f69" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalServices",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "4eaa2847-ac10-4123-8680-0bd58d5daacd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "834c52d3-baec-47a9-adfc-6d0ed9b9ad6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "85c789c2-b344-40a1-ad11-94903ff6849e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "2e02fa77-8994-4c54-97ca-e6ebbe840388");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2280ef2f-5d4d-4196-bb3a-fe5573134e3e", "AQAAAAEAACcQAAAAEGgkYJw30MpvPOGAyB6xc21l2uPFPLlXvRkNPkDSbADCF/QzPD/NEvGsiqv3liwgXA==", "dfaf5e04-5438-48c6-9f64-633406b9f29e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e673e4bf-cedb-43ec-87b2-c1b3911595fc", "AQAAAAEAACcQAAAAEN3aqykYpPrHhLCXa+pD/Cy706OSf/KFu2styigpAXpMT4vvrFTqIRHDXGzZSUVEqA==", "5eb1f625-72a8-42d0-9396-56d428e2a49e" });
        }
    }
}
