using coder.Application.Common.Exceptions.Productos;
using coder.Application.Features.Productos.Commands.CreateProduct;
using coder.Application.Features.Productos.Commands.UpdateProduct;
using coder.Application.Features.Productos.Queries.GetProducto;
using coder.Application.Features.Productos.Queries.GetProductos;
using coder.Application.Features.Usuarios.Commands.CreateUsuario;
using coder.Application.Features.Usuarios.Commands.UpdateUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coderh_Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto([FromRoute] int id)
        {
            try
            {
                var query = new GetProductoRequest { Id = id };
                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (ProductoNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse); 
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var query = new GetProductosRequest();
                var response = await _mediator.Send(query); 
                
                return Ok(response);
            }
            catch (ProductosListNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] CreateProductRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CreateProductResponse { Message = $"Error al crear el producto: {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] UpdateProductRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new UpdateUsuarioResponse { Message = $"Error al modificar el producto: {ex.Message}" });
            }
        }
    }
}
