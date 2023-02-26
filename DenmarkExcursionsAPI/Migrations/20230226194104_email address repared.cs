using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenmarkExcursionsAPI.Migrations
{
    public partial class emailaddressrepared : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAdress",
                table: "Users",
                newName: "EmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Users",
                newName: "EmailAdress");
        }
    }
}
