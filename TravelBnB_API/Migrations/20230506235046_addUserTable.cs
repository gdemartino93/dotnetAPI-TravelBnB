using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelBnB_API.Migrations
{
    /// <inheritdoc />
    public partial class addUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ApartmentNumbers",
                keyColumn: "AptNo",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.InsertData(
                table: "ApartmentNumbers",
                columns: new[] { "AptNo", "ApartmentId", "CreatedDate", "SpecialDetails", "UpdatedDate" },
                values: new object[,]
                {
                    { 12, 0, new DateTime(2023, 5, 3, 19, 25, 48, 338, DateTimeKind.Local).AddTicks(5563), " parcheggio gratuito", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 193, 0, new DateTime(2023, 5, 3, 19, 25, 48, 338, DateTimeKind.Local).AddTicks(5568), "piscina coperta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Mq2", "Name", "Occupancy", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Parcheggio gratuito, Wi-Fi gratuito", new DateTime(2023, 5, 3, 19, 25, 48, 338, DateTimeKind.Local).AddTicks(5307), "Questo appartamento si trova in una posizione panoramica con vista sulla città.", "https://esempio.com/immagine1.jpg", 80, "Casa David", 4, 5.0, null },
                    { 2, "Aria condizionata, Accesso per disabili", new DateTime(2023, 5, 3, 19, 25, 48, 338, DateTimeKind.Local).AddTicks(5364), "Appartamento moderno nel cuore del centro città.", "https://esempio.com/immagine2.jpg", 60, "Appartamento Sofia", 3, 4.0, null },
                    { 3, "Piscina, Giardino, Cucina completamente attrezzata", new DateTime(2023, 5, 3, 19, 25, 48, 338, DateTimeKind.Local).AddTicks(5368), "Villa spaziosa con piscina privata e giardino.", "https://esempio.com/immagine3.jpg", 150, "Villa Maria", 8, 5.0, null },
                    { 4, "TV via cavo, Cucinino, Balcone con vista mare", new DateTime(2023, 5, 3, 19, 25, 48, 338, DateTimeKind.Local).AddTicks(5372), "Monolocale accogliente vicino al mare.", "https://esempio.com/immagine4.jpg", 30, "Monolocale Giovanni", 2, 3.0, null },
                    { 5, "Palestra, Terrazza, Lavatrice", new DateTime(2023, 5, 3, 19, 25, 48, 338, DateTimeKind.Local).AddTicks(5376), "Appartamento colorato con arredamento moderno.", "https://esempio.com/immagine5.jpg", 70, "Appartamento Rosa", 4, 4.0, null }
                });
        }
    }
}
