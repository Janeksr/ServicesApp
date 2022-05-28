using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class ChangeInWorkersAndServicesTablesManyToManyRelationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiceWorker",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceWorker", x => new { x.ServiceId, x.WorkerId });
                    table.ForeignKey(
                        name: "FK_ServiceWorker_Services_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceWorker_Workers_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                column: "ConcurrencyStamp",
                value: "4295f085-4888-44af-8cb0-75fa7be38288");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "440edbf7-7132-4f68-b6b6-6229a3acdecd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "34cd0474-ffe4-40d4-a4f1-6016d9b77488");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "3d1e7df8-67f5-4b35-bdcf-d66ca534a77b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4db1bc34-c029-4770-9a9c-83d0e72b4a80", "AQAAAAEAACcQAAAAELAMUrTa9CFP64pELA9299iuVxwMEIBqtAIZd0bnBmz9qFZ2cc/Lh5zTRfY28jbCNg==", "0efa878f-6c4e-41a7-8c78-8d9fdca7fa68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a494c61-9194-41c1-a0a0-16f9a4d81019", "AQAAAAEAACcQAAAAEIN/CwG8rtDnQ/eZkvmchtGZ09iWVLIwsVwBzwD6Ae8jUHEHmHO7qex2rLGlzkXAOA==", "ba826904-b865-4b2f-838e-ee02534ab0f1" });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CompanyId",
                table: "Workers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceWorker_WorkerId",
                table: "ServiceWorker",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Companies_CompanyId",
                table: "Workers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Companies_CompanyId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "ServiceWorker");

            migrationBuilder.DropIndex(
                name: "IX_Workers_CompanyId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Workers");

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
                value: "5d0ec0ea-4ab3-4805-8456-6bf24b262550");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                column: "ConcurrencyStamp",
                value: "076e7f63-8da5-4ac4-a427-59b389b4d94a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6261baec-128e-a0ab-ae32-164f20a1bced",
                column: "ConcurrencyStamp",
                value: "751f9b6c-5512-4a90-9ade-ad2c01cd3f8c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                column: "ConcurrencyStamp",
                value: "840cadf0-156c-474f-bdce-dd28729c8fa7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408121ad-b63e-49ff-1d02-6c221af8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67036ea7-26d7-4904-8dc1-c9c7f18a9718", "AQAAAAEAACcQAAAAEOi5HibvtLknHrsp3OpjbzlG3XPCXzcj6xovJrKT+zl5WCG+dgliKONnE540UJn9fg==", "4a69281d-98ed-4f6e-87a3-89751cd28096" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24683538-a2a2-45cb-9d88-6ea39073e05d", "AQAAAAEAACcQAAAAEBrd+oNPRKlGLcrWbqXsfPZvKNvUfw3MdlHSSLdtLMqMBFvCatmVAG7CBAv34mVp2A==", "764564f2-d620-4bb0-b518-820908cbfba6" });

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
    }
}
