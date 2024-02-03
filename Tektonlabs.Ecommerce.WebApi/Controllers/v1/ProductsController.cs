using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tektonlabs.Ecommerce.Application.DTO;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.UpdateProductCommand;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Queries.GetProductQuery;
using Tektonlabs.Ecommerce.Common;
using Tektonlabs.Ecommerce.Domain.Entities;
using static Dapper.SqlMapper;

namespace Tektonlabs.Ecommerce.WebApi.Controllers.v1
{
    /// Api Products  
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        /// Constructor  
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Registrar un nuevo producto.
        /// </summary>
        /// <param name="command">Objeto para registrar nuevo producto.</param>  
        /// <returns>Retorna un objeto response con el id del producto insertado.</returns> 
        /// <response code="201">Registro creado</response> 
        /// <response code="400">Error en el servidor</response>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Nuevo Producto",
            Description = "Este endpoint se encarga de registrar nuevo producto",
            OperationId = "Insert",
            Tags = new string[] { "Insert" })]
        [SwaggerResponse(201, "Insert", typeof(Response<ProductInsertDto>))]
        [SwaggerResponse(400, "Error Server")]
        public async Task<IActionResult> Insert([FromBody] CreateProductCommand command)
        { 
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return StatusCode(StatusCodes.Status201Created, response);
            return BadRequest(response.Message);
        }
        /// <summary>
        /// Actualizar un producto.
        /// </summary>
        /// <param name="id">Id del producto a modificar.</param>  
        /// <param name="command">Objeto para modificar un producto.</param>  
        /// <returns>Retorna un objeto response con el status de la actualización.</returns> 
        /// <response code="200">Producto actualizado</response> 
        /// <response code="404">Producto no encontrado</response>
        /// <response code="400">Error en el servidor</response>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Actualizar Producto",
            Description = "Este endpoint se encarga de actualizar campos de un producto",
            OperationId = "Update",
            Tags = new string[] { "Update" })]
        [SwaggerResponse(200, "Update", typeof(Response<bool>))]
        [SwaggerResponse(404, "Notfound Product")]
        [SwaggerResponse(400, "Error Server")]
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
        /// <summary>
        /// Consultar producto por Id.
        /// </summary>
        /// <param name="id">Id del producto a consultar.</param>  
        /// <returns>Retorna un objeto response con el porducto consultado.</returns> 
        /// <response code="200">Producto encontrado</response> 
        /// <response code="404">Producto no encontrado</response>
        /// <response code="400">Error en el servidor</response>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtener Producto",
            Description = "Este endpoint se encarga de obtener un producto",
            OperationId = "GetById",
            Tags = new string[] { "GetById" })]
        [SwaggerResponse(200, "GetById", typeof(Response<ProductDto>))]
        [SwaggerResponse(404, "Notfound Product")]
        [SwaggerResponse(400, "Error Server")]
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
