using System;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        private Advert[] seedAdverts = {
            new Advert {ID = 1 , Title = "New Disesel Car Advert" , Fuel = FuelType.Diesel , New = true},
            new Advert {ID = 2 , Title = "New Gasoline Car Advert" , Fuel = FuelType.Gasoline , New = true},
            new Advert {ID = 3 , Title = "Used Diesel Car Advert" , Fuel = FuelType.Diesel , New = false , Mileage = 30 , FirstRegistration = new DateTime(2015,01,01)},
            new Advert {ID = 4 , Title = "Used Gasoline Car Advert" , Fuel = FuelType.Gasoline , New = false , Mileage = 45 , FirstRegistration = new DateTime(2010,05,01)}
        };

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Advert> Adverts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advert>().HasData(seedAdverts);
        }
    }
}
