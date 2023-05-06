using Microsoft.EntityFrameworkCore;
using TravelBnB_API.Models;

namespace TravelBnB_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentNumber> ApartmentNumbers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            //modelBuilder.Entity<Apartment>().HasData(
            //    new Apartment()
            //    {
            //        Id = 1,
            //        Name = "Casa David",
            //        Details = "Questo appartamento si trova in una posizione panoramica con vista sulla città.",
            //        Amenity = "Parcheggio gratuito, Wi-Fi gratuito",
            //        ImageUrl = "https://esempio.com/immagine1.jpg",
            //        Mq2 = 80,
            //        Occupancy = 4,
            //        Rate = 5,
            //        CreatedDate = DateTime.Now,
            //    },
            //    new Apartment()
            //    {
            //        Id = 2,
            //        Name = "Appartamento Sofia",
            //        Details = "Appartamento moderno nel cuore del centro città.",
            //        Amenity = "Aria condizionata, Accesso per disabili",
            //        ImageUrl = "https://esempio.com/immagine2.jpg",
            //        Mq2 = 60,
            //        Occupancy = 3,
            //        Rate = 4,
            //        CreatedDate = DateTime.Now,
            //    },
            //    new Apartment()
            //    {
            //        Id = 3,
            //        Name = "Villa Maria",
            //        Details = "Villa spaziosa con piscina privata e giardino.",
            //        Amenity = "Piscina, Giardino, Cucina completamente attrezzata",
            //        ImageUrl = "https://esempio.com/immagine3.jpg",
            //        Mq2 = 150,
            //        Occupancy = 8,
            //        Rate = 5,
            //        CreatedDate = DateTime.Now,
            //    },
            //    new Apartment()
            //    {
            //        Id = 4,
            //        Name = "Monolocale Giovanni",
            //        Details = "Monolocale accogliente vicino al mare.",
            //        Amenity = "TV via cavo, Cucinino, Balcone con vista mare",
            //        ImageUrl = "https://esempio.com/immagine4.jpg",
            //        Mq2 = 30,
            //        Occupancy = 2,
            //        Rate = 3,
            //        CreatedDate = DateTime.Now,
            //    },
            //    new Apartment()
            //    {
            //        Id = 5,
            //        Name = "Appartamento Rosa",
            //        Details = "Appartamento colorato con arredamento moderno.",
            //        Amenity = "Palestra, Terrazza, Lavatrice",
            //        ImageUrl = "https://esempio.com/immagine5.jpg",
            //        Mq2 = 70,
            //        Occupancy = 4,
            //        Rate = 4,
            //        CreatedDate = DateTime.Now,
            //    }
            //    );
            //modelBuilder.Entity<ApartmentNumber>().HasData(
            //    new ApartmentNumber() { AptNo = 12, CreatedDate = DateTime.Now, SpecialDetails = " parcheggio gratuito" },
            //    new ApartmentNumber() { AptNo = 193, CreatedDate = DateTime.Now , SpecialDetails = "piscina coperta"}
            // );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
