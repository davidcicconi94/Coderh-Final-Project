using AutoMapper;
using coder.Application.Common.Exceptions.Productos;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Features.Usuarios.Commands.DeleteUsuario;
using coder.Application.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Features.Productos.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Producto> _producto;
        public DeleteProductHandler(IMapper mapper, IGenericRepository<Producto> producto)
        {
            _mapper = mapper;
            _producto = producto;
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            DeleteProductResponse producto = await GetProducto(request);

            return producto;
        }
        public async Task<DeleteProductResponse> GetProducto(DeleteProductRequest request)
        {
            var producto = await _producto.GetSingleOrDefaultAsync(x => x.Id == request.Id);

            await _producto.DeleteAsync(producto);

            await _producto.SaveChangesAsync();

            return producto == null ? throw new ProductoNotFoundException() : _mapper.Map<DeleteProductResponse>(producto);
        }
    }
}
