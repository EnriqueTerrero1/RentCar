using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class VehiculeModel
    {
        
        public Guid id { get; set; }
        public Brand brand { get; set; }

        public string description { get; set; }

        public bool status { get; set; }
    }
}
