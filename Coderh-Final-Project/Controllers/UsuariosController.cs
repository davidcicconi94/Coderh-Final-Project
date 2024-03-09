using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Features.Usuarios.Queries.GetUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coderh_Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            try
            {
                var query = new GetUsuarioRequest { Id = id };
                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (UsuarioNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }
    }
}
