using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MobileAddedToInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Information",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Information");
        }
    }
}
