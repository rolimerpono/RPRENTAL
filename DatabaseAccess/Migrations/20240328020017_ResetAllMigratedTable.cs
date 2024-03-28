using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class ResetAllMigratedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AmenityOnly",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMENITY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AmenityOnly", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Rooms",
                columns: table => new
                {
                    ROOM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROOM_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ROOM_PRICE = table.Column<double>(type: "float", nullable: false),
                    MAX_OCCUPANCY = table.Column<int>(type: "int", nullable: false),
                    IMAGE_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Rooms", x => x.ROOM_ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_RoleClaims_tbl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_UserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_tbl_UserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tbl_UserRoles_tbl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_UserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_tbl_UserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoomAmenity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROOM_ID = table.Column<int>(type: "int", nullable: false),
                    AMENITY_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoomAmenity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_RoomAmenity_tbl_AmenityOnly_AMENITY_ID",
                        column: x => x.AMENITY_ID,
                        principalTable: "tbl_AmenityOnly",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Amenity",
                columns: table => new
                {
                    AMENITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMENITY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ROOM_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Amenity", x => x.AMENITY_ID);
                    table.ForeignKey(
                        name: "FK_tbl_Amenity_tbl_Rooms_ROOM_ID",
                        column: x => x.ROOM_ID,
                        principalTable: "tbl_Rooms",
                        principalColumn: "ROOM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Booking",
                columns: table => new
                {
                    BOOKING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ROOM_ID = table.Column<int>(type: "int", nullable: false),
                    ROOM_NUMBER = table.Column<int>(type: "int", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USER_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOTAL_COST = table.Column<double>(type: "float", nullable: false),
                    BOOKING_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOOKING_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHECK_IN_DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    CHECK_OUT_DATE = table.Column<DateOnly>(type: "date", nullable: false),
                    IS_PAYMENT_SUCCESSFULL = table.Column<bool>(type: "bit", nullable: false),
                    PAYMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STRIPE_SESSION_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STRIPE_PAYEMENT_INTENT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTUAL_CHECK_IN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACTUAL_CHECK_OUT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Booking", x => x.BOOKING_ID);
                    table.ForeignKey(
                        name: "FK_tbl_Booking_AspNetUsers_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Booking_tbl_Rooms_ROOM_ID",
                        column: x => x.ROOM_ID,
                        principalTable: "tbl_Rooms",
                        principalColumn: "ROOM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoomNumber",
                columns: table => new
                {
                    ROOM_NUMBER = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ROOM_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoomNumber", x => x.ROOM_NUMBER);
                    table.ForeignKey(
                        name: "FK_tbl_RoomNumber_tbl_Rooms_ROOM_ID",
                        column: x => x.ROOM_ID,
                        principalTable: "tbl_Rooms",
                        principalColumn: "ROOM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_AmenityOnly",
                columns: new[] { "ID", "AMENITY_NAME" },
                values: new object[,]
                {
                    { 1, "Washing Machine" },
                    { 2, "Electric Fan" },
                    { 3, "TV" },
                    { 4, "Internet Wifi" },
                    { 5, "Microwave" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Rooms",
                columns: new[] { "ROOM_ID", "CREATED_DATE", "DESCRIPTION", "IMAGE_URL", "MAX_OCCUPANCY", "ROOM_NAME", "ROOM_PRICE", "UPDATED_DATE" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3192), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. Nam vitae ex nec felis suscipit lobortis non sed nisl.", "https://placehold.co/600x400/png", 1, "Single Room", 85.0, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3193) },
                    { 2, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3201), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. Nam vitae ex nec felis suscipit lobortis non sed nisl.", "https://placehold.co/600x400/png", 2, "Double Room", 90.0, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3202) },
                    { 3, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3207), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. Nam vitae ex nec felis suscipit lobortis non sed nisl.", "https://placehold.co/600x400/png", 3, "Deluxed Room", 100.0, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3208) },
                    { 4, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3215), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. Nam vitae ex nec felis suscipit lobortis non sed nisl.", "https://placehold.co/600x400/png", 4, "Queens Room", 120.0, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3216) },
                    { 5, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3222), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. Nam vitae ex nec felis suscipit lobortis non sed nisl.", "https://placehold.co/600x400/png", 5, "Kings Room", 130.0, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3223) },
                    { 6, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3229), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus, id aliquam ante lacinia. Donec a leo pharetra, venenatis est ut, scelerisque leo. Nam vitae ex nec felis suscipit lobortis non sed nisl.", "https://placehold.co/600x400/png", 10, "Executive Suite", 180.0, new DateTime(2024, 3, 28, 14, 0, 15, 970, DateTimeKind.Local).AddTicks(3230) }
                });

            migrationBuilder.InsertData(
                table: "tbl_Amenity",
                columns: new[] { "AMENITY_ID", "AMENITY_NAME", "DESCRIPTION", "ROOM_ID" },
                values: new object[,]
                {
                    { 1, "Microwave", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 1 },
                    { 2, "Electric Fan", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 1 },
                    { 3, "Aircon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 1 },
                    { 4, "Netflix", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 1 },
                    { 5, "Washing Machine", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 1 },
                    { 6, "Microwave", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 2 },
                    { 7, "Electric Fan", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 2 },
                    { 8, "Aircon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 2 },
                    { 9, "Netflix", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 2 },
                    { 10, "Washing Machine", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 2 },
                    { 11, "Microwave", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 3 },
                    { 12, "Electric Fan", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 3 },
                    { 13, "Aircon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 3 },
                    { 14, "Netflix", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 3 },
                    { 15, "Washing Machine", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 3 },
                    { 16, "Microwave", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 4 },
                    { 17, "Electric Fan", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 4 },
                    { 18, "Aircon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 4 },
                    { 19, "Netflix", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 4 },
                    { 20, "Washing Machine", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 4 },
                    { 21, "Microwave", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 5 },
                    { 22, "Electric Fan", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 5 },
                    { 23, "Aircon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 5 },
                    { 24, "Netflix", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 5 },
                    { 25, "Washing Machine", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 5 },
                    { 26, "Microwave", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 6 },
                    { 27, "Electric Fan", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 6 },
                    { 28, "Aircon", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 6 },
                    { 29, "Netflix", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 6 },
                    { 30, "Washing Machine", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta.", 6 }
                });

            migrationBuilder.InsertData(
                table: "tbl_RoomAmenity",
                columns: new[] { "ID", "AMENITY_ID", "ROOM_ID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "tbl_RoomNumber",
                columns: new[] { "ROOM_NUMBER", "DESCRIPTION", "ROOM_ID" },
                values: new object[,]
                {
                    { 101, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 1 },
                    { 102, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 1 },
                    { 103, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 1 },
                    { 104, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 1 },
                    { 201, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 2 },
                    { 202, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 2 },
                    { 203, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 2 },
                    { 204, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 2 },
                    { 301, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 3 },
                    { 302, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 3 },
                    { 303, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 3 },
                    { 304, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 3 },
                    { 401, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 4 },
                    { 402, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 4 },
                    { 403, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 4 },
                    { 501, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 5 },
                    { 502, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 5 },
                    { 503, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 5 },
                    { 601, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 6 },
                    { 602, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna. Donec quis consectetur mi, eu luctus lacus.Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec facilisis metus quis orci faucibus", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoleClaims_RoleId",
                table: "tbl_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "tbl_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserClaims_UserId",
                table: "tbl_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserLogins_UserId",
                table: "tbl_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserRoles_RoleId",
                table: "tbl_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Amenity_ROOM_ID",
                table: "tbl_Amenity",
                column: "ROOM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Booking_ROOM_ID",
                table: "tbl_Booking",
                column: "ROOM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Booking_USER_ID",
                table: "tbl_Booking",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoomAmenity_AMENITY_ID",
                table: "tbl_RoomAmenity",
                column: "AMENITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoomNumber_ROOM_ID",
                table: "tbl_RoomNumber",
                column: "ROOM_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_RoleClaims");

            migrationBuilder.DropTable(
                name: "tbl_UserClaims");

            migrationBuilder.DropTable(
                name: "tbl_UserLogins");

            migrationBuilder.DropTable(
                name: "tbl_UserRoles");

            migrationBuilder.DropTable(
                name: "tbl_UserTokens");

            migrationBuilder.DropTable(
                name: "tbl_Amenity");

            migrationBuilder.DropTable(
                name: "tbl_Booking");

            migrationBuilder.DropTable(
                name: "tbl_RoomAmenity");

            migrationBuilder.DropTable(
                name: "tbl_RoomNumber");

            migrationBuilder.DropTable(
                name: "tbl_Roles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbl_AmenityOnly");

            migrationBuilder.DropTable(
                name: "tbl_Rooms");
        }
    }
}
