using AutoMapper;
using coder.Application.Common.Exceptions.Productos;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Features.Usuarios.Queries.GetUsuario;
using coder.Application.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Features.Productos.Queries.GetProducto
{
    public class GetProductoHandler : IRequestHandler<GetProductoRequest, GetProductoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Producto> _producto;
        public GetProductoHandler(IMapper mapper, IGenericRepository<Producto> producto)
        {
            _mapper = mapper;
            _producto = producto;
        }
        public async Task<GetProductoResponse> Handle(GetProductoRequest request, CancellationToken cancellationToken)
        {
            GetProductoResponse producto = await GetProducto(request);
            return producto;
        }
        public async Task<GetProductoResponse> GetProducto(GetProductoRequest request)
        {
            var producto = await _producto.GetSingleOrDefaultAsync(x => x.Id == request.Id);
            
            return producto == null ? throw new ProductoNotFoundException() : _mapper.Map<GetProductoResponse>(producto);
        }
    }
}
