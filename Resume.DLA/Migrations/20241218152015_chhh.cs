using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DLA.Migrations
{
    /// <inheritdoc />
    public partial class chhh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegDate",
                value: new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegDate",
                value: new DateTime(2024, 12, 18, 18, 44, 36, 871, DateTimeKind.Local).AddTicks(2642));
        }
    }
}
