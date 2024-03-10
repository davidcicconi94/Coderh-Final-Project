using AutoMapper;
using coder.Application.Common.Exceptions.Productos;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;


namespace coder.Application.Features.Productos.Queries.GetProductos
{
    public class GetProductosHandler : IRequestHandler<GetProductosRequest, GetProductosResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Producto> _producto;
        public GetProductosHandler(IMapper mapper, IGenericRepository<Producto> producto)
        {
            _mapper = mapper;
            _producto = producto;
        }

        public async Task<GetProductosResponse> Handle(GetProductosRequest request, CancellationToken cancellationToken)
        {
            GetProductosResponse productos = await GetProductos();

            return productos;
        }

        public async Task<GetProductosResponse> GetProductos()
        {
            var productos = await _producto.GetAllAsync();

            return productos == null ? throw new ProductosListNotFoundException() : _mapper.Map<GetProductosResponse>(productos);
        }
    }
}
