namespace RentCar.Models
{
    public class Vehicule_Type
    {
       public  Guid id { get; set; }
        public string description { get; set; }

        public bool status { get; set; }

        internal void CreateAsync(Vehicule_Type vehicule_Type)
        {
            throw new NotImplementedException();
        }
    }
}
