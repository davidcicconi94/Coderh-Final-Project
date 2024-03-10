using AutoMapper;
using coder.Application.Common.DTOs;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;


namespace coder.Application.Features.Usuarios.Queries.GetUsuarios
{
    public class GetUsuariosHandler : IRequestHandler<GetUsuariosRequest, GetUsuariosResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _usuario;
        private readonly IGenericRepository<Producto> _producto;


        public GetUsuariosHandler(IMapper mapper, IGenericRepository<Usuario> usuario, IGenericRepository<Producto> producto)
        {
            _mapper = mapper;
            _usuario = usuario;
            _producto = producto;
        }
        public async Task<GetUsuariosResponse> Handle(GetUsuariosRequest request, CancellationToken cancellationToken)
        {
            GetUsuariosResponse usuarios = await GetUsuarios();
            return usuarios;
        }

        public async Task<GetUsuariosResponse> GetUsuarios()
        {
            var usuarios = await _usuario.GetAllAsync();  

            var usuariosConProductosDto = new List<UsuarioDTO>();

            foreach (var usuario in usuarios)
            {
                var productos = await _producto.GetAllAsync(x => x.IdUsuario == usuario.Id);

                var usuarioDto = _mapper.Map<UsuarioDTO>(usuario);
                usuarioDto.Productos = _mapper.Map<List<ProductoDTO>>(productos);

                usuariosConProductosDto.Add(usuarioDto);
            }

            return usuarios == null ? throw new UsuariosListNotFoundException() : _mapper.Map<IEnumerable<UsuarioDTO>, GetUsuariosResponse>(usuariosConProductosDto);
        }
    }
}
