using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenityOnlyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AmenityOnly");

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9841), new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9842) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9848), new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9857), new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9858) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9864), new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9865) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9870), new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9871) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9877), new DateTime(2024, 3, 25, 20, 42, 0, 116, DateTimeKind.Local).AddTicks(9878) });
        }
    }
}
