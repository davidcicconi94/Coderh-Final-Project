using MediatR;

namespace coder.Application.Features.Productos.Commands.UpdateProduct
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public int Id { get; set; } 
        public string Descripciones { get; set; } = null!;
        public decimal? Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
