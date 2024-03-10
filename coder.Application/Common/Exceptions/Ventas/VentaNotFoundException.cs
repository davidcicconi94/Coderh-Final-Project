using coder.Application.Common.DTOs;
using coder.ErrorHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Common.Exceptions.Ventas
{
    public class VentaNotFoundException : NotFoundException
    {
        public VentaNotFoundException()
            : base ("No se pudo encontrar la venta con ese ID.")
        {
            
        }
        public object ErrorResponse => new { Message };
    }
}
