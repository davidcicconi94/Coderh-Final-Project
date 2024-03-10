using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Common.Exceptions.Ventas;
using coder.Application.Features.Usuarios.Commands.CreateUsuario;
using coder.Application.Features.Usuarios.Commands.DeleteUsuario;
using coder.Application.Features.Ventas.Commands.CreateVenta;
using coder.Application.Features.Ventas.Queries.GetVentas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coderh_Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            try
            {
                var query = new GetVentasRequest();
                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (VentasNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearVenta([FromBody] CreateVentaRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (VentasNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta([FromRoute] int id)
        {
            try
            {
                var query = new DeleteUsuarioRequest { Id = id };

                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (VentasNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }
    }
}
