using AutoMapper;
using coder.Application.Domain.Entities;
using coder.Application.Features.Productos.Queries.GetProducto;
using coder.Application.Features.Productos.Queries.GetProductos;
using coder.Application.Features.Usuarios.Commands.CreateUsuario;
using coder.Application.Features.Usuarios.Commands.DeleteUsuario;
using coder.Application.Features.Usuarios.Commands.UpdateUsuario;
using coder.Application.Features.Usuarios.Queries.GetUsuario;
using coder.Application.Features.Usuarios.Queries.GetUsuarioByCredentials;
using coder.Application.Features.Usuarios.Queries.GetUsuarios;

namespace coder.Application.Infrastructure.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region Usuarios
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

            CreateMap<UpdateUsuarioRequest, Usuario>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.NombreUsuario))
                .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña))
                .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Mail));

            CreateMap<Usuario, GetUsuarioByCredentialsResponse>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Inicio de sesión correcto. Bienvenido nuevamente!."));

            CreateMap<Usuario, DeleteUsuarioResponse>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Usuario eliminado correctamente."));
            #endregion

            #region Productos
            CreateMap<Producto, GetProductoResponse>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Producto econtrado correctamente."));

            CreateMap<IEnumerable<Producto>, GetProductosResponse>()
                .ForMember(dest => dest.Productos, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Usuarios encontrados correctamente."));



            #endregion

        }
    }
}
