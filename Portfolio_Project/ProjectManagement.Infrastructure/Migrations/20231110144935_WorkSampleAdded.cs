using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkSampleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkSamples",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSamples_WorkSampleCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "WorkSampleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSamples_CategoryId",
                table: "WorkSamples",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSamples");
        }
    }
}
