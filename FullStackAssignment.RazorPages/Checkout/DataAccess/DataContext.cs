using Checkout.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Checkout.DataAccess
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            var cnn = new SqliteConnection("Filename=:memory:");
            cnn.Open();
            optionsBuilder.UseSqlite(cnn);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>()
                .ToTable("Offers");

            modelBuilder.Entity<Offer>().HasData(
                new Offer
                {
                    Id = 1,
                    Price = 159,
                    Name = "10 nr 159 kr, spara 61%",
                    ExtraInfo = "Detta erbjudande gäller t.o.m. 15/2 eller så långt lagret räcker.",
                    ProductId = 2
                },
                new Offer
                {
                    Id = 2,
                    Price = 299,
                    Name = "20 nr 299 kr, spara 63%",
                    ExtraInfo = "Detta erbjudande gäller t.o.m. 25/2 eller så långt lagret räcker.",
                    ProductId = 2
                },
                new Offer
                {
                    Id = 3,
                    Price = 279,
                    Name = "7 nr 279 kr, spar 60%",
                    ProductId = 4
                },
                new Offer
                {
                    Id = 4,
                    Price = 529,
                    Name = "13 nr 529 kr, spar 78%",
                    ExtraInfo = "+ Premie: Secrets by B øreringer",
                    ProductId = 4
                },
                new Offer
                {
                    Id = 5,
                    Price = 999,
                    Name = "26 nr 999 kr, spar 73%",
                    ExtraInfo = "+ Premie: Stelton Hurricane lyslykt",
                    ProductId = 4
                },
                new Offer
                {
                    Id = 6,
                    Price = 39,
                    Name = "24 nro 39 €, säästä 46%",
                    ProductId = 6
                });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Allers",
                Description = "Sveriges största veckotidning ger dig glädje och inspiration, varje vecka.",
                ImageUrl = "https://bilder.tidningskungen.se/upl/normal500/allers-6-2024.jpg",
                Country = Country.Sweden
            }, new Product
            {
                Id = 4,
                Name = "KK",
                Description = "KK er bladet som gir norske kvinner inspirasjon, underholdning og gode tips til hverdagen.",
                ImageUrl = "https://bilder.bladkongen.no/upl/normal500/kk-19-2022.jpg",
                Country = Country.Norway
            }, new Product
            {
                Id = 6,
                Name = "Kotiliesi",
                Description = "Kotiliesi on rakastettu naistenlehti, joka tuo iloa ja väriä arkeen.",
                ImageUrl = "https://images.tidningskungen.se/upl/normal500/kotiliesi-10-2023.jpg",
                Country = Country.Finland
            });
        }
    }
}
