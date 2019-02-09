using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public enum FuelType
    {
        Gasoline,
        Diesel
    }
    public class Advert
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public FuelType Fuel { get; set; }

        public bool New { get; set; }

        private int? milage;
        public int? Mileage
        {
            get => milage;
            set
            {
                if (value != null && New == true)
                {
                    throw new InvalidOperationException("New adverts cannot have milage");
                }
                milage = value;
            }
        }


        private DateTime? firstRegistration;
        public DateTime? FirstRegistration {
            get => firstRegistration;
            set
            {
                if (value != null && New == true)
                {
                    throw new InvalidOperationException("New adverts cannot have first registration date");
                }
                firstRegistration = value;
            }
        }
    }
}
