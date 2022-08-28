using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinkelTicket.Database.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3911db3a-28ff-4b9c-b310-7cdc5b390441", "b415d545-a13f-451b-a99e-4ebb1cc44b0e", "Requester", "REQUESTER" },
                    { "6a30c8d6-b3a1-4a99-aee7-2cc1e3f793f5", "d380ea66-ed0a-479c-bb23-78bce2a76904", "Admin", "ADMIN" },
                    { "7121eac9-bb95-44db-bd7b-12cc52ff3d6b", "4db022a3-829e-417e-8811-8640e1975bc7", "Designer", "DESIGNER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3911db3a-28ff-4b9c-b310-7cdc5b390441");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a30c8d6-b3a1-4a99-aee7-2cc1e3f793f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7121eac9-bb95-44db-bd7b-12cc52ff3d6b");
        }
    }
}
