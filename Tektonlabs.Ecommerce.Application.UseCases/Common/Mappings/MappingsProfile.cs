using AutoMapper;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.UpdateProductCommand;
using Tektonlabs.Ecommerce.Domain.Entities;

namespace Tektonlabs.Ecommerce.Application.UseCases.Common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();

        }
    }
}
