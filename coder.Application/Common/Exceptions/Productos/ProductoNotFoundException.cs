using coder.Application.Domain.Entities;
using coder.ErrorHandling.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Common.Exceptions.Productos
{
    public class ProductoNotFoundException : NotFoundException
    {
        public ProductoNotFoundException()
            : base ("Producto no encontrado.")
        {
            
        }
        public object ErrorResponse => new { Message, Producto = (Producto)null, };
    }
}
