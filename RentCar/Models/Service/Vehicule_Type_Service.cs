using RentCar.Models.Interface;

using Microsoft.EntityFrameworkCore;
namespace RentCar.Models.Service
{
    public class Vehicule_Type_Service:IRentCar
    {
        private readonly RentCarDBcontext dbcontext;

        public Vehicule_Type_Service(RentCarDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
        }

        public async Task<bool> CreateAsync(Vehicule_Type vehicule_Type)
        {
            vehicule_Type.id = Guid.NewGuid();
           /* if ( vehicule_Type.status = "In stock")
            {
                vehicule_Type.status = true;
            }*/
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
        }
    }
}
