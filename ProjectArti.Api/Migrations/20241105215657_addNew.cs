using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectArti.Api.Migrations
{
    /// <inheritdoc />
    public partial class addNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatuApplicant",
                table: "applicants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatuApplicant",
                table: "applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
