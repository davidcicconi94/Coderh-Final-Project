using MediatR;

namespace coder.Application.Features.Productos.Commands.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Descripciones { get; set; } = null!;
        public decimal? Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
