using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class AddedImageCopmaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "9725fe9f-c2a7-4fde-8e28-31cbaf7b6136");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "95e75bcc-2643-492e-9c40-77b7bf2c2fb8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "d078f6e4-8926-4659-8919-ad4805a0f012");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "1b82edbf-16ed-4ecc-9178-a0d514498cf1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96c8b493-1c65-40af-991e-5f7492c5b956", "AQAAAAEAACcQAAAAECQQKyLt3aqTG95BzW8j3GH9vfqH5jDawq83oVyP+Qpp9pZO9HqG/0p7+7eUNpVTCg==", "8810dabc-6bad-49cb-869d-8bc973296631" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70d398d1-4165-41e1-a025-2ab8e77c090d", "AQAAAAEAACcQAAAAEBi3Ma73a5y7Pf9yOQISuZd9giZwnpe2AZw961p03yZEyo+Q2CNDqWt6ESpiJetZMg==", "4cd8162b-8b07-4f97-a861-77556ff7578b" });

            migrationBuilder.CreateIndex(
                name: "IX_ImageCompanies_CompanyId",
                table: "ImageCompanies",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageCompanies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "37fc8182-6f6d-44b0-a656-53035609fb69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "8f0bf60e-bd9f-48b1-8850-cd7117b40325");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "74384759-cfbf-4134-8435-9514d6f055a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "31b22705-7a67-4dd8-a473-8fa95f43f9d1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d775a62-ecc5-4b83-acb8-7a783a5f9362", "AQAAAAEAACcQAAAAEIdUugFOUGPI5/MQfXoYQ+JneUTkzKSj/7eIcj2WommfwQB2rfMh1i7RN1OLSFDDTQ==", "b2c22b83-07f0-45ad-8e7b-bbee19c23c96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4492e31-6745-482c-b639-0e7630b232b8", "AQAAAAEAACcQAAAAEOviqxCB5IFYcDI6HhPA4Xul7kTnxl9fr32H8Qh8xpFVvO9dryKuszozXt710zZbHw==", "ba8abd99-2f63-445f-99ba-4bab48c70197" });
        }
    }
}
