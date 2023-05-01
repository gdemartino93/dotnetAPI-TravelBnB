using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBnB_API.Migrations
{
    /// <inheritdoc />
    public partial class fixtableaptno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VillaNo",
                table: "ApartmentNumbers",
                newName: "AptNo");

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 25, 9, 310, DateTimeKind.Local).AddTicks(3274));

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 193,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 25, 9, 310, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 25, 9, 310, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 25, 9, 310, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 25, 9, 310, DateTimeKind.Local).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 25, 9, 310, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 25, 9, 310, DateTimeKind.Local).AddTicks(3152));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AptNo",
                table: "ApartmentNumbers",
                newName: "VillaNo");

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "VillaNo",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "VillaNo",
                keyValue: 193,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1581));
        }
    }
}
