using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomAmenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_AmenityOnly_tbl_RoomAmenity_RoomAmenityID",
                table: "tbl_AmenityOnly");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Rooms_tbl_RoomAmenity_RoomAmenityID",
                table: "tbl_Rooms");

            migrationBuilder.DropTable(
                name: "tbl_RoomAmenity");

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
                values: new object[] { new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8818), new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8820) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8826), new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8827) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8834), new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8835) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8841), new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8847), new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8848) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8853), new DateTime(2024, 3, 25, 20, 46, 7, 655, DateTimeKind.Local).AddTicks(8854) });
        }
    }
}
