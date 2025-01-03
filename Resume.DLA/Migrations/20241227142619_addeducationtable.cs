using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DLA.Migrations
{
    /// <inheritdoc />
    public partial class addeducationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateOnly>(type: "date", nullable: false),
                    End = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AboutMeTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "BrithDay",
                value: new DateOnly(2024, 12, 27));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.UpdateData(
                table: "AboutMeTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "BrithDay",
                value: new DateOnly(2024, 12, 25));
        }
    }
}
