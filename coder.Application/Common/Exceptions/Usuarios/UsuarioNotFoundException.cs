using coder.ErrorHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Common.Exceptions.Usuarios
{
    internal class UsuarioNotFoundException: NotFoundException
    {
        public UsuarioNotFoundException() : base("El usuario no fue encontrado.")
        {
        }
    }
}
