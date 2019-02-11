using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Adverts.ViewModels
{
    public class AdvertVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public FuelType Fuel { get; set; }
        public bool New { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int? Mileage { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FirstRegistration { get; set; }
    }
}
