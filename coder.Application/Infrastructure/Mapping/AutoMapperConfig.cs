using AutoMapper;
using coder.Application.Domain.Entities;
using coder.Application.Features.Usuarios.Commands.CreateUsuario;
using coder.Application.Features.Usuarios.Queries.GetUsuario;
using coder.Application.Features.Usuarios.Queries.GetUsuarios;
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
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Usuario econtrado correctamente."));

            CreateMap<IEnumerable<Usuario>, GetUsuariosResponse>()
                .ForMember(dest => dest.Usuarios, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Usuarios encontrados correctamente."));

            CreateMap<CreateUsuarioRequest, Usuario>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.NombreUsuario))
                .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña))
                .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Mail));
        }
    }
}
