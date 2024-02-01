using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Application.Validator;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Domain.Entities;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        //private readonly IProductsRepository _productsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateProductValidator _validator;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper, CreateProductValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
            _validator = validator;
        }

        public async Task<Response<bool>> Handle( CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            _validator.ValidateAndThrow(request);

            var product = _mapper.Map<Product>(request); 
            response.Data = await _unitOfWork.Products.InsertAsync(product);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!!!";
            }

            return response;
        }
    }
}
