using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tektonlabs.Ecommerce.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository Products { get; }
    }
}
