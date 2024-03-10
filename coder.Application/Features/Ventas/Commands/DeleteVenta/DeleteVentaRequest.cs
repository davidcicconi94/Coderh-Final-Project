using MediatR;

namespace coder.Application.Features.Ventas.Commands.DeleteVenta
{
    public class DeleteVentaRequest : IRequest<DeleteVentaResponse>
    {
        public int Id { get; set; }
    }
}
