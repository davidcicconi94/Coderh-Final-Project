using coder.Application.Common.DTOs;
using coder.ErrorHandling.Exceptions;

namespace coder.Application.Common.Exceptions.ProductosVendidos
{
    public class ProductosVendidosNotFoundException : NotFoundException
    {
        public ProductosVendidosNotFoundException()
            : base ("No se pudo encontrar la lista de productos vendidos.")
        {
            
        }
        public object ErrorResponse => new { Message, ProductosVendidos = (IEnumerable<ProductosVendidosDTO>)null, };
    }
}
