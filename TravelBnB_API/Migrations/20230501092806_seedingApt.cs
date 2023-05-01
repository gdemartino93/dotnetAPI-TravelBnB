using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelBnB_API.Migrations
{
    /// <inheritdoc />
    public partial class seedingApt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Mq2", "Name", "Occupancy", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Parcheggio gratuito, Wi-Fi gratuito", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Questo appartamento si trova in una posizione panoramica con vista sulla città.", "https://esempio.com/immagine1.jpg", 80, "Casa David", 4, 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Aria condizionata, Accesso per disabili", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Appartamento moderno nel cuore del centro città.", "https://esempio.com/immagine2.jpg", 60, "Appartamento Sofia", 3, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Piscina, Giardino, Cucina completamente attrezzata", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Villa spaziosa con piscina privata e giardino.", "https://esempio.com/immagine3.jpg", 150, "Villa Maria", 8, 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "TV via cavo, Cucinino, Balcone con vista mare", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monolocale accogliente vicino al mare.", "https://esempio.com/immagine4.jpg", 30, "Monolocale Giovanni", 2, 3.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Palestra, Terrazza, Lavatrice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Appartamento colorato con arredamento moderno.", "https://esempio.com/immagine5.jpg", 70, "Appartamento Rosa", 4, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
