using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        private Advert[] adverts = {
            new Advert {ID = 1 , Title = "New Disesel Car Advert" , Fuel = FuelType.Diesel , New = true},
            new Advert {ID = 2 , Title = "New Gasoline Car Advert" , Fuel = FuelType.Gasoline , New = true}
        };

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Advert> Adverts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advert>().HasData(adverts);
        }
    }
}
