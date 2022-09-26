using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinkelTicket.Database.Migrations
{
    public partial class UserRolePropertyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7aac7272-3d4b-4a01-833a-139f8b2bef51", "60162675-8397-4ed0-946f-0cf0109e8136", "Requester", "REQUESTER" },
                    { "c6ed7348-f261-41f7-93a5-1f4a8132c91a", "0dbd2ced-2af2-4f7c-8676-6b610af1ddf2", "Designer", "DESIGNER" },
                    { "fbfe9af1-05be-4384-9ba8-d17e0caecf20", "4a7bbfd4-7f13-4111-a085-d36dff886704", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "474de032-f1ed-4845-a6dc-15bf32c02e63",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "44d079f5-6ae6-4e1f-9ec5-d215f90d99b4", "a4111caf-99f3-45e0-9d2a-70e6b48f62bd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7aac7272-3d4b-4a01-833a-139f8b2bef51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6ed7348-f261-41f7-93a5-1f4a8132c91a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbfe9af1-05be-4384-9ba8-d17e0caecf20");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b9231fe-4e7f-471b-9a47-36a155b559c1", "8c416984-8a44-4334-ad49-455d73d9415d", "Requester", "REQUESTER" },
                    { "2c517848-2b8f-4e5b-98b3-130c445d98f7", "c3807e8e-9fb1-4784-8a2d-5398e6677dec", "Designer", "DESIGNER" },
                    { "31114486-d18e-4b8f-a053-77111029a27b", "0a66d0f0-7659-4c2e-a52e-af826bd85ec8", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "474de032-f1ed-4845-a6dc-15bf32c02e63",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e24124f4-2d63-467f-86b5-7309c36a01e5", "5b5f6d66-d68b-4ccc-800a-de5541bd9d0e" });
        }
    }
}
