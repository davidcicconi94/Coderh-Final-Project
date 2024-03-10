using coder.Application.Common.DTOs;
using coder.Application.Domain.Entities;

namespace coder.Application.Features.Usuarios.Queries.GetUsuarios
{
    public class GetUsuariosResponse
    {
        public string Message { get; set; }
        public IEnumerable<UsuarioDTO> Usuarios { get; set; }
    }
}
