using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tektonlabs.Ecommerce.Application.UseCases.Products.Commands.CreateProductCommand;
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

        [HttpPost("Insert")]
        [SwaggerOperation(
            Summary = "Nuevo Producto",
            Description = "This endpoint will return all categories",
            OperationId = "Insert",
            Tags = new string[] { "Insert" })]
        //[SwaggerResponse(200, "Nuevo", typeof(Response<IEnumerable<CategoryDto>>))]
        //[SwaggerResponse(404, "Notfound Categories")]
        public async Task<IActionResult> Insert([FromBody] CreateProductCommand command)
        {
            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        //[HttpPut("Update/{customerId}")]
        //public async Task<IActionResult> Update(string customerId, [FromBody] UpdateCustomerCommand command)
        //{
        //    var customerDto = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId });
        //    if (customerDto.Data == null)
        //        return NotFound(customerDto.Message);

        //    if (command == null)
        //        return BadRequest();
        //    var response = await _mediator.Send(command);
        //    if (response.IsSuccess)
        //        return Ok(response);

        //    return BadRequest(response.Message);
        //}
        //[HttpGet("Get/{customerId}")]
        //public async Task<IActionResult> Get([FromRoute] string customerId)
        //{
        //    if (string.IsNullOrEmpty(customerId))
        //        return BadRequest();
        //    var response = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId });
        //    if (response.IsSuccess)
        //        return Ok(response);

        //    return BadRequest(response.Message);
        //}
    }
}
