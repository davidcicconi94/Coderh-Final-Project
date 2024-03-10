using coder.Application.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Features.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioRequest : IRequest<CreateUsuarioResponse>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }
    }
}
