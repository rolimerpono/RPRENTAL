using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(706), new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(707) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(714), new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(715) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(721), new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(722) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 4,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(728), new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(729) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 5,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(735), new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(736) });

            migrationBuilder.UpdateData(
                table: "tbl_Rooms",
                keyColumn: "ROOM_ID",
                keyValue: 6,
                columns: new[] { "CREATED_DATE", "UPDATED_DATE" },
                values: new object[] { new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(742), new DateTime(2024, 3, 25, 20, 39, 56, 391, DateTimeKind.Local).AddTicks(743) });
        }
    }
}
