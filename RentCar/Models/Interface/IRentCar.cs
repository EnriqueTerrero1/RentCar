namespace RentCar.Models.Interface
{
  public  interface  IRentCar
    {
       Task<bool> CreateAsync (Vehicule_Type vehicule_Type);
        Task<Vehicule_Type[]> GetAllAsync();
       // Task<T> UpdateAsync (T entity);
       Task<bool> DeleteAsync (Guid id);




    }
}
