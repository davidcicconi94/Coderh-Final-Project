using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Features.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioRequest: IRequest<GetUsuarioResponse>
    {
        public int Id { get; set; } 
    }
}
