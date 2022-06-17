using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Models
{
    public class Vehicule
    {
        
        public Guid id { get; set; }
        public string description { get; set; }
        public int chasisNumber { get; set; }
        public int motorNumber { get; set; }

        public int plateNumber { get; set; }
        

        public Vehicule_Type vehicule_Type { get; set; }

        public Brand brand { get; set; }
        public VehiculeModel model { get; set; }
        public  Fuel_Type fuel_type { get; set; }

        public bool status { get; set; }


    }
}
