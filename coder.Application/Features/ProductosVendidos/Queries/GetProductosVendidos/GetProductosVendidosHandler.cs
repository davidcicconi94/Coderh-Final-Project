using AutoMapper;
using coder.Application.Common.DTOs;
using coder.Application.Common.Exceptions.ProductosVendidos;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;


namespace coder.Application.Features.ProductosVendidos.Queries.GetProductosVendidos
{
    public class GetProductosVendidosHandler : IRequestHandler<GetProductosVendidosRequest, GetProductosVendidosResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductoVendido> _producto;
        public GetProductosVendidosHandler(IMapper mapper, IGenericRepository<ProductoVendido> producto)
        {
            _mapper = mapper;
            _producto = producto;
        }
        public async Task<GetProductosVendidosResponse> Handle(GetProductosVendidosRequest request, CancellationToken cancellationToken)
        {
            GetProductosVendidosResponse productos = await GetProductosVendidos();

            return productos;
        }
        public async Task<GetProductosVendidosResponse> GetProductosVendidos()
        {
            var producto = await _producto.GetAllAsync();

            var productoDto = _mapper.Map<IEnumerable<ProductosVendidosDTO>>(producto);

            return producto == null ? throw new ProductosVendidosNotFoundException() : _mapper.Map<GetProductosVendidosResponse>(productoDto);
        }

    }
}
