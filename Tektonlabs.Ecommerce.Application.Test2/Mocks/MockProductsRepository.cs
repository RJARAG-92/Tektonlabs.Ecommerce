using Moq; 
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Domain.Entities;
using Tektonlabs.Ecommerce.Domain.Enums;

namespace Tektonlabs.Ecommerce.Application.Test.Mocks
{
    public static class MockProductsRepository
    {
        public static Mock<IProductsRepository> GetProductsRepository()
        {
            var products=new List<Product>() { 
                new Product()
                {
                    ProductId=1,
                    Name="Producto 1",
                    Moneda=TipoMoneda.USD,

                },
                 new Product()
                {
                    ProductId=2,
                    Name="Producto 2",
                    Moneda=TipoMoneda.PEN,

                }
            };
            var mockRepo = new Mock<IProductsRepository>();


            mockRepo.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync(products.First(x => x.ProductId == 1));

            mockRepo.Setup(r => r.InsertAsync(It.IsAny<Product>())).ReturnsAsync((Product product) =>
            {
                products.Add(product);
                return product;
            });

            return mockRepo;
        }
    }
}
