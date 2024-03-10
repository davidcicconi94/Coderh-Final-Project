using AutoMapper;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;

namespace coder.Application.Features.Productos.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Producto> _producto;
        private readonly IGenericRepository<Usuario> _usuario;
        public CreateProductHandler(IMapper mapper, IGenericRepository<Producto> producto, IGenericRepository<Usuario> usuario)
        {
            _mapper = mapper;
            _producto = producto;
            _usuario = usuario;
        }
        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            return await CreateProducto(request);
        }

        private async Task<CreateProductResponse> CreateProducto(CreateProductRequest request)
        {
            var usuario = await _usuario.GetSingleOrDefaultAsync(x => x.Id == request.IdUsuario);

            if(usuario == null)
            {
                throw new UsuarioNotFoundException();
            }

            Producto nuevoProducto = _mapper.Map<Producto>(request);

            await _producto.AddAsync(nuevoProducto);

            usuario.Productos.Add(nuevoProducto);

            await _producto.SaveChangesAsync();

            CreateProductResponse response = new CreateProductResponse
            {
                Message = "Producto creado exitosamente",
            };

            return response;
        }
    }
}
