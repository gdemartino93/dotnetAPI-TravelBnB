using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBnB_API.Migrations
{
    /// <inheritdoc />
    public partial class fixAptMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 193,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(8009));
        }
    }
}
