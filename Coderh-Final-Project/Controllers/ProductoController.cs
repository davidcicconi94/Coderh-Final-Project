using coder.Application.Common.Exceptions.Productos;
using coder.Application.Features.Productos.Queries.GetProducto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coderh_Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto([FromRoute] int id)
        {
            try
            {
                var query = new GetProductoRequest { Id = id };
                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (ProductoNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse); 
            }
        }
    }
}
