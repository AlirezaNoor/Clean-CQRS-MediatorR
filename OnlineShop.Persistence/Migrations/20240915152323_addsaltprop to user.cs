using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addsaltproptouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");
        }
    }
}
