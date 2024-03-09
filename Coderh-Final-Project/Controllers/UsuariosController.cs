using coder.Application.Features.Usuarios.Queries.GetUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coderh_Final_Project.Controllers
{
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
            var query = new GetUsuarioRequest {  Id = id };
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
