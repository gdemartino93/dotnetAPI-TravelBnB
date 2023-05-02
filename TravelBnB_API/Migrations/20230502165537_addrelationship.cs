using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBnB_API.Migrations
{
    /// <inheritdoc />
    public partial class addrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "ApartmentNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 12,
                columns: new[] { "ApartmentId", "CreatedDate" },
                values: new object[] { 0, new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(8107) });

            migrationBuilder.UpdateData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 193,
                columns: new[] { "ApartmentId", "CreatedDate" },
                values: new object[] { 0, new DateTime(2023, 5, 2, 18, 55, 37, 893, DateTimeKind.Local).AddTicks(8111) });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentNumbers_ApartmentId",
                table: "ApartmentNumbers",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentNumbers_Apartments_ApartmentId",
                table: "ApartmentNumbers",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentNumbers_Apartments_ApartmentId",
                table: "ApartmentNumbers");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentNumbers_ApartmentId",
                table: "ApartmentNumbers");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "ApartmentNumbers");

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
    }
}
