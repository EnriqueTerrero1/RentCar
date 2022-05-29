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
        public string chasisNumber { get; set; }
        public string motorNumber { get; set; }

        public string plateNumber { get; set; }

        public string vehicule_Type { get; set; }
        public string model { get; set; }
        public string fuel_type  { get; set; }

        public string name { get; set; }
        public string identificationCard { get; set; }
        public string tarjetaCrNumber { get; set; }
        public double creditLimit { get; set; }
        public string PersonKind { get; set; }
    }
}
