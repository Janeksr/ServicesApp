using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "5ca21f93-bd22-46e5-bbee-a1b41b1f3f01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "7e5caf27-0e65-4acd-bde4-0522e6ffe544");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "92acf397-9a52-4293-ae2d-2acbc6d307c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "8554032f-2eef-4a98-bd08-75f691e78880");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7d2aabc-40b6-4053-b6f3-6a584b15b9bd", "AQAAAAEAACcQAAAAENUCrIh7dY2knRzqK79r/GsCy0UdyhDsro5u6EMd0E5Q+JgjoeK+D/nuqL31g0iTmw==", "e65dbcb6-f6d7-4bf2-a6df-247cc6d68289" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c01384ce-c130-4f3a-92f1-0e9892b8f7a3", "AQAAAAEAACcQAAAAENrOEp7l3vqHGwfTPecJiQTAOkDKe25jI19rFEykKp8Z4FESfEpyWfbREve5ECVbfQ==", "15633c16-d6e4-493b-9009-c2fd7619935b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "d0645feb-e8e2-4546-b1bc-46deb2be27e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "3818125b-9a26-45f1-b249-d4be4fc36551");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "0d9bd711-e112-411e-aed3-567541a2097e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "0b63b63c-0421-4524-897b-48f8581a4b90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79de92a0-27f1-40d1-b067-36dfcfd121ac", "AQAAAAEAACcQAAAAEAI5yOwf4HEKLIHUWvF3s7zBQhUhDSOTkQmQnF10bBhQYj2TEs7J8gKP/dR0wqHx4w==", "d41f7546-3130-4bd6-9a68-37ae938fef2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea71887b-aa8d-42b7-b13d-91b5cebfea61", "AQAAAAEAACcQAAAAEJqwhmgfFOGESXeS73plQaxQ526lglVnwKE8hxrnls12N6EIgq0A0cVw36ySF70QFQ==", "d8619ccf-8bf8-41fd-a060-5992ef34f65f" });
        }
    }
}
