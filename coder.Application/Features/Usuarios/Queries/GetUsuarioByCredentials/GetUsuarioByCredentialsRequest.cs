using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Features.Usuarios.Queries.GetUsuarioByCredentials
{
    public class GetUsuarioByCredentialsRequest : IRequest<GetUsuarioByCredentialsResponse>
    {
        public string NombreUsuario {  get; set; }  
        public string Constraseña { get; set; }
    }
}
