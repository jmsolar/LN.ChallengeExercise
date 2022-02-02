using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LN.Infraestructure.Persistence.Migrations
{
    public partial class AgregoclavesforaneasalasentidadesPhoneNumberAddressCountryCityyState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Addresses_AddressId",
                schema: "ApplicationDB",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneNumbers_PhoneNumberId",
                schema: "ApplicationDB",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AddressId",
                schema: "ApplicationDB",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PhoneNumberId",
                schema: "ApplicationDB",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CityId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CountryId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StateId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "ApplicationDB",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhoneNumberId",
                schema: "ApplicationDB",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StateId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "ApplicationDB",
                table: "States",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                schema: "ApplicationDB",
                table: "PhoneNumbers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "ApplicationDB",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "ApplicationDB",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                schema: "ApplicationDB",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_States_AddressId",
                schema: "ApplicationDB",
                table: "States",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ContactId",
                schema: "ApplicationDB",
                table: "PhoneNumbers",
                column: "ContactId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_AddressId",
                schema: "ApplicationDB",
                table: "Countries",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_AddressId",
                schema: "ApplicationDB",
                table: "Cities",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ContactId",
                schema: "ApplicationDB",
                table: "Addresses",
                column: "ContactId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Contacts_ContactId",
                schema: "ApplicationDB",
                table: "Addresses",
                column: "ContactId",
                principalSchema: "ApplicationDB",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Addresses_AddressId",
                schema: "ApplicationDB",
                table: "Cities",
                column: "AddressId",
                principalSchema: "ApplicationDB",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Addresses_AddressId",
                schema: "ApplicationDB",
                table: "Countries",
                column: "AddressId",
                principalSchema: "ApplicationDB",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Contacts_ContactId",
                schema: "ApplicationDB",
                table: "PhoneNumbers",
                column: "ContactId",
                principalSchema: "ApplicationDB",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Addresses_AddressId",
                schema: "ApplicationDB",
                table: "States",
                column: "AddressId",
                principalSchema: "ApplicationDB",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Contacts_ContactId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Addresses_AddressId",
                schema: "ApplicationDB",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Addresses_AddressId",
                schema: "ApplicationDB",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_Contacts_ContactId",
                schema: "ApplicationDB",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Addresses_AddressId",
                schema: "ApplicationDB",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_AddressId",
                schema: "ApplicationDB",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_ContactId",
                schema: "ApplicationDB",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Countries_AddressId",
                schema: "ApplicationDB",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_AddressId",
                schema: "ApplicationDB",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ContactId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "ApplicationDB",
                table: "States");

            migrationBuilder.DropColumn(
                name: "ContactId",
                schema: "ApplicationDB",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "ApplicationDB",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "ApplicationDB",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ContactId",
                schema: "ApplicationDB",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "ApplicationDB",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhoneNumberId",
                schema: "ApplicationDB",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                schema: "ApplicationDB",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                schema: "ApplicationDB",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                schema: "ApplicationDB",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressId",
                schema: "ApplicationDB",
                table: "Contacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PhoneNumberId",
                schema: "ApplicationDB",
                table: "Contacts",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                schema: "ApplicationDB",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                schema: "ApplicationDB",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                schema: "ApplicationDB",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                schema: "ApplicationDB",
                table: "Addresses",
                column: "CityId",
                principalSchema: "ApplicationDB",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                schema: "ApplicationDB",
                table: "Addresses",
                column: "CountryId",
                principalSchema: "ApplicationDB",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                schema: "ApplicationDB",
                table: "Addresses",
                column: "StateId",
                principalSchema: "ApplicationDB",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Addresses_AddressId",
                schema: "ApplicationDB",
                table: "Contacts",
                column: "AddressId",
                principalSchema: "ApplicationDB",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneNumbers_PhoneNumberId",
                schema: "ApplicationDB",
                table: "Contacts",
                column: "PhoneNumberId",
                principalSchema: "ApplicationDB",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
