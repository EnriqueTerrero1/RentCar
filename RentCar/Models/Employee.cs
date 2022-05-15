namespace RentCar.Models
{
    public class Employee
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public int identificationCard { get; set; }
        public string workingTime { get; set; }
        public double CommissionPercentage { get; set; }
        public DateTime datedateOfAdmission { get; set; }
        public bool status { get; set; }


    }
}
