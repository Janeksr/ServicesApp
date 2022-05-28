using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturedServices.Data.Migrations
{
    public partial class ChangeInWorkersAndServicesTablesManyToManyRelationV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceWorker_Services_WorkerId",
                table: "ServiceWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceWorker_Workers_ServiceId",
                table: "ServiceWorker");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "ServiceWorker",
                newName: "WorkersId");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "ServiceWorker",
                newName: "ServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceWorker_WorkerId",
                table: "ServiceWorker",
                newName: "IX_ServiceWorker_WorkersId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceWorker_Services_ServicesId",
                table: "ServiceWorker",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceWorker_Workers_WorkersId",
                table: "ServiceWorker",
                column: "WorkersId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceWorker_Services_ServicesId",
                table: "ServiceWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceWorker_Workers_WorkersId",
                table: "ServiceWorker");

            migrationBuilder.RenameColumn(
                name: "WorkersId",
                table: "ServiceWorker",
                newName: "WorkerId");

            migrationBuilder.RenameColumn(
                name: "ServicesId",
                table: "ServiceWorker",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceWorker_WorkersId",
                table: "ServiceWorker",
                newName: "IX_ServiceWorker_WorkerId");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceWorker_Services_WorkerId",
                table: "ServiceWorker",
                column: "WorkerId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceWorker_Workers_ServiceId",
                table: "ServiceWorker",
                column: "ServiceId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
