using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_api.Migrations
{
    /// <inheritdoc />
    public partial class columnupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Company_CompanyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Company",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                schema: "public",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CompanyId",
                schema: "public",
                table: "User",
                newName: "IX_User_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "public",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_User_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalSchema: "public",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Company_CompanyId",
                schema: "public",
                table: "User",
                column: "CompanyId",
                principalSchema: "public",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_User_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Company_CompanyId",
                schema: "public",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "public",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Company",
                schema: "public",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "public",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_User_CompanyId",
                table: "Users",
                newName: "IX_Users_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Company_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
