using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeAndTagsToRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Tags", "Type" },
                values: new object[] { "", "Main" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Recipes");
        }
    }
}
