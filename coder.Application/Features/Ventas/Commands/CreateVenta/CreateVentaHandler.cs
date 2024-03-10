using MediatR;

namespace coder.Application.Features.Ventas.Commands.CreateVenta
{
    public class CreateVentaHandler : IRequestHandler<CreateVentaRequest, CreateVentaResponse>
    {
        public Task<CreateVentaResponse> Handle(CreateVentaRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
