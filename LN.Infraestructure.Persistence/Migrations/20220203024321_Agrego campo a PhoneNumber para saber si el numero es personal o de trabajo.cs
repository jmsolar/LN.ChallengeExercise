using Microsoft.EntityFrameworkCore.Migrations;

namespace LN.Infraestructure.Persistence.Migrations
{
    public partial class AgregocampoaPhoneNumberparasabersielnumeroespersonalodetrabajo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPersonal",
                schema: "ApplicationDB",
                table: "PhoneNumbers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPersonal",
                schema: "ApplicationDB",
                table: "PhoneNumbers");
        }
    }
}
