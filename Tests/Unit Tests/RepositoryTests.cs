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
    class RepositoryTests : TestBase
    {
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

        [Test]
        public void TestEdit()
        {
            var advert = repository.GetById(3);
            advert.Title = "Modified Title";
            advert.FirstRegistration = new DateTime(2017, 12, 01);

            repository.Update(advert);

            var modifiedAdvert = repository.GetById(3);

            Assert.That(modifiedAdvert.Title, Is.EqualTo("Modified Title"));
            Assert.That(modifiedAdvert.FirstRegistration, Is.EqualTo(new DateTime(2017, 12, 01)));
        }

        [Test]
        public void TestDelete()
        {
            var advert = repository.GetById(3);

            repository.Delete(advert);

            var modifiedAdvert = repository.GetById(3);

            Assert.That(modifiedAdvert, Is.Null);
        }
    }
}
