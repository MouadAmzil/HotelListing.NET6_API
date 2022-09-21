namespace HotelListing.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<T> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync (T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists (int id);
    }
}
