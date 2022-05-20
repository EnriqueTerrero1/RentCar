using RentCar.Models.Interface;

using Microsoft.EntityFrameworkCore;
namespace RentCar.Models.Service
{
    public class Vehicule_Type_Service 
    {
        private readonly RentCarDBcontext dbcontext;
        private readonly IRentCar<Vehicule_Type> vehicule_Type;
        public Vehicule_Type_Service(IRentCar<Vehicule_Type> vehicule_Type)
        {
            this.vehicule_Type = vehicule_Type;
        }
        
        //public async task create(Vehicule_Type vehicule_Type)
        //{
          //  vehicule_Type.CreateAsync(vehicule_Type);
        //}

       
        
       
       









        /* public Vehicule_Type_Service()
        {
           // this.dbcontext = dBcontext;
           //this.entity = vehicule_Type;
        }

        Vehicule_Type vehicule = new Vehicule_Type();
        

        public async Task<bool> CreateAsync(Vehicule_Type vehicule_Type)
         {
             vehicule_Type.id = Guid.NewGuid();

             dbcontext.vehicule_Types.Add(vehicule_Type);
             var saveResult = await dbcontext.SaveChangesAsync();    
             return saveResult==1;

         }

         public async Task<Vehicule_Type[]> GetAllAsync()
         {

            var vehicule_Types = await dbcontext.vehicule_Types.ToArrayAsync();
             return vehicule_Types;
         }

        public async Task<bool> DeleteAsync(Guid id)
         {

             var vehicule_type1= dbcontext.vehicule_Types.Where(x => x.id==id).FirstOrDefault();
             dbcontext.vehicule_Types.Remove(vehicule_type1);
             var saveResult = await dbcontext.SaveChangesAsync();
             return saveResult == 1;
         }*/
       
    }
}
