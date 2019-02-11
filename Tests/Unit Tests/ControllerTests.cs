using Car_Adverts.Controllers;
using Car_Adverts.ViewModels;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    public class ControllerTests : TestBase 
    {

        private AdvertsController controller;

        [SetUp]
        public void Setup()
        {
            controller = new AdvertsController(repository);
        }

        [Test]
        public void TestDefaultAction()
        {
            var advert = controller.Get().FirstOrDefault();
            Assert.That(advert.Title, Is.EqualTo("New Disesel Car Advert"));
        }

        [Test]
        public void TestGetById()
        {
            var advert = controller.Get(3);

            Assert.That(advert.Title, Is.EqualTo("Used Diesel Car Advert"));
            Assert.That(advert.FirstRegistration, Is.EqualTo(new DateTime(2015, 01, 01)));
        }

        [Test]
        public void TestInsertValidModel()
        {
            AdvertVM newAdvertVM = new AdvertVM
            {
                Id = 10,
                Title = "New Advert",
                Fuel = FuelType.Diesel,
                New = false,
                Mileage = 3000,
                FirstRegistration = DateTime.Today.AddYears(-10)
            };

            var actionResult = controller.Post(newAdvertVM) as CreatedAtActionResult;

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.StatusCode, Is.EqualTo(201));
        }
    }
}
