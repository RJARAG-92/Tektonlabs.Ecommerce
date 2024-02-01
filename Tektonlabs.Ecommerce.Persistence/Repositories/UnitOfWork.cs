using Tektonlabs.Ecommerce.Application.Interface.Persistence;

namespace Tektonlabs.Ecommerce.Persistence.Repositories
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
