using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class CompanyServiceRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "0babe25c-43d8-4810-a116-cd773f7a12ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "3c438174-1e64-4e11-afad-a23cfb6ae559");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "e21447cb-d58c-4bfa-b261-456ce5c8d3d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "a950e743-617d-4cee-b119-e5c1a89bd356");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58a5e019-a005-48ac-b2f4-26dd0969539f", "AQAAAAEAACcQAAAAELe2dNQey9rq0yWrKUXVBxYw2HnIhYOMOO9RlHQyIVWODdwtUirkRQW2FQ2aUt8KtA==", "b66e5a02-4804-4a19-9b2a-ed24b950d87a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf13c9df-4fbd-4f99-a087-88322aa64331", "AQAAAAEAACcQAAAAEGMY6Axu/jV6qLMoTpP5ZGINkUih+xnuPCxGpBOCKGP2f5qjVwKJmkmBKSF7rUEI5A==", "26e9169b-f7ea-4659-8dd3-df8f22dcfb16" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CompanyId",
                table: "Services",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Companies_CompanyId",
                table: "Services",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Companies_CompanyId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CompanyId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "67f426e0-6094-4b48-b71f-8be58fcdc4b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "f97596ee-ae86-48da-9192-118acc11fb0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "9f3cdb61-dbfd-4d24-9411-5a91c8ab75fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "5a318f1b-6266-46b6-969c-e43d86761760");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6deeef11-8d2a-45ec-9d84-c0cb9e0c7174", "AQAAAAEAACcQAAAAEMf83noTYKTdYD+0JE7p4z631WyMjz++FVFCO7mDbhA8KP9PauEWDkTmPiI/5JL0lA==", "bcbc850d-b903-489c-ba31-9c9d4c090e51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8de2fd2d-d429-46c7-9855-b9d1dff81eca", "AQAAAAEAACcQAAAAEKNasGlDvTh5r/dre3pwd0+knpr9CaztDRG7LXeuBG8+jlPiZNwuIcluRw3KNP65QQ==", "4d5013b0-46b6-4c1a-9ddb-8aa622c6443c" });
        }
    }
}
