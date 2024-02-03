namespace Tektonlabs.Ecommerce.Application.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T> GetAsync(int id);
    }
}
