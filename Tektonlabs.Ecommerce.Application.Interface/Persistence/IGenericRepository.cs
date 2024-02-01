using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tektonlabs.Ecommerce.Application.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T> GetAsync(int id);
       
    }
}
