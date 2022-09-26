using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinkelTicket.Database.Migrations
{
    public partial class TicketUserRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1b5c269-8191-4ef1-87ba-614ffe654478");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5582643-eb2d-416b-921e-f61d2f69523e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8627bea-67ca-4248-b31e-bb83223b6048");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EndDate",
                table: "Tickets",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a249142-9860-4781-b3f3-63b6e070cc45", "45a398f1-77a9-4b62-8458-f779b5b2f13f", "Admin", "ADMIN" },
                    { "618f66e0-bfe7-491e-bb01-a2acdfa04ce6", "36b439c6-865c-420a-9653-154d1ab74f6f", "Requester", "REQUESTER" },
                    { "d8d03a08-b5ce-4c9e-aa4f-14c0f3d8ff89", "0da1b1ca-a170-4dd4-a31f-41c3ac4661dd", "Designer", "DESIGNER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a249142-9860-4781-b3f3-63b6e070cc45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "618f66e0-bfe7-491e-bb01-a2acdfa04ce6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8d03a08-b5ce-4c9e-aa4f-14c0f3d8ff89");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e1b5c269-8191-4ef1-87ba-614ffe654478", "7d3e3795-0539-490b-ba9e-1bb9c42ad5b5", "Requester", "REQUESTER" },
                    { "e5582643-eb2d-416b-921e-f61d2f69523e", "68db8fb5-fedf-4d9a-a69b-5146fc759084", "Admin", "ADMIN" },
                    { "e8627bea-67ca-4248-b31e-bb83223b6048", "b2c618a8-ebdd-4e96-8e98-6105b46dc6f1", "Designer", "DESIGNER" }
                });
        }
    }
}
