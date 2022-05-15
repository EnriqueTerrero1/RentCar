using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RentCar.Models
{
    public class RentCarDBcontext:DbContext
    {

       
            public DbSet<Brand> brands { get; set; }
            public DbSet<Client> clients { get; set; }
            public DbSet<Employee> employees { get; set; }
            public DbSet<Fuel_Type> fuel_Types { get; set; }
        public DbSet<Inspection> inspections { get; set; }
        public DbSet<RentAndReturn> rentAndReturns { get; set; }
        public DbSet<Vehicule> vehicules { get; set; }
        public DbSet<Vehicule_Type> vehicule_Types { get; set; }
        public DbSet<VehiculeModel> vehiculemodels { get; set; }

        public RentCarDBcontext(DbContextOptions<RentCarDBcontext> options)
                 : base(options)
        {
           
        }









    }
}
