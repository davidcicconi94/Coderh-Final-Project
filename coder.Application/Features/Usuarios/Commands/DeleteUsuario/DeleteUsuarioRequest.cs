using MediatR;

namespace coder.Application.Features.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioRequest : IRequest<DeleteUsuarioResponse>
    {
        public int Id { get; set; }
    }
}
