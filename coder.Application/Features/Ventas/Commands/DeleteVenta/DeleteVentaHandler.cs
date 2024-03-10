using AutoMapper;
using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Common.Exceptions.Ventas;
using coder.Application.Domain.Entities;
using coder.Application.Features.Usuarios.Commands.DeleteUsuario;
using coder.Application.Features.Ventas.Commands.CreateVenta;
using coder.Application.Infrastructure;
using MediatR;

namespace coder.Application.Features.Ventas.Commands.DeleteVenta
{
    public class DeleteVentaHandler : IRequestHandler<DeleteVentaRequest, DeleteVentaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Ventum> _venta;

        public DeleteVentaHandler(IMapper mapper, IGenericRepository<Ventum> venta)
        {
            _mapper = mapper;
            _venta = venta;
        }
        public async Task<DeleteVentaResponse> Handle(DeleteVentaRequest request, CancellationToken cancellationToken)
        {
            DeleteVentaResponse venta = await GetVenta(request);

            return venta;
        }
        public async Task<DeleteVentaResponse> GetVenta(DeleteVentaRequest request)
        {
            var venta = await _venta.GetSingleOrDefaultAsync(x => x.Id == request.Id);

            if(venta == null)
            {
                throw new VentaNotFoundException();
            }

            await _venta.DeleteAsync(venta);

            await _venta.SaveChangesAsync();
            
            return venta == null ? throw new VentaNotFoundException() : _mapper.Map<DeleteVentaResponse>(venta);
        }
    }
}
