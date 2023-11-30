using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "Password", "UserName" },
                values: new object[] { 1, "email@email.com", true, "5F4DCC3B5AA765D61D8327DEB882CF99", "admin" });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "FirstName", "LastName", "PersonalNumber" },
                values: new object[] { 1, "Admin", "Adminashvili", "000000000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
