using AutoMapper;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;


namespace coder.Application.Features.Usuarios.Commands.UpdateUsuario
{
    internal class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioRequest, UpdateUsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _usuario;

        public UpdateUsuarioHandler(IMapper mapper, IGenericRepository<Usuario> usuario)
        {
            _mapper = mapper;
            _usuario = usuario;
        }
        public async Task<UpdateUsuarioResponse> Handle(UpdateUsuarioRequest request, CancellationToken cancellationToken)
        {
            Usuario usuario = await GetUser(request);

            if(usuario == null)
            {
                throw new UsuarioNotFoundException();
            }
            return await UpdateUsuario(request);
        }

        private async Task<Usuario> GetUser(UpdateUsuarioRequest request)
        {
            Usuario? usuario = await _usuario.GetSingleByIdAsync(request.Id);
            
            return usuario ?? throw new UsuarioNotFoundException();
        }

        private async Task<UpdateUsuarioResponse> UpdateUsuario(UpdateUsuarioRequest request)
        {
            Usuario usuarioMod = _mapper.Map<Usuario>(request);

            await _usuario.UpdateAsync(usuarioMod);

            await _usuario.SaveChangesAsync();

            UpdateUsuarioResponse response = new UpdateUsuarioResponse
            {
                Message = "Usuario modificado exitosamente",
            };

            return response;
        }
    }
}
