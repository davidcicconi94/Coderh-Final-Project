using coder.Application.Domain.Entities;
using coder.ErrorHandling.Exceptions;

namespace coder.Application.Common.Exceptions.Usuarios
{
    public class UsuariosListNotFoundException : NotFoundException
    {

        public UsuariosListNotFoundException()
            : base ("No se pudo obtener la lista de usuarios")
        {
            
        }
        public object ErrorResponse => new { Message, Usuarios = (IEnumerable<Usuario>)null, };
    }
}
