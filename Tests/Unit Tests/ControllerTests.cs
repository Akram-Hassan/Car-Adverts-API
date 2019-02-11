using Car_Adverts.Controllers;
using DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    public class ControllerTests
    {
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

        private AdvertsController controller;
        private Repository repository;
        private ApplicationDbContext context;

        [SetUp]
        public void SetUp()
        {
            context = CreateContext();
            repository = new Repository(context);
            controller = new AdvertsController(repository);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
            context = null;
            repository = null;
        }

        [Test]
        public void TestDefaultAction()
        {
            var advert = controller.Get().FirstOrDefault();
            Assert.That(advert.Title, Is.EqualTo("New Disesel Car Advert"));
        }
    }
}
