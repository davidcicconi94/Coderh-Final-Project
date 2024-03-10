using coder.Application.Domain.Entities;

namespace coder.Application.Features.Usuarios.Queries.GetUsuarios
{
    public class GetUsuariosResponse
    {
        public string Message { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
