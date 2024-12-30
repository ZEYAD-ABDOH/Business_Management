using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectArti.Api.Migrations
{
    /// <inheritdoc />
    public partial class ADD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_units_UnitID",
                table: "clients");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropIndex(
                name: "IX_clients_UnitID",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "UnitID",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "profiles",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Employees",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "craftsmens",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "clients",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "applicants",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "NameStatus",
                table: "RentedStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameStatus",
                table: "RentedStatus");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "profiles",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Employees",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "craftsmens",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "clients",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "applicants",
                newName: "gender");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UnitID",
                table: "clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UnitSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: true),
                    HasBalcony = table.Column<bool>(type: "bit", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasGarage = table.Column<bool>(type: "bit", nullable: true),
                    NumberOfBedrooms = table.Column<int>(type: "int", nullable: true),
                    houseAmentities_NumberOfFloor = table.Column<int>(type: "int", nullable: true),
                    HasConferenceRoom = table.Column<bool>(type: "bit", nullable: true),
                    NumberOfWorkspaces = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_units_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_UnitID",
                table: "clients",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_units_CompanyID",
                table: "units",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_units_UnitID",
                table: "clients",
                column: "UnitID",
                principalTable: "units",
                principalColumn: "Id");
        }
    }
}
