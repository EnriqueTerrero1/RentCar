using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class RentCarModelView
    {
        public Vehicule_Type[] vehicule_Types { get; set; }
        public Brand[] brands { get; set; }
        public VehiculeModel[] vehiculeModels { get; set; }
        public Fuel_Type[] fuel_Types { get; set; }
        public Vehicule[] vehicules { get; set; }
        public Client []    clients { get; set; }
        public Employee [] employees { get; set; }
        public Inspection [] inspections { get; set; }
        public RentAndReturn[] rentAndReturns { get; set; }

        public Guid id { get; set; }
        public string description { get; set; }

        public bool status { get; set; }
        public int contador { get; set; }
        public string brand { get; set; }
        public int chasisNumber { get; set; }
        public int motorNumber { get; set; }

        public int  plateNumber { get; set; }

        public string vehicule_Type { get; set; }
        public string model { get; set; }
        public string fuel_type  { get; set; }

        public string name { get; set; }
        public string identificationCard { get; set; }
        public string tarjetaCrNumber { get; set; }
        public double creditLimit { get; set; }
        public string PersonKind { get; set; }

        public string Employee { get; set; }
        public string Vehicule { get; set; }
        public string client { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime rentDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime returnDate { get; set; }

       public double costPerDay { get; set; }
        public int rentDays { get; set; }

        public string comment { get; set; }

        public string workingTime { get; set; }
        public double CommissionPercentage { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime datedateOfAdmission { get; set; }


    }
}
