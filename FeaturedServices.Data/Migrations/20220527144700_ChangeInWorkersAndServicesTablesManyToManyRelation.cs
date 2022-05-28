using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class ChangeInWorkersAndServicesTablesManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Workers_WorkerId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Companies_CompanyId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_CompanyId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Services_WorkerId",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "c1e45d32-fa07-41e7-aa47-c84c3f612aad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "8e0da763-d98b-4e0b-9918-c402224625bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "34e73011-69fd-45a3-9508-5ad683146f9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "0bdd9f99-9698-4f2d-83ae-aacb689675ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "722fba00-9ffb-498e-9bdc-0cde2b0d3879", "AQAAAAEAACcQAAAAEOilRd+un0ULYz3g/ug/nRerwc7EeKaG4OKCUn267BYGXJYHkqMi3MadTaovcyYhHw==", "f3c989cd-9a7f-4813-9f73-3a0641e676d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2eb7add-56fe-4f17-b145-0e94535ec438", "AQAAAAEAACcQAAAAEBSOmB4PDTN1XbnvQF5yCPCjAhZgx66s4CfPy86MOncPLjYFod2jy8UOinQdaGqNxQ==", "2e279c46-2ff3-44a9-ba57-113497e3d68c" });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkerId",
                table: "Workers",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyId",
                table: "Companies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Workers_CompanyId",
                table: "Companies",
                column: "CompanyId",
                principalTable: "Workers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Services_WorkerId",
                table: "Workers",
                column: "WorkerId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Workers_CompanyId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Services_WorkerId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WorkerId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Companies");

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

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CompanyId",
                table: "Workers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_WorkerId",
                table: "Services",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Workers_WorkerId",
                table: "Services",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Companies_CompanyId",
                table: "Workers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
