using coder.Application.Domain.Entities;
using coder.ErrorHandling.Exceptions;

namespace coder.Application.Common.Exceptions.Usuarios
{
    public class UsuarioNotFoundException : NotFoundException
    {
        public UsuarioNotFoundException()
            : base("El usuario no fue encontrado.") { }

        public object ErrorResponse => new { Message, Usuario = (Usuario)null, };
    }
}
