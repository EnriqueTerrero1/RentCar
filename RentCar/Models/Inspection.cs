namespace RentCar.Models
{
    public class Inspection
    {
        public Guid id { get; set; }
        public Vehicule vehicule { get; set; }
        public Client client { get; set; }

        public bool scratch { get; set; }

        public string amountOfFuel { get; set; }

        public bool replacementTire { get; set; }
        public bool jack { get; set; }

        public bool glassBreaked { get; set; }

        public DateTime date { get; set; }
        public Employee employee { get; set; }
        public bool status { get; set; }





    }
}
