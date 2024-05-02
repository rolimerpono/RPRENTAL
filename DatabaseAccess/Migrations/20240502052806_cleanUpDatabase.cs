using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class cleanUpDatabase : Migration
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
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Amenity", x => x.AmenityId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ResetPassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ResetPassword", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomPrice = table.Column<double>(type: "float", nullable: false),
                    MaxOccupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Rooms", x => x.RoomId);
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
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomNo = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckinDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CheckoutDate = table.Column<DateOnly>(type: "date", nullable: false),
                    NoOfStay = table.Column<int>(type: "int", nullable: false),
                    IsPaymentSuccessfull = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StripeSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripePaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualCheckinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualCheckoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualCancelledDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_tbl_Booking_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbl_Booking_tbl_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "tbl_Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoomAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoomAmenity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_RoomAmenity_tbl_Amenity_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "tbl_Amenity",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RoomAmenity_tbl_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "tbl_Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoomNumber",
                columns: table => new
                {
                    RoomNo = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoomNumber", x => x.RoomNo);
                    table.ForeignKey(
                        name: "FK_tbl_RoomNumber_tbl_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "tbl_Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_Amenity",
                columns: new[] { "AmenityId", "AmenityName" },
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
                columns: new[] { "RoomId", "CreatedDate", "Description", "ImageUrl", "MaxOccupancy", "RoomName", "RoomPrice", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4039), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Single.jpg", 1, "Single Room", 85.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4040) },
                    { 2, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4047), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Double.jpg", 2, "Double Room", 90.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4048) },
                    { 3, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4053), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Deluxed.jpg", 3, "Deluxed Room", 100.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4054) },
                    { 4, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4099), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Queens.jpg", 4, "Queens Room", 120.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4100) },
                    { 5, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4106), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Kings.jpg", 5, "Kings Room", 130.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4107) },
                    { 6, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4113), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Executive.jpg", 10, "Executive Suite", 100.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4114) },
                    { 7, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4119), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Super Deluxed.jpg", 10, "Super Deluxed", 110.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4120) },
                    { 8, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4126), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Diamond Room.jpg", 10, "Diamond Room", 87.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4127) },
                    { 9, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4133), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed finibus sed purus consequat porta. Praesent vitae tincidunt dolor, bibendum lacinia urna.", "\\img\\Rooms\\Emerald Room.jpg", 10, "Emerald Deluxed", 98.0, new DateTime(2024, 5, 2, 17, 28, 5, 919, DateTimeKind.Local).AddTicks(4134) }
                });

            migrationBuilder.InsertData(
                table: "tbl_RoomAmenity",
                columns: new[] { "Id", "AmenityId", "RoomId" },
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
                columns: new[] { "RoomNo", "Description", "RoomId" },
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
                name: "IX_tbl_Booking_RoomId",
                table: "tbl_Booking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Booking_UserId",
                table: "tbl_Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoomAmenity_AmenityId",
                table: "tbl_RoomAmenity",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoomAmenity_RoomId",
                table: "tbl_RoomAmenity",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoomNumber_RoomId",
                table: "tbl_RoomNumber",
                column: "RoomId");
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
                name: "tbl_ResetPassword");

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
