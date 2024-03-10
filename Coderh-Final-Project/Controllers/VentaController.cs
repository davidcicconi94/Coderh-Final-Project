using coder.Application.Common.Exceptions.Ventas;
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

    }
}
