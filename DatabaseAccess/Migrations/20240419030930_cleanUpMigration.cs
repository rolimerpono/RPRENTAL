using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class cleanUpMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
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
                name: "tbl_Amenity",
                columns: table => new
                {
                    AMENITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMENITY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Amenity", x => x.AMENITY_ID);
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
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    NO_OF_STAY = table.Column<int>(type: "int", nullable: false),
                    IS_PAYMENT_SUCCESSFULL = table.Column<bool>(type: "bit", nullable: false),
                    PAYMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STRIPE_SESSION_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STRIPE_PAYEMENT_INTENT_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTUAL_CHECK_IN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACTUAL_CHECK_OUT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACTUAL_CANCELLED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_tbl_RoomAmenity_tbl_Amenity_AMENITY_ID",
                        column: x => x.AMENITY_ID,
                        principalTable: "tbl_Amenity",
                        principalColumn: "AMENITY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RoomAmenity_tbl_Rooms_ROOM_ID",
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
                table: "tbl_Amenity",
                columns: new[] { "AMENITY_ID", "AMENITY_NAME" },
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
                    { 1, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1154), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 1, "Single Room", 85.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1155) },
                    { 2, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1162), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 2, "Double Room", 90.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1163) },
                    { 3, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1169), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 3, "Deluxed Room", 100.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1170) },
                    { 4, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1177), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 4, "Queens Room", 120.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1178) },
                    { 5, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1184), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 5, "Kings Room", 130.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1185) },
                    { 6, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1191), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 10, "Executive Suite", 100.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1192) },
                    { 7, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1197), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 10, "Super Deluxed", 110.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1198) },
                    { 8, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1204), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 10, "Diamond Room", 87.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1205) },
                    { 9, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1210), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "https://placehold.co/600x400/png", 10, "Emerald Deluxed", 98.0, new DateTime(2024, 4, 19, 15, 9, 30, 302, DateTimeKind.Local).AddTicks(1211) }
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
                    { 5, 5, 1 },
                    { 6, 3, 2 },
                    { 7, 1, 2 },
                    { 8, 5, 3 },
                    { 9, 3, 4 },
                    { 10, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "tbl_RoomNumber",
                columns: new[] { "ROOM_NUMBER", "DESCRIPTION", "ROOM_ID" },
                values: new object[,]
                {
                    { 101, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor.", 1 },
                    { 102, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 1 },
                    { 103, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 1 },
                    { 104, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 1 },
                    { 201, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 2 },
                    { 202, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 2 },
                    { 203, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 2 },
                    { 204, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 2 },
                    { 301, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 3 },
                    { 302, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 3 },
                    { 303, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 3 },
                    { 304, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 3 },
                    { 401, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 4 },
                    { 402, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 4 },
                    { 403, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 4 },
                    { 501, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 5 },
                    { 502, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 5 },
                    { 503, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 5 },
                    { 601, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 6 },
                    { 602, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed finibus sed purus consequat porta.Praesent vitae tincidunt dolor.", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
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
                name: "IX_tbl_RoomAmenity_ROOM_ID",
                table: "tbl_RoomAmenity",
                column: "ROOM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoomNumber_ROOM_ID",
                table: "tbl_RoomNumber",
                column: "ROOM_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbl_Booking");

            migrationBuilder.DropTable(
                name: "tbl_RoomAmenity");

            migrationBuilder.DropTable(
                name: "tbl_RoomNumber");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbl_Amenity");

            migrationBuilder.DropTable(
                name: "tbl_Rooms");
        }
    }
}
