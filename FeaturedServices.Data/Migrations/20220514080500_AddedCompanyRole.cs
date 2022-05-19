using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedCompanyRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "30b47ed9-b984-46b2-b5de-e7dfbf9dcc40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "b7bc80b9-2168-4b01-bc14-bfe5fb680203");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "626a4a0c-b21e-a9ab-9e32-144f20a1bced", "86fb1a9b-c388-46b7-b43f-3089f991086b", "Company", "COMPANY" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bb9036d-c9f7-40fe-9bb7-f0654b9fcf14", "AQAAAAEAACcQAAAAEFUxPwRIqIoJhY/4ZsqZ0BVerUNK87EwMJ9ZsLTYqVSJa9nNRnnqwQudx+oYhso/1Q==", "10e5b7ba-de75-4633-bda4-ed9b672b2f7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95651877-87df-49d7-8976-40d42889c854", "AQAAAAEAACcQAAAAEHc3EEix9t8NfJ2Df6AWJDxYjL0ps6jFMPbBYF+xiUzy654X+EEiAfqTZIcugU7TCg==", "94c4d2e5-18b9-44bb-8548-9b290493bc7e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "f54285ee-4377-4248-86bb-9ceff7b8290f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "0f36c088-3a2d-4b59-8c9e-1d74cafd7f21");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52ccc145-0b30-4dce-be93-965ca142dd15", "AQAAAAEAACcQAAAAEGVOVEkTS0wKhxXLIZMG6j+sJrHQNqwOmc3psjU2XKe65j6wBY0buh2CXaYEU04o7w==", "ead06f35-d7b9-4183-8693-c9118d7ee3a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c50dc287-07f6-49be-b0e5-4567d2db5113", "AQAAAAEAACcQAAAAEF9U968JgWSYtJz0zBWEcznLUKdKQggk78NN7FtKz72mHOUPHmEfrffTcKhUFoUsPw==", "103d17f8-e62d-4788-9f5d-5210b5f96bf1" });
        }
    }
}
