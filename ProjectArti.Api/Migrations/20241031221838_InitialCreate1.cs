using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectArti.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_Commercial_CommercialId",
                table: "FloorType");

            migrationBuilder.DropTable(
                name: "Commercial");

            migrationBuilder.DropIndex(
                name: "IX_FloorType_CommercialId",
                table: "FloorType");

            migrationBuilder.DropColumn(
                name: "CommercialId",
                table: "FloorType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommercialId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Commercial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeSpaces = table.Column<int>(type: "int", nullable: false),
                    RetailSpaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commercial", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_CommercialId",
                table: "FloorType",
                column: "CommercialId");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_Commercial_CommercialId",
                table: "FloorType",
                column: "CommercialId",
                principalTable: "Commercial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
