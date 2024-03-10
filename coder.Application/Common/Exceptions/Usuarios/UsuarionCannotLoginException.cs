using coder.Application.Domain.Entities;
using coder.ErrorHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Common.Exceptions.Usuarios
{
    public class UsuarionCannotLoginException : NotFoundException
    {
        public UsuarionCannotLoginException()
            : base ("Datos incorrectos. Por favor verifique su usuario y contraseña.")
        {
            
        }
        public object ErrorResponse => new { Message };
    }
}
