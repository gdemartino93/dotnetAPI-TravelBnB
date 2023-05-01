using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBnB_API.Migrations
{
    /// <inheritdoc />
    public partial class fixDtoAptNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 50, 32, 799, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 193,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 50, 32, 799, DateTimeKind.Local).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 50, 32, 799, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 50, 32, 799, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 50, 32, 799, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 50, 32, 799, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 23, 50, 32, 799, DateTimeKind.Local).AddTicks(3018));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
