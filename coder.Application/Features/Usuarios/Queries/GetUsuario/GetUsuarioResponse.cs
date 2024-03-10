using coder.Application.Domain.Entities;

namespace coder.Application.Features.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioResponse
    {
        public string Message { get; set; }
        public Usuario Usuario { get; set; }
    }
}
