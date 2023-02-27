using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFes.Migrations
{
    /// <inheritdoc />
    public partial class _20230226_1740 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contentId",
                table: "Favorites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "contentId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
