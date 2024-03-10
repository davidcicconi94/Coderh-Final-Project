using AutoMapper;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;

namespace coder.Application.Features.Ventas.Commands.CreateVenta
{
    public class CreateVentaHandler : IRequestHandler<CreateVentaRequest, CreateVentaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Ventum> _venta;

        public CreateVentaHandler(IMapper mapper, IGenericRepository<Ventum> venta)
        {
            _mapper = mapper;
            _venta = venta;
        }
        public async Task<CreateVentaResponse> Handle(CreateVentaRequest request, CancellationToken cancellationToken)
        {
            return await CrearVenta(request);
        }

        private async Task<CreateVentaResponse> CrearVenta(CreateVentaRequest request)
        {
            Ventum nuevaVenta = _mapper.Map<Ventum>(request);

            await _venta.AddAsync(nuevaVenta);

            await _venta.SaveChangesAsync();

            CreateVentaResponse response = new CreateVentaResponse
            {
                Message = "Venta creada exitosamente",
            };

            return response;
        }

    }
}
