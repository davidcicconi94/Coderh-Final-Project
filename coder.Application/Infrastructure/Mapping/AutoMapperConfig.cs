using AutoMapper;
using coder.Application.Common.DTOs;
using coder.Application.Domain.Entities;
using coder.Application.Features.Productos.Commands.CreateProduct;
using coder.Application.Features.Productos.Commands.DeleteProduct;
using coder.Application.Features.Productos.Commands.UpdateProduct;
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
            CreateMap<Usuario, UsuarioDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.NombreUsuario))
               .ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => src.Contraseña))
               .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.Mail))
               .ForMember(dest => dest.Productos, opt => opt.MapFrom(src => src.Productos));

            CreateMap<UsuarioDTO, GetUsuarioResponse>()
               .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src))
               .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Usuario econtrado correctamente."));

            CreateMap<IEnumerable<UsuarioDTO>, GetUsuariosResponse>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Any() ? "Usuarios encontrados correctamente." : "No se encontraron usuarios."))
                .ForMember(dest => dest.Usuarios, opt => opt.MapFrom(src => src));

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
            CreateMap<Producto, ProductoDTO>()
                .PreserveReferences();

            CreateMap<UpdateProductRequest, Producto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descripciones, opt => opt.MapFrom(src => src.Descripciones))
                .ForMember(dest => dest.Costo, opt => opt.MapFrom(src => src.Costo))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.PrecioVenta, opt => opt.MapFrom(src => src.PrecioVenta));

            CreateMap<Producto, GetProductoResponse>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Producto econtrado correctamente."));

            CreateMap<IEnumerable<Producto>, GetProductosResponse>()
                .ForMember(dest => dest.Productos, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Productos encontrados correctamente."));

            CreateMap<CreateProductRequest, Producto>()
                .ForMember(dest => dest.Descripciones, opt => opt.MapFrom(src => src.Descripciones))
                .ForMember(dest => dest.Costo, opt => opt.MapFrom(src => src.Costo))
                .ForMember(dest => dest.PrecioVenta, opt => opt.MapFrom(src => src.PrecioVenta))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario));

            CreateMap<Producto, DeleteProductResponse>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Producto eliminado correctamente."));

            #endregion

        }
    }
}
