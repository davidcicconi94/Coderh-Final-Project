using coder.Application.Domain.Entities;
using coder.ErrorHandling.Exceptions;

namespace coder.Application.Common.Exceptions.Productos
{
    public class ProductosListNotFoundException : NotFoundException
    {
        public ProductosListNotFoundException()
            : base ("No se pudo obtener la lista de productos.")
        {

        }
        public object ErrorResponse => new { Message, Productos = (IEnumerable<Producto>)null, };
    }
}
