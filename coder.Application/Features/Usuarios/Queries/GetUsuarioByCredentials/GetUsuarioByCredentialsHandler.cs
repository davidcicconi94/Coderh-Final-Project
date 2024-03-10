using AutoMapper;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;

namespace coder.Application.Features.Usuarios.Queries.GetUsuarioByCredentials
{
    public class GetUsuarioByCredentialsHandler : IRequestHandler<GetUsuarioByCredentialsRequest, GetUsuarioByCredentialsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _usuario;
        public GetUsuarioByCredentialsHandler(IMapper mapper, IGenericRepository<Usuario> usuario)
        {
            _mapper = mapper;
            _usuario = usuario;
        }
        public async Task<GetUsuarioByCredentialsResponse> Handle(GetUsuarioByCredentialsRequest request, CancellationToken cancellationToken)
        {
            var response = await GetUsuarioByCredentials(request.NombreUsuario, request.Constraseña);
            return response;
        }

        public async Task<GetUsuarioByCredentialsResponse> GetUsuarioByCredentials(string nombreUsuario, string contraseña)
        {
            var usuario = await _usuario.GetSingleOrDefaultAsync(x => x.NombreUsuario == nombreUsuario && x.Contraseña == contraseña);

            return usuario == null ? throw new UsuarionCannotLoginException() : _mapper.Map<GetUsuarioByCredentialsResponse>(usuario);
        }
    }
}
