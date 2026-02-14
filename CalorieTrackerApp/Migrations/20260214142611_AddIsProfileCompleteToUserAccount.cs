using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddIsProfileCompleteToUserAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProfileComplete",
                table: "UserAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProfileComplete",
                table: "UserAccounts");
        }
    }
}
