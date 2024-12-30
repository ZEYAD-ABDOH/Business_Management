using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectArti.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_Balcony_BalconyId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_CommercialType_CommercialTypeId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_Garage_GarageId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_GardenType_GardenTypeId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_GymTop_GymTopId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_MeetingRoom_MeetingRoomId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_Parking_ParkingId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_RecreationalArea_RecreationalAreaId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_SwimmingPoolT_SwimmingPoolTId",
                table: "FloorType");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FloorType",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "SwimmingPoolTId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RecreationalAreaId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MeetingRoomId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GymTopId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GardenTypeId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GarageId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CommercialTypeId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BalconyId",
                table: "FloorType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FloorType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCommercial",
                table: "FloorType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsResidential",
                table: "FloorType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "FloorType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CommercialType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CommercialType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PropertyID",
                table: "clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_clients_PropertyID",
                table: "clients",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_properties_PropertyID",
                table: "clients",
                column: "PropertyID",
                principalTable: "properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_Balcony_BalconyId",
                table: "FloorType",
                column: "BalconyId",
                principalTable: "Balcony",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_CommercialType_CommercialTypeId",
                table: "FloorType",
                column: "CommercialTypeId",
                principalTable: "CommercialType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_Garage_GarageId",
                table: "FloorType",
                column: "GarageId",
                principalTable: "Garage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_GardenType_GardenTypeId",
                table: "FloorType",
                column: "GardenTypeId",
                principalTable: "GardenType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_GymTop_GymTopId",
                table: "FloorType",
                column: "GymTopId",
                principalTable: "GymTop",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_MeetingRoom_MeetingRoomId",
                table: "FloorType",
                column: "MeetingRoomId",
                principalTable: "MeetingRoom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_Parking_ParkingId",
                table: "FloorType",
                column: "ParkingId",
                principalTable: "Parking",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_RecreationalArea_RecreationalAreaId",
                table: "FloorType",
                column: "RecreationalAreaId",
                principalTable: "RecreationalArea",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_SwimmingPoolT_SwimmingPoolTId",
                table: "FloorType",
                column: "SwimmingPoolTId",
                principalTable: "SwimmingPoolT",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_properties_PropertyID",
                table: "clients");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_Balcony_BalconyId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_CommercialType_CommercialTypeId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_Garage_GarageId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_GardenType_GardenTypeId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_GymTop_GymTopId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_MeetingRoom_MeetingRoomId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_Parking_ParkingId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_RecreationalArea_RecreationalAreaId",
                table: "FloorType");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorType_SwimmingPoolT_SwimmingPoolTId",
                table: "FloorType");

            migrationBuilder.DropIndex(
                name: "IX_clients_PropertyID",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FloorType");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "FloorType");

            migrationBuilder.DropColumn(
                name: "IsCommercial",
                table: "FloorType");

            migrationBuilder.DropColumn(
                name: "IsResidential",
                table: "FloorType");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "FloorType");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CommercialType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CommercialType");

            migrationBuilder.DropColumn(
                name: "PropertyID",
                table: "clients");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FloorType",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "SwimmingPoolTId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecreationalAreaId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParkingId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeetingRoomId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GymTopId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GardenTypeId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GarageId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommercialTypeId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BalconyId",
                table: "FloorType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_Balcony_BalconyId",
                table: "FloorType",
                column: "BalconyId",
                principalTable: "Balcony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_CommercialType_CommercialTypeId",
                table: "FloorType",
                column: "CommercialTypeId",
                principalTable: "CommercialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_Garage_GarageId",
                table: "FloorType",
                column: "GarageId",
                principalTable: "Garage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_GardenType_GardenTypeId",
                table: "FloorType",
                column: "GardenTypeId",
                principalTable: "GardenType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_GymTop_GymTopId",
                table: "FloorType",
                column: "GymTopId",
                principalTable: "GymTop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_MeetingRoom_MeetingRoomId",
                table: "FloorType",
                column: "MeetingRoomId",
                principalTable: "MeetingRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_Parking_ParkingId",
                table: "FloorType",
                column: "ParkingId",
                principalTable: "Parking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_RecreationalArea_RecreationalAreaId",
                table: "FloorType",
                column: "RecreationalAreaId",
                principalTable: "RecreationalArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FloorType_SwimmingPoolT_SwimmingPoolTId",
                table: "FloorType",
                column: "SwimmingPoolTId",
                principalTable: "SwimmingPoolT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
