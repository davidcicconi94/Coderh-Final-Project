using AutoMapper;
using coder.Application.Domain.Entities;
using coder.Application.Features.Usuarios.Queries.GetUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Infrastructure.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, GetUsuarioResponse>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src));
        }
    }
}
