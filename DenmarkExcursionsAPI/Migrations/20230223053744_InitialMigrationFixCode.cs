using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenmarkExcursionsAPI.Migrations
{
    public partial class InitialMigrationFixCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Came",
                table: "Regions",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Regions",
                newName: "Came");
        }
    }
}
