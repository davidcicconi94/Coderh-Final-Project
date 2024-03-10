using coder.Application.Common.Exceptions.ProductosVendidos;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Features.ProductosVendidos.Queries.GetProductosVendidos;
using coder.Application.Features.Usuarios.Queries.GetUsuarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coderh_Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoVendidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductosVendidos()
        {
            try
            {
                var query = new GetProductosVendidosRequest();
                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (ProductosVendidosNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }
    }
}
