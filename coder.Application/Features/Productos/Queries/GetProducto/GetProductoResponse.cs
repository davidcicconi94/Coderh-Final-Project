using coder.Application.Domain.Entities;

namespace coder.Application.Features.Productos.Queries.GetProducto
{
    public class GetProductoResponse
    {
        public string Message { get; set; }
        public Producto Producto { get; set; }
    }
}
