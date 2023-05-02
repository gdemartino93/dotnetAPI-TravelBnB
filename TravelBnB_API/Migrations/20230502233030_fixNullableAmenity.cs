using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBnB_API.Migrations
{
    /// <inheritdoc />
    public partial class fixNullableAmenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 30, 30, 402, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 193,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 30, 30, 402, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 30, 30, 402, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 30, 30, 402, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 30, 30, 402, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 30, 30, 402, DateTimeKind.Local).AddTicks(6456));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 30, 30, 402, DateTimeKind.Local).AddTicks(6460));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 25, 26, 68, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 193,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 25, 26, 68, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 25, 26, 68, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 25, 26, 68, DateTimeKind.Local).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 25, 26, 68, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 25, 26, 68, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 3, 1, 25, 26, 68, DateTimeKind.Local).AddTicks(310));
        }
    }
}
