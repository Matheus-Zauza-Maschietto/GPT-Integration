using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gpt_integration.Migrations
{
    /// <inheritdoc />
    public partial class updateorigin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origins",
                schema: "gptintegration",
                table: "ChatMessages");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                schema: "gptintegration",
                table: "ChatMessages",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                schema: "gptintegration",
                table: "ChatMessages");

            migrationBuilder.AddColumn<int>(
                name: "Origins",
                schema: "gptintegration",
                table: "ChatMessages",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
