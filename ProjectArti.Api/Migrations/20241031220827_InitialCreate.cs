using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectArti.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateListed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SpecialOffers = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Balcony",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalconySize = table.Column<int>(type: "int", nullable: false),
                    View = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balcony", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quality = table.Column<double>(type: "float", nullable: true),
                    Timeliness = table.Column<double>(type: "float", nullable: true),
                    Professionalism = table.Column<double>(type: "float", nullable: true),
                    Communication = table.Column<double>(type: "float", nullable: true),
                    OverallSatisfaction = table.Column<double>(type: "float", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "CommercialType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeSpaces = table.Column<int>(type: "int", nullable: false),
                    RetailSpaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageSize = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GardenType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GardenSize = table.Column<int>(type: "int", nullable: false),
                    PlantTypes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IrrigationSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Playground = table.Column<bool>(type: "bit", nullable: false),
                    SeatingArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GymTop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalTraining = table.Column<bool>(type: "bit", nullable: false),
                    ClassesOffered = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymTop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomSize = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSpots = table.Column<int>(type: "int", nullable: false),
                    CoveredSpots = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PendingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PendingSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedCloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonForPending = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecreationalArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaSize = table.Column<int>(type: "int", nullable: false),
                    TypesOfActivities = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Playground = table.Column<bool>(type: "bit", nullable: false),
                    PicnicArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecreationalArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentedStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyRent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SwimmingPoolT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoolSize = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmingPoolT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnderRenovationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenovationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnderRenovationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_BusinessType_BusinessTypeID",
                        column: x => x.BusinessTypeID,
                        principalTable: "BusinessType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FloorType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommercialTypeId = table.Column<int>(type: "int", nullable: false),
                    CommercialId = table.Column<int>(type: "int", nullable: false),
                    ParkingId = table.Column<int>(type: "int", nullable: false),
                    GardenTypeId = table.Column<int>(type: "int", nullable: false),
                    SwimmingPoolTId = table.Column<int>(type: "int", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false),
                    BalconyId = table.Column<int>(type: "int", nullable: false),
                    GymTopId = table.Column<int>(type: "int", nullable: false),
                    MeetingRoomId = table.Column<int>(type: "int", nullable: false),
                    RecreationalAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorType", x => x.id);
                    table.ForeignKey(
                        name: "FK_FloorType_Balcony_BalconyId",
                        column: x => x.BalconyId,
                        principalTable: "Balcony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_CommercialType_CommercialTypeId",
                        column: x => x.CommercialTypeId,
                        principalTable: "CommercialType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_Commercial_CommercialId",
                        column: x => x.CommercialId,
                        principalTable: "Commercial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_GardenType_GardenTypeId",
                        column: x => x.GardenTypeId,
                        principalTable: "GardenType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_GymTop_GymTopId",
                        column: x => x.GymTopId,
                        principalTable: "GymTop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_MeetingRoom_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalTable: "MeetingRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_Parking_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_RecreationalArea_RecreationalAreaId",
                        column: x => x.RecreationalAreaId,
                        principalTable: "RecreationalArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FloorType_SwimmingPoolT_SwimmingPoolTId",
                        column: x => x.SwimmingPoolTId,
                        principalTable: "SwimmingPoolT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PendingStatusId = table.Column<int>(type: "int", nullable: true),
                    RentedStatusId = table.Column<int>(type: "int", nullable: true),
                    SoldStatusId = table.Column<int>(type: "int", nullable: true),
                    AvailableStatusId = table.Column<int>(type: "int", nullable: true),
                    UnderRenovationStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyStatus_AvailableStatus_AvailableStatusId",
                        column: x => x.AvailableStatusId,
                        principalTable: "AvailableStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyStatus_PendingStatus_PendingStatusId",
                        column: x => x.PendingStatusId,
                        principalTable: "PendingStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyStatus_RentedStatus_RentedStatusId",
                        column: x => x.RentedStatusId,
                        principalTable: "RentedStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyStatus_SoldStatus_SoldStatusId",
                        column: x => x.SoldStatusId,
                        principalTable: "SoldStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyStatus_UnderRenovationStatus_UnderRenovationStatusId",
                        column: x => x.UnderRenovationStatusId,
                        principalTable: "UnderRenovationStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "craftsmens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearsOfExperience = table.Column<double>(type: "float", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_craftsmens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_craftsmens_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasicSalary = table.Column<double>(type: "float", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearsOfExperience = table.Column<double>(type: "float", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "jobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ResumeCV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatuApplicant = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobApplications_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    FloorNumber = table.Column<int>(type: "int", nullable: true),
                    HasBalcony = table.Column<bool>(type: "bit", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfBedrooms = table.Column<int>(type: "int", nullable: true),
                    houseAmentities_NumberOfFloor = table.Column<int>(type: "int", nullable: true),
                    HasGarage = table.Column<bool>(type: "bit", nullable: true),
                    NumberOfWorkspaces = table.Column<int>(type: "int", nullable: true),
                    HasConferenceRoom = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_units_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Floor = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Balcony = table.Column<bool>(type: "bit", nullable: false),
                    YearBuilt = table.Column<int>(type: "int", nullable: false),
                    ImagesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyType_FloorType_FloorTypeId",
                        column: x => x.FloorTypeId,
                        principalTable: "FloorType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "taskArtis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    startTask = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTask = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CraftsmanID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskArtis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskArtis_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_taskArtis_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_taskArtis_craftsmens_CraftsmanID",
                        column: x => x.CraftsmanID,
                        principalTable: "craftsmens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResumeCV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatuApplicant = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    JobApplicationID = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearsOfExperience = table.Column<double>(type: "float", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicants_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicants_jobApplications_JobApplicationID",
                        column: x => x.JobApplicationID,
                        principalTable: "jobApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitSize = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    PropertyStatusId = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_properties_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_properties_PropertyStatus_PropertyStatusId",
                        column: x => x.PropertyStatusId,
                        principalTable: "PropertyStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_properties_PropertyType_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CraftsmanID = table.Column<int>(type: "int", nullable: true),
                    UnitID = table.Column<int>(type: "int", nullable: true),
                    BaseRatingID = table.Column<int>(type: "int", nullable: true),
                    TaskID = table.Column<int>(type: "int", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearsOfExperience = table.Column<double>(type: "float", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_BaseRating_BaseRatingID",
                        column: x => x.BaseRatingID,
                        principalTable: "BaseRating",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_clients_craftsmens_CraftsmanID",
                        column: x => x.CraftsmanID,
                        principalTable: "craftsmens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_clients_taskArtis_TaskID",
                        column: x => x.TaskID,
                        principalTable: "taskArtis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_clients_units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CraftsmanID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearsOfExperience = table.Column<double>(type: "float", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profiles_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_profiles_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_profiles_clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_profiles_craftsmens_CraftsmanID",
                        column: x => x.CraftsmanID,
                        principalTable: "craftsmens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "requestClients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statusRequest = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestClients", x => x.id);
                    table.ForeignKey(
                        name: "FK_requestClients_clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicants_CompanyID",
                table: "applicants",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_applicants_JobApplicationID",
                table: "applicants",
                column: "JobApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_clients_BaseRatingID",
                table: "clients",
                column: "BaseRatingID");

            migrationBuilder.CreateIndex(
                name: "IX_clients_CraftsmanID",
                table: "clients",
                column: "CraftsmanID");

            migrationBuilder.CreateIndex(
                name: "IX_clients_TaskID",
                table: "clients",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_clients_UnitID",
                table: "clients",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BusinessTypeID",
                table: "Companies",
                column: "BusinessTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_craftsmens_CompanyID",
                table: "craftsmens",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyID",
                table: "Employees",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_BalconyId",
                table: "FloorType",
                column: "BalconyId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_CommercialId",
                table: "FloorType",
                column: "CommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_CommercialTypeId",
                table: "FloorType",
                column: "CommercialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_GarageId",
                table: "FloorType",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_GardenTypeId",
                table: "FloorType",
                column: "GardenTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_GymTopId",
                table: "FloorType",
                column: "GymTopId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_MeetingRoomId",
                table: "FloorType",
                column: "MeetingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_ParkingId",
                table: "FloorType",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_RecreationalAreaId",
                table: "FloorType",
                column: "RecreationalAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorType_SwimmingPoolTId",
                table: "FloorType",
                column: "SwimmingPoolTId");

            migrationBuilder.CreateIndex(
                name: "IX_jobApplications_CompanyID",
                table: "jobApplications",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_ClientID",
                table: "profiles",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_CompanyID",
                table: "profiles",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_CraftsmanID",
                table: "profiles",
                column: "CraftsmanID");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_EmployeeID",
                table: "profiles",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_properties_CompanyID",
                table: "properties",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_properties_Name",
                table: "properties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_properties_PropertyStatusId",
                table: "properties",
                column: "PropertyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_properties_PropertyTypeId",
                table: "properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyStatus_AvailableStatusId",
                table: "PropertyStatus",
                column: "AvailableStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyStatus_PendingStatusId",
                table: "PropertyStatus",
                column: "PendingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyStatus_RentedStatusId",
                table: "PropertyStatus",
                column: "RentedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyStatus_SoldStatusId",
                table: "PropertyStatus",
                column: "SoldStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyStatus_UnderRenovationStatusId",
                table: "PropertyStatus",
                column: "UnderRenovationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyType_FloorTypeId",
                table: "PropertyType",
                column: "FloorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_requestClients_ClientID",
                table: "requestClients",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_taskArtis_CompanyID",
                table: "taskArtis",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_taskArtis_CraftsmanID",
                table: "taskArtis",
                column: "CraftsmanID");

            migrationBuilder.CreateIndex(
                name: "IX_taskArtis_EmployeeID",
                table: "taskArtis",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_units_CompanyID",
                table: "units",
                column: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "requestClients");

            migrationBuilder.DropTable(
                name: "jobApplications");

            migrationBuilder.DropTable(
                name: "PropertyStatus");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "AvailableStatus");

            migrationBuilder.DropTable(
                name: "PendingStatus");

            migrationBuilder.DropTable(
                name: "RentedStatus");

            migrationBuilder.DropTable(
                name: "SoldStatus");

            migrationBuilder.DropTable(
                name: "UnderRenovationStatus");

            migrationBuilder.DropTable(
                name: "FloorType");

            migrationBuilder.DropTable(
                name: "BaseRating");

            migrationBuilder.DropTable(
                name: "taskArtis");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "Balcony");

            migrationBuilder.DropTable(
                name: "CommercialType");

            migrationBuilder.DropTable(
                name: "Commercial");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "GardenType");

            migrationBuilder.DropTable(
                name: "GymTop");

            migrationBuilder.DropTable(
                name: "MeetingRoom");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "RecreationalArea");

            migrationBuilder.DropTable(
                name: "SwimmingPoolT");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "craftsmens");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "BusinessType");
        }
    }
}
