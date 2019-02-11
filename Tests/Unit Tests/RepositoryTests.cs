using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    class RepositoryTests
    {
        private Repository repository;
        private ApplicationDbContext context;


        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("Scout24Adverts")
            .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }

        [SetUp]
        public void SetUp()
        {
            context = CreateContext();
            repository = new Repository(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
            context = null;
            repository = null;
        }

        [Test]
        public void TestGetFirst()
        {
            var id = repository.GetAll().FirstOrDefault()?.ID;
            Assert.That(id, Is.EqualTo(1));
        }

        [Test]
        public void TestGetById()
        {
            var advertTwo = repository.GetById(2);
            Assert.That(advertTwo.ID, Is.EqualTo(2));
            Assert.That(advertTwo.Title, Is.EqualTo("New Gasoline Car Advert"));
        }

        [Test]
        public void TestAdd()
        {
            var newAdvert = new Advert { ID = 5 , Title = "Newly added advert", Fuel = FuelType.Diesel, New = true };

            repository.Add(newAdvert);

            var foundAdvert = repository.GetById(5);

            Assert.That(foundAdvert.Title, Is.EqualTo("Newly added advert"));
        }
    }
}
