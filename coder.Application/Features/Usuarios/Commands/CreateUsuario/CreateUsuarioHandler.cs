using AutoMapper;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using MediatR;

namespace coder.Application.Features.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioRequest, CreateUsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _usuario;

        public CreateUsuarioHandler(IMapper mapper, IGenericRepository<Usuario> usuario)
        {
            _mapper = mapper;
            _usuario = usuario;
        }
        public async Task<CreateUsuarioResponse> Handle(CreateUsuarioRequest request, CancellationToken cancellationToken)
        {
            return await CreateUsuario(request);
        }

        private async Task<CreateUsuarioResponse> CreateUsuario(CreateUsuarioRequest request)
        {
            Usuario nuevoUsuario = _mapper.Map<Usuario>(request);

            await _usuario.AddAsync(nuevoUsuario);

            await _usuario.SaveChangesAsync();

            CreateUsuarioResponse response = new CreateUsuarioResponse
            {
                Message = "Usuario creado exitosamente",
            };

            return response;
        }
    }
}
