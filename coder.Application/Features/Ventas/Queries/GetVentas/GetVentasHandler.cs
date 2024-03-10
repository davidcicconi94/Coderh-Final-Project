using AutoMapper;
using coder.Application.Common.DTOs;
using coder.Application.Common.Exceptions.ProductosVendidos;
using coder.Application.Common.Exceptions.Ventas;
using coder.Application.Domain.Entities;
using coder.Application.Features.Productos.Queries.GetProductos;
using coder.Application.Features.ProductosVendidos.Queries.GetProductosVendidos;
using coder.Application.Infrastructure;
using MediatR;

namespace coder.Application.Features.Ventas.Queries.GetVentas
{
    public class GetVentasHandler : IRequestHandler<GetVentasRequest, GetVentasResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Ventum> _venta;
        public GetVentasHandler(IMapper mapper, IGenericRepository<Ventum> venta)
        {
            _mapper = mapper;
            _venta = venta;
        }
        public async Task<GetVentasResponse> Handle(GetVentasRequest request, CancellationToken cancellationToken)
        {
            GetVentasResponse ventas = await GetVentas();

            return ventas;
        }
        public async Task<GetVentasResponse> GetVentas()
        {
            var venta = await _venta.GetAllAsync();

            var ventaDto = _mapper.Map<IEnumerable<VentumDTO>>(venta);

            return venta == null ? throw new VentasNotFoundException() : _mapper.Map<GetVentasResponse>(ventaDto);
        }
    }
}
