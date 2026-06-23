using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckZone.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToScamReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "ScamReports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "ScamReports");
        }
    }
}
