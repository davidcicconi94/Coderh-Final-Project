using coder.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Features.Ventas.Queries.GetVentas
{
    public class GetVentasResponse
    {
        public string Message { get; set; }
        public IEnumerable<VentumDTO> Ventas { get; set; }
    }
}
