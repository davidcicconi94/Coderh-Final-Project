using AutoMapper;
using coder.Application.Common.DTOs;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;


namespace coder.Application.Features.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioHandler: IRequestHandler<GetUsuarioRequest, GetUsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _usuario;
        private readonly IGenericRepository<Producto> _producto;
        public GetUsuarioHandler(IMapper mapper, IGenericRepository<Usuario> usuario, IGenericRepository<Producto> producto)
        {
            _mapper = mapper;
            _usuario = usuario;
            _producto = producto;
        }

        public async Task<GetUsuarioResponse> Handle(GetUsuarioRequest request, CancellationToken cancellationToken)
        {
            GetUsuarioResponse usuario = await GetUsuario(request);
            return usuario;
        }

        public async Task<GetUsuarioResponse> GetUsuario(GetUsuarioRequest request)
        {
            var usuario = await _usuario.GetSingleOrDefaultAsync(x => x.Id == request.Id);

            if (usuario == null)
            {
                throw new UsuarioNotFoundException();
            }

            var productos = await _producto.GetAllAsync(x => x.IdUsuario == request.Id);

            foreach (var producto in productos)
            {
                usuario.Productos.Add(producto);
            }

            var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);

            return usuario == null ?  throw new UsuarioNotFoundException() : _mapper.Map<GetUsuarioResponse>(usuarioDto);
        }
    }
}
