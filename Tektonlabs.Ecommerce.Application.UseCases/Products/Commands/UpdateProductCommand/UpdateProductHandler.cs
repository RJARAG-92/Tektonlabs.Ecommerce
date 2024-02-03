using AutoMapper;
using FluentValidation;
using MediatR;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Application.Interface.Persistence;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Domain.Entities;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.UpdateProductCommand
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UpdateProductValidator _validator;

        public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper, UpdateProductValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Response<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            _validator.ValidateAndThrow(request);

            var product = _mapper.Map<Product>(request);
            response.Data = await _unitOfWork.Products.UpdateAsync(product);
            response.Message = "Elemento no encontrado!!!";
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización Exitosa!!!";
            }

            return response;
        }
    }
}
