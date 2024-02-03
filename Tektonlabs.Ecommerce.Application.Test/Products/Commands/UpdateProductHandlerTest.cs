using AutoMapper;
using Moq;
using Shouldly;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Application.Test.Mocks;
using Tektonlabs.Ecommerce.Application.UseCases.Common.Mappings;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.UpdateProductCommand;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Domain.Enums;

namespace Tektonlabs.Ecommerce.Application.Test.Products.Commands
{
    public class UpdateProductHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly UpdateProductHandler _handler;
        private readonly UpdateProductCommand _command;
        private readonly UpdateProductValidator _createProductValidator;
        public UpdateProductHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingsProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _createProductValidator = new UpdateProductValidator();
            _handler = new UpdateProductHandler(_mockUow.Object, _mapper, new UpdateProductValidator());

            _command = new UpdateProductCommand
            {
                ProductId = 1,
                Name = "Test DTO",
                Status = ProductStatus.Active,
                UnidadMedida = TipoUnidadMedida.UNIDAD,
                Moneda = TipoMoneda.PEN,
                Price = 10,
                Stock = 20,
                Description = "Description",
            };
        }
        [Fact]
        public async Task Handle_Should_RetunValidResult_WhenProductDtoValid()
        {
            var result = await _handler.Handle(_command, CancellationToken.None);

            result.ShouldBeOfType<Response<bool>>();
        } 
    }
}
