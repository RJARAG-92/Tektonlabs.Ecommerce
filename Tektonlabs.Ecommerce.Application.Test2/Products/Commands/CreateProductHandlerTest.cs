using AutoMapper;
using FluentValidation.TestHelper;
using Moq;
using Shouldly;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Application.Test.Mocks;
using Tektonlabs.Ecommerce.Application.UseCases.Common.Mappings;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Domain.Enums;

namespace Tektonlabs.Ecommerce.Application.Test.Products.Commands
{
    public class CreateProductHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateProductHandler _handler;
        private readonly CreateProductCommand _command;
        private readonly CreateProductValidator _createProductValidator;
        public CreateProductHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingsProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _createProductValidator = new CreateProductValidator();
            _handler = new CreateProductHandler(_mockUow.Object, _mapper, new CreateProductValidator());

            _command = new CreateProductCommand
            {
                Name = "Test DTO",
                Status = ProductStatus.Active,
                UnidadMedida= TipoUnidadMedida.UNIDAD,
                Moneda=TipoMoneda.PEN,
                Price=10,
                Stock=20,
                Description = "Description",
            };
        }
        [Fact]
        public async Task Handle_Should_RetunValidResult_WhenProductDtoValid()
        {
            var result = await _handler.Handle(_command, CancellationToken.None);

            result.ShouldBeOfType<Response<ProductInsertDto>>();
        }
        [Fact]
        public void Handle_Should_RetunValidationErrorResult_WhenParamatersInValid()
        {
            _command.Name = "";
            _command.Price = -10;
            _command.Stock = -5;

            var result = _createProductValidator.TestValidate(_command);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Price);
            result.ShouldHaveValidationErrorFor(x => x.Stock);
        }

        [Fact]
        public void Handle_Should_RetunValidationErrorResult_WhenNameLengthMenor4()
        {
            _command.Name = "123";

            var result = _createProductValidator.TestValidate(_command);
            result.ShouldHaveValidationErrorFor(x => x.Name); 
        }
    }
}
