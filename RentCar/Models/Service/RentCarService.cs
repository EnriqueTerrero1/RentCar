using Microsoft.EntityFrameworkCore;
using RentCar.Models.Interface;

namespace RentCar.Models.Service
{
    public class RentCarService<T>: IRentCar<T> where T : class
    {
        private readonly RentCarDBcontext dbcontext;
        private readonly DbSet<T> table;

        public RentCarService(RentCarDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
            table= dbcontext.Set<T>();
        }
      public  async Task<bool> CreateAsync(T entity)      
        {

            table.Add(entity);
            var saveResult = await dbcontext.SaveChangesAsync();
            return saveResult == 1;
        }
        public T[] GetAll()
        {

            var entitys =  table.ToArray() ;
            return entitys;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            table.Attach(entity);
            dbcontext.Entry(entity).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id){

            var entity = table.Find(id);
            table.Remove(entity);
            var saveResult = await dbcontext.SaveChangesAsync();
            return saveResult == 1;

        }







    }
}
