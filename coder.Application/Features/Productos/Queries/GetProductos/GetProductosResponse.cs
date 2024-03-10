using coder.Application.Domain.Entities;

namespace coder.Application.Features.Productos.Queries.GetProductos
{
    public class GetProductosResponse
    {
        public string Message { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
    }
}
