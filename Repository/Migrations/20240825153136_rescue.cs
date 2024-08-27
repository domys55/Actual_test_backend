using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class rescue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_Contacts_ContactId",
                table: "AddressModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModel_Contacts_ContactId",
                table: "PhoneModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneModel",
                table: "PhoneModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel");

            migrationBuilder.RenameTable(
                name: "PhoneModel",
                newName: "PhoneNums");

            migrationBuilder.RenameTable(
                name: "AddressModel",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneModel_ContactId",
                table: "PhoneNums",
                newName: "IX_PhoneNums_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressModel_ContactId",
                table: "Addresses",
                newName: "IX_Addresses_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNums",
                table: "PhoneNums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Contacts_ContactId",
                table: "Addresses",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNums_Contacts_ContactId",
                table: "PhoneNums",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Contacts_ContactId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNums_Contacts_ContactId",
                table: "PhoneNums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNums",
                table: "PhoneNums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "PhoneNums",
                newName: "PhoneModel");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "AddressModel");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNums_ContactId",
                table: "PhoneModel",
                newName: "IX_PhoneModel_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_ContactId",
                table: "AddressModel",
                newName: "IX_AddressModel_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneModel",
                table: "PhoneModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_Contacts_ContactId",
                table: "AddressModel",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModel_Contacts_ContactId",
                table: "PhoneModel",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
