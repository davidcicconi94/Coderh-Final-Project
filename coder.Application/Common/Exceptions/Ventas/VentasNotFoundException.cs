using coder.Application.Common.DTOs;
using coder.ErrorHandling.Exceptions;

namespace coder.Application.Common.Exceptions.Ventas
{
    public class VentasNotFoundException : NotFoundException
    {
        public VentasNotFoundException()
            : base ("No se pudo encontrar la lista de ventas.")
        {
            
        }
        public object ErrorResponse => new { Message, Ventas = (IEnumerable<VentumDTO>)null, };
    }
}
