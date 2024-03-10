using MediatR;

namespace coder.Application.Features.Productos.Commands.DeleteProduct
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>   
    {
        public int Id { get; set; }
    }
}
