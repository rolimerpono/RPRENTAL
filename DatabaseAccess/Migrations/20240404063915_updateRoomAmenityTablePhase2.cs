using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateRoomAmenityTablePhase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1573), new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1574) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1581), new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1582) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1588), new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1589) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1595), new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1596) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1602), new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1609), new DateTime(2024, 4, 4, 19, 39, 14, 847, DateTimeKind.Local).AddTicks(1610) });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoomAmenity_AMENITY_ID",
                table: "tbl_RoomAmenity",
                column: "AMENITY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_RoomAmenity_tbl_Amenity_AMENITY_ID",
                table: "tbl_RoomAmenity",
                column: "AMENITY_ID",
                principalTable: "tbl_Amenity",
                principalColumn: "AMENITY_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_RoomAmenity_tbl_Amenity_AMENITY_ID",
                table: "tbl_RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_tbl_RoomAmenity_AMENITY_ID",
                table: "tbl_RoomAmenity");

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6086), new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6093), new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6094) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6100), new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6101) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6107), new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6108) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6114), new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6115) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6120), new DateTime(2024, 4, 4, 16, 28, 25, 431, DateTimeKind.Local).AddTicks(6121) });
        }
    }
}
