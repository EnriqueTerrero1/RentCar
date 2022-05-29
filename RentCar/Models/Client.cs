namespace RentCar.Models
{
    public class Client
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string identificationCard { get; set; }

        public int tarjetaCrNumber { get; set; }

        public double creditLimit { get; set; }
        public bool PersonKind { get; set; }
        public bool status { get; set; }


    }
}
