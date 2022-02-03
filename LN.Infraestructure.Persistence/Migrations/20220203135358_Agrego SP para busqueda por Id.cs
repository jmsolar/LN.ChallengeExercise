using Microsoft.EntityFrameworkCore.Migrations;

namespace LN.Infraestructure.Persistence.Migrations
{
    public partial class AgregoSPparabusquedaporId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"EXEC(N'CREATE OR ALTER PROCEDURE [ApplicationDB].[Contact_FindById] 
                         @Id VARCHAR(100) AS
                        BEGIN
	                        SELECT *
	                        FROM ApplicationDB.Contacts
	                        WHERE Id = @Id;
                        END')";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROC [ApplicationDB].[Contact_FindById]";

            migrationBuilder.Sql(sp);
        }
    }
}
