using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedCompanyToReservationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "fe970357-d2b7-498b-bf24-e31aa987e0a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "caa13f00-7cd8-48c4-9bed-a5a0cdef220f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "c4d504dd-ac0e-4544-869b-5a2a98ad45af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "f07a5bdc-231e-489a-b37b-10925acd2407");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "206cfd44-a684-44b2-ab3d-989a4a872ac1", "AQAAAAEAACcQAAAAELiaN7Qn7EUZwgrR0swjPljqUVCGTNCkLg3wbpwGiNtWLN1qq4ox1eiEe6Gcw3awMg==", "0be8cc73-82ae-483a-9a8b-5c83dc10eef4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "186349ee-98f7-4c0b-8f5a-033979c3974a", "AQAAAAEAACcQAAAAEL7D0/jkjjlQM7qVSXhQYySNv9LR1zmotihQrwAKRWQctKIt8mu8+xk7ON6vI3zxkw==", "5a62ebd6-48d7-4c2c-803f-7f5b0c5a3c6f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "d6bb4dfe-f861-40cc-8142-42ed6f3d9677");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "a64f178e-6a35-4df5-bf4e-5cc8c179421f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "46354b8c-0df6-49b4-b8a0-19a9ccb95912");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "40876bb4-d992-48ad-b040-ec4f66cd47e8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba54a198-cc97-44c5-9b07-5dafa09c2700", "AQAAAAEAACcQAAAAEJhndjxfFgHoNfaSQNdY8Ju26Hrnv0XRthZDbQgPShT//4AUekobq+dnphePV3yXrw==", "07af8029-db79-4b25-91ce-7e68d79f0f0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f92437ea-899d-4932-9841-f2c82384f159", "AQAAAAEAACcQAAAAEMvtY3O1I2f78xaFiLYnsDYTwjzG7zqZEsciLhoX0KCa97a/ed0kvgN45WlbMzRXeQ==", "9aa4d04e-ef36-4f8a-a665-4214a12abd04" });
        }
    }
}
