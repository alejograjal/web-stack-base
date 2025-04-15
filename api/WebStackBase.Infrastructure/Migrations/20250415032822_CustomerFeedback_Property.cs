using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStackBase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomerFeedback_Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowInWeb",
                table: "CustomerFeedback",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInWeb",
                table: "CustomerFeedback");
        }
    }
}
