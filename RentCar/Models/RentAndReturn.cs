using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class RentAndReturn
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; }
        public Vehicule Vehicule { get; set; }
        public Client client { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime rentDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime returnDate { get; set; }
        
        public double costPerDay { get; set; }
    
        public int rentDays { get; set; }

        public string? comment { get; set; }

        public bool status { get; set; }


    }
}
