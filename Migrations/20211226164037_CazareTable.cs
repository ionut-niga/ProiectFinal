using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class CazareTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cazare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinatieID = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cazare", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CazareID",
                table: "Contract",
                column: "CazareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Cazare_CazareID",
                table: "Contract",
                column: "CazareID",
                principalTable: "Cazare",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Cazare_CazareID",
                table: "Contract");

            migrationBuilder.DropTable(
                name: "Cazare");

            migrationBuilder.DropIndex(
                name: "IX_Contract_CazareID",
                table: "Contract");
        }
    }
}
