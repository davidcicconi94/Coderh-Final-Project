using coder.Application.Common.DTOs;

namespace coder.Application.Features.ProductosVendidos.Queries.GetProductosVendidos
{
    public class GetProductosVendidosResponse
    {
        public string Message { get; set; }
        public IEnumerable<ProductosVendidosDTO> ProductosVendidos { get; set; }
    }
}
