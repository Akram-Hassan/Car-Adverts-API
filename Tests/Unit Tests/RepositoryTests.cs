﻿using DAL;
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
        public void TestRepositoryGetFirst()
        {
            var id = repository.GetAll().FirstOrDefault()?.ID;
            Assert.That(id, Is.EqualTo(1));
        }
    }
}
