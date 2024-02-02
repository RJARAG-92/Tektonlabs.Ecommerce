using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.UpdateProductCommand;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Queries.GetProductQuery;
using Tektonlabs.Ecommerce.Common;

namespace Tektonlabs.Ecommerce.WebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Nuevo Producto",
            Description = "Este endpoint se encarga de registrar nuevo producto",
            OperationId = "Insert",
            Tags = new string[] { "Insert" })]
        [SwaggerResponse(200, "Insert", typeof(Response<ProductInsertDto>))]
        public async Task<IActionResult> Insert([FromBody] CreateProductCommand command)
        { 
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Actualizar Producto",
            Description = "Este endpoint se encarga de actualizar campos de un producto",
            OperationId = "Update",
            Tags = new string[] { "Update" })]
        [SwaggerResponse(200, "Update", typeof(Response<bool>))]
        [SwaggerResponse(404, "Notfound Product")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductCommand command)
        {
            var customerDto = await _mediator.Send(new GetProductQuery(id));
            if (customerDto.Data == null)
                return NotFound(customerDto.Message);

            command = command with { ProductId = id };
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtener Producto",
            Description = "Este endpoint se encarga de obtener un producto",
            OperationId = "GetById",
            Tags = new string[] { "GetById" })]
        [SwaggerResponse(200, "GetById", typeof(Response<ProductDto>))]
        [SwaggerResponse(404, "Notfound Product")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        { 
            var response = await _mediator.Send(new GetProductQuery(id));
            if (response.Data == null)
                return NotFound(response);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
