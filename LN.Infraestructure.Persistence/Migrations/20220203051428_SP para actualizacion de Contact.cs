using Microsoft.EntityFrameworkCore.Migrations;

namespace LN.Infraestructure.Persistence.Migrations
{
    public partial class SPparaactualizaciondeContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"EXEC(N'CREATE OR ALTER PROCEDURE [ApplicationDB].[Contact_Update] 
                        @Name VARCHAR(15), @Company VARCHAR(15), @Profile VARCHAR(15), @CountryCode VARCHAR(15), 
                        @StateCodePH VARCHAR(15), @NumberPH VARCHAR(15), @IsPersonal BIT, @CountryName VARCHAR(15),
                        @CountryNumCode INT, @AlphaCode VARCHAR(15), @StateCode VARCHAR(15), @StateName VARCHAR(15), 
                        @ZipCode INT, @CityName VARCHAR(15), @AddressDetail VARCHAR(15), @Id VARCHAR(100) AS
                        BEGIN
                            DECLARE @AddressId VARCHAR(100);

                            UPDATE ApplicationDB.Contacts
                            SET Name = @Name, Company = @Company, Profile = @Profile
                            WHERE Id = @Id;

                            UPDATE ApplicationDB.PhoneNumbers
                            SET CountryCode = @CountryCode, StateCode = @StateCodePH, Number = @NumberPH, IsPersonal = @IsPersonal
                            WHERE ContactId = @Id;

                            UPDATE ApplicationDB.Addresses
                            SET Detail = @AddressDetail
                            WHERE ContactId = @Id;

	                        SELECT @AddressId = Id
	                        FROM ApplicationDB.Addresses
	                        WHERE ContactId = @Id;

                            UPDATE ApplicationDB.Cities
                            SET ZipCode = @ZipCode, Name = @CityName
                            WHERE AddressId = @AddressId;

                            UPDATE ApplicationDB.States
                            SET Code = @StateCode, Name = @StateName
                            WHERE AddressId = @AddressId;

                            UPDATE ApplicationDB.Countries
                            SET Name = @CountryName, NumericCode = @CountryNumCode, AlphaCode = @AlphaCode
                            WHERE AddressId = @AddressId;
                        END')";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROC [ApplicationDB].[Contact_Update]";

            migrationBuilder.Sql(sp);
        }
    }
}
