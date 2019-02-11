using Car_Adverts.Controllers;
using DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace UnitTests
{
    public class TestBase
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

        protected Repository repository;
        protected ApplicationDbContext context;

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
    }
}