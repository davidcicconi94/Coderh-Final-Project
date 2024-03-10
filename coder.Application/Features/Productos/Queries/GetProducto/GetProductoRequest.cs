using MediatR;

namespace coder.Application.Features.Productos.Queries.GetProducto
{
    public class GetProductoRequest : IRequest<GetProductoResponse>
    {
        public int Id { get; set; } 
    }
}
