using Moq; 
using Tektonlabs.Ecommerce.Application.Interface.Persistence;

namespace Tektonlabs.Ecommerce.Application.Test.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockProductsRepo = MockProductsRepository.GetProductsRepository();

            mockUow.Setup(r => r.Products).Returns(mockProductsRepo.Object);

            return mockUow;
        }
    }
}