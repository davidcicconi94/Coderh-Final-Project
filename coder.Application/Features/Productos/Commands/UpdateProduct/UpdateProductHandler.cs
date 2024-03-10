using AutoMapper;
using coder.Application.Common.DTOs;
using coder.Application.Common.Exceptions.Productos;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Features.Usuarios.Commands.UpdateUsuario;
using coder.Application.Infrastructure;
using MediatR;

namespace coder.Application.Features.Productos.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Producto> _producto;
        private readonly IGenericRepository<Usuario> _usuario;
        public UpdateProductHandler(IMapper mapper, IGenericRepository<Producto> producto, IGenericRepository<Usuario> usuario)
        {
            _mapper = mapper;
            _producto = producto;
            _usuario = usuario;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            Producto producto = await GetProducto(request);

            if(producto == null)
            {
                throw new ProductoNotFoundException();
            }

            return await UpdateProducto(request);
        }

        private async Task<Producto> GetProducto(UpdateProductRequest request)
        {
            Producto? producto = await _producto.GetSingleByIdAsync(request.Id);

            return producto ?? throw new ProductoNotFoundException();
        }

        private async Task<UpdateProductResponse> UpdateProducto(UpdateProductRequest request)
        {
            Producto productoMod = _mapper.Map<Producto>(request);

            await _producto.UpdateAsync(productoMod);

            await _producto.SaveChangesAsync();

            UpdateProductResponse response = new UpdateProductResponse
            {
                Message = "Producto modificado exitosamente",
            };

            return response;
        }
    }
}
