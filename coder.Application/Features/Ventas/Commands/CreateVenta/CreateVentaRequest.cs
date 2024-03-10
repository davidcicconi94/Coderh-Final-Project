using MediatR;

namespace coder.Application.Features.Ventas.Commands.CreateVenta
{
    public class CreateVentaRequest : IRequest<CreateVentaResponse>
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public int IdUsuario { get; set; }
    }
}
