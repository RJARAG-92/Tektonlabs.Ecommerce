using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;

namespace Tektonlabs.Ecommerce.Persistencia.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductsRepository Products { get; }

        public UnitOfWork(IProductsRepository products)
        {
            Products = products;

        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
