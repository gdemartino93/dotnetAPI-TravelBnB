using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBnB_API.Migrations
{
    /// <inheritdoc />
    public partial class aptNotable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 22, 57, 14, 528, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 22, 57, 14, 528, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 22, 57, 14, 528, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 22, 57, 14, 528, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 22, 57, 14, 528, DateTimeKind.Local).AddTicks(1161));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 11, 29, 11, 255, DateTimeKind.Local).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 11, 29, 11, 255, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 11, 29, 11, 255, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 11, 29, 11, 255, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 11, 29, 11, 255, DateTimeKind.Local).AddTicks(1998));
        }
    }
}
