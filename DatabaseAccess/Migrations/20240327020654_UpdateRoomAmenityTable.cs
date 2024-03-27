using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomAmenityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_AmenityOnly_tbl_RoomAmenity_RoomAmenityID",
                table: "tbl_AmenityOnly");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Rooms_tbl_RoomAmenity_RoomAmenityID",
                table: "tbl_Rooms");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Rooms_RoomAmenityID",
                table: "tbl_Rooms");

            migrationBuilder.DropIndex(
                name: "IX_tbl_AmenityOnly_RoomAmenityID",
                table: "tbl_AmenityOnly");

            migrationBuilder.DropColumn(
                name: "RoomAmenityID",
                table: "tbl_Rooms");

            migrationBuilder.DropColumn(
                name: "RoomAmenityID",
                table: "tbl_AmenityOnly");

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7908), new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7923), new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7925) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7937), new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7951), new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7964), new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7966) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7978), new DateTime(2024, 3, 27, 15, 6, 53, 890, DateTimeKind.Local).AddTicks(7980) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomAmenityID",
                table: "tbl_Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomAmenityID",
                table: "tbl_AmenityOnly",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tbl_AmenityOnly",
                keyColumn: "ID",
                keyValue: 1,
                column: "RoomAmenityID",
                value: null);

            migrationBuilder.UpdateData(
                table: "tbl_AmenityOnly",
                keyColumn: "ID",
                keyValue: 2,
                column: "RoomAmenityID",
                value: null);

            migrationBuilder.UpdateData(
                table: "tbl_AmenityOnly",
                keyColumn: "ID",
                keyValue: 3,
                column: "RoomAmenityID",
                value: null);

            migrationBuilder.UpdateData(
                table: "tbl_AmenityOnly",
                keyColumn: "ID",
                keyValue: 4,
                column: "RoomAmenityID",
                value: null);

            migrationBuilder.UpdateData(
                table: "tbl_AmenityOnly",
                keyColumn: "ID",
                keyValue: 5,
                column: "RoomAmenityID",
                value: null);

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "RoomAmenityID", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1211), null, new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "RoomAmenityID", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1219), null, new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "RoomAmenityID", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1227), null, new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1228) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "RoomAmenityID", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1235), null, new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1236) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "RoomAmenityID", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1242), null, new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1243) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "RoomAmenityID", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1249), null, new DateTime(2024, 3, 27, 11, 43, 49, 394, DateTimeKind.Local).AddTicks(1250) });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Rooms_RoomAmenityID",
                table: "tbl_Rooms",
                column: "RoomAmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AmenityOnly_RoomAmenityID",
                table: "tbl_AmenityOnly",
                column: "RoomAmenityID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_AmenityOnly_tbl_RoomAmenity_RoomAmenityID",
                table: "tbl_AmenityOnly",
                column: "RoomAmenityID",
                principalTable: "tbl_RoomAmenity",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Rooms_tbl_RoomAmenity_RoomAmenityID",
                table: "tbl_Rooms",
                column: "RoomAmenityID",
                principalTable: "tbl_RoomAmenity",
                principalColumn: "ID");
        }
    }
}
