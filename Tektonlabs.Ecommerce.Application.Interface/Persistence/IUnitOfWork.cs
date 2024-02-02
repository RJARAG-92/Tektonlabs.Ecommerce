namespace Tektonlabs.Ecommerce.Application.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository Products { get; }

    }
}
