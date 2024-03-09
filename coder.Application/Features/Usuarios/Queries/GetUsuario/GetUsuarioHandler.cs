using AutoMapper;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Infrastructure;
using coder.ErrorHandling.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Features.Usuarios.Queries.GetUsuario
{
    public class GetUsuarioHandler: IRequestHandler<GetUsuarioRequest, GetUsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Usuario> _usuario;
        public GetUsuarioHandler(IMapper mapper, IGenericRepository<Usuario> usuario)
        {
            _mapper = mapper;
            _usuario = usuario;
        }

        public async Task<GetUsuarioResponse> Handle(GetUsuarioRequest request, CancellationToken cancellationToken)
        {
            GetUsuarioResponse usuario = await GetUsuario(request);
            return usuario;
        }

        public async Task<GetUsuarioResponse> GetUsuario(GetUsuarioRequest request)
        {
            var usuario = await _usuario.GetSingleOrDefaultAsync(x => x.Id == request.Id);
            
            return usuario == null ? throw new UsuarioNotFoundException() : _mapper.Map<GetUsuarioResponse>(usuario);
        }
    }
}
