using AutoMapper;
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

        public GetUsuariosHandler(IMapper mapper, IGenericRepository<Usuario> usuario)
        {
            _mapper = mapper;
            _usuario = usuario;
        }
        public async Task<GetUsuariosResponse> Handle(GetUsuariosRequest request, CancellationToken cancellationToken)
        {
            GetUsuariosResponse usuarios = await GetUsuarios();
            return usuarios;
        }

        public async Task<GetUsuariosResponse> GetUsuarios()
        {
            var usuarios = await _usuario.GetAllAsync();

            return usuarios == null ? throw new UsuariosListNotFoundException() : _mapper.Map<GetUsuariosResponse>(usuarios);
        }
    }
}
