using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace List.Host.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lists");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Lists",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Lists");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Lists",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
