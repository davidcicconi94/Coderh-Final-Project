using coder.Application.Common.DTOs;
using coder.Application.Domain.Entities;

namespace coder.Application.Features.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioResponse
    {
        public string Message { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
