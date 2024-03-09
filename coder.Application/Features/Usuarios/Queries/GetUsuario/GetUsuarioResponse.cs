using coder.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Features.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioResponse
    {
        public string Message { get; set; }
        public object Usuario { get; set; }
    }
}
