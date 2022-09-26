using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinkelTicket.Database.Migrations
{
    public partial class UserRoleProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Tickets",
                newName: "ExpectedEndDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualEndDate",
                table: "Tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b9231fe-4e7f-471b-9a47-36a155b559c1", "8c416984-8a44-4334-ad49-455d73d9415d", "Requester", "REQUESTER" },
                    { "2c517848-2b8f-4e5b-98b3-130c445d98f7", "c3807e8e-9fb1-4784-8a2d-5398e6677dec", "Designer", "DESIGNER" },
                    { "31114486-d18e-4b8f-a053-77111029a27b", "0a66d0f0-7659-4c2e-a52e-af826bd85ec8", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "474de032-f1ed-4845-a6dc-15bf32c02e63", 0, null, "e24124f4-2d63-467f-86b5-7309c36a01e5", "melihcan.karaca@winkel.com.tr", false, "Melihcan Kazım Karaca", false, null, "Melihcan Kazım", "MELIHCAN.KARACA@WINKEL.COM.TR", "MELIHCAN.KARACA@WINKEL.COM.TR", "AQAAAAEAACcQAAAAELYQUIkW7lNhJdMbWZPYtgDmm2GxqBhN1ykOSm8Pw6IRqC13U1yw8ChYjLygSuoXRA==", null, false, "3a249142-9860-4781-b3f3-63b6e070cc45", "Admin", "5b5f6d66-d68b-4ccc-800a-de5541bd9d0e", "Karaca", false, "melihcan.karaca@winkel.com.tr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b9231fe-4e7f-471b-9a47-36a155b559c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c517848-2b8f-4e5b-98b3-130c445d98f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31114486-d18e-4b8f-a053-77111029a27b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "474de032-f1ed-4845-a6dc-15bf32c02e63");

            migrationBuilder.DropColumn(
                name: "ActualEndDate",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ExpectedEndDate",
                table: "Tickets",
                newName: "EndDate");

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
    }
}
