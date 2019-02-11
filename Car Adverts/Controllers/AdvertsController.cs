using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Adverts.ViewModels;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_Adverts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly Repository repository;

        public AdvertsController(Repository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<AdvertVM> Get() 
            => repository.GetAll().Select(a => Map(a));



        private AdvertVM Map(Advert advert)
            => new AdvertVM
            {
                Title = advert.Title,
                Fuel = advert.Fuel,
                New = advert.New,
                Mileage = advert.Mileage,
                FirstRegistration = advert.FirstRegistration
            };
    }
}