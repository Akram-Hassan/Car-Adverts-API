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

        [HttpGet()]
        public IEnumerable<AdvertVM> Get() 
            => repository.GetAll().Select(a => MapToViewModel(a));

        private AdvertVM MapToViewModel(Advert advert)
            => new AdvertVM
            {
                Id = advert.Id,
                Title = advert.Title,
                Fuel = advert.Fuel,
                New = advert.New,
                Mileage = advert.Mileage,
                FirstRegistration = advert.FirstRegistration
            };

        private Advert Map(AdvertVM advert)
            => new Advert
            {
                Id = advert.Id,
                Title = advert.Title,
                Fuel = advert.Fuel,
                New = advert.New,
                Mileage = advert.Mileage,
                FirstRegistration = advert.FirstRegistration
            };


        [HttpGet("{id}")]
        public AdvertVM Get([FromRoute]int id)
            => MapToViewModel( repository.GetById(id) );

        [HttpPost]
        public IActionResult Post([FromBody] AdvertVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advert = Map(viewModel);
            repository.Add(advert);

            return CreatedAtAction("Get", new { id = advert.Id }, advert);
        }
    }
}