using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class DataContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataContract",
                table: "Contract",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataContract",
                table: "Contract");
        }
    }
}
