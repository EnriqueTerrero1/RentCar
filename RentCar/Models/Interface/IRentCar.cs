namespace RentCar.Models.Interface
{
  public  interface  IRentCar<T> where T: class
    {

        Task<bool> CreateAsync(T entity);
    
        T[] GetAll();

       Task<bool> UpdateAsync (T entity);
      Task<bool> DeleteAsync (Guid id);




    }
}
