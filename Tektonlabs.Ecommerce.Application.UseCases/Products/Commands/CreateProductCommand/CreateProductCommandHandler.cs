using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Domain.Entities;

namespace Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<bool>>
    {
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var product = _mapper.Map<Product>(request);
            //response.Data = product;
            //if (response.Data)
            //{
                response.IsSuccess = true;
                response.Message = "Registro Exitoso!!!";
            //}

            return response;
        }
    }
}
