using AutoMapper;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;

namespace coder.Application.Features.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioRequest, DeleteUsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _usuario;
        public DeleteUsuarioHandler(IMapper mapper, IGenericRepository<Usuario> usuario)
        {
            _mapper = mapper;
            _usuario = usuario;
        }
        public async Task<DeleteUsuarioResponse> Handle(DeleteUsuarioRequest request, CancellationToken cancellationToken)
        {
            DeleteUsuarioResponse usuario = await GetUsuario(request); 

            return usuario;
        }
        public async Task<DeleteUsuarioResponse> GetUsuario(DeleteUsuarioRequest request)
        {
            var usuario = await _usuario.GetSingleOrDefaultAsync(x => x.Id == request.Id);

            await _usuario.DeleteAsync(usuario);

            await _usuario.SaveChangesAsync();

            return usuario == null ? throw new UsuarioNotFoundException() : _mapper.Map<DeleteUsuarioResponse>(usuario);
        }
    }
}
