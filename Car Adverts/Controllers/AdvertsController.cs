using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
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

        public IEnumerable<string> Get()
        {
            return repository.GetAll().Select(x => x.Title);
        }
    }
}