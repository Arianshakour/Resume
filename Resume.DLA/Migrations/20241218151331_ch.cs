using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DLA.Migrations
{
    /// <inheritdoc />
    public partial class ch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "LastName", "Mobile", "Password", "RePassword", "RegDate" },
                values: new object[] { 1, "B@yahoo.com", "آریان", true, "شکور", "09121112233", "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B", "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B", new DateTime(2024, 12, 18, 18, 31, 43, 684, DateTimeKind.Local).AddTicks(4148) });
        }
    }
}
