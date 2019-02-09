using DAL.Entities;
using NUnit.Framework;
using System;

namespace Tests
{
    public class UnitTests
    {
        [Test]
        public void CreatedAdvertCannotHaveMileage()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>()
                    .And.Message.EqualTo("New adverts cannot have milage"),
                    () =>
                        new Advert { New = true, Mileage = 10 }
                    );
        }

        [Test]
        public void ChangedAdvertCannotHaveMileage()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>()
                    .And.Message.EqualTo("New adverts cannot have milage"),
                    delegate {
                        var advert = new Advert { New = true };
                        advert.Mileage = 10; 
                    });
        }

        [Test]
        public void CreatedAdvertCannotHaveRegistrationDate()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>()
                    .And.Message.EqualTo("New adverts cannot have first registration date"),
                    () =>
                        new Advert { New = true, FirstRegistration = DateTime.Today }
                    );
        }

        [Test]
        public void ChangedAdvertCannotHaveRegistrationDate()
        {
            Assert.Throws(Is.TypeOf<InvalidOperationException>()
                    .And.Message.EqualTo("New adverts cannot have first registration date"),
                    delegate {
                        var advert = new Advert { New = true };
                        advert.FirstRegistration = DateTime.Today;
                    });
        }
    }
}