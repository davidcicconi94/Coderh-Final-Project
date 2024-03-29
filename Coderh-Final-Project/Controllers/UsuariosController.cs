﻿using coder.Application.Common.Exceptions.Usuarios;
using coder.Application.Domain.Entities;
using coder.Application.Features.Usuarios.Commands.CreateUsuario;
using coder.Application.Features.Usuarios.Commands.DeleteUsuario;
using coder.Application.Features.Usuarios.Commands.UpdateUsuario;
using coder.Application.Features.Usuarios.Queries.GetUsuario;
using coder.Application.Features.Usuarios.Queries.GetUsuarioByCredentials;
using coder.Application.Features.Usuarios.Queries.GetUsuarios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coderh_Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var query = new GetUsuariosRequest();
                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (UsuariosListNotFoundException ex) 
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }

        [HttpGet("login")]
        public async Task<IActionResult> GetUsuariosByCredentials([FromQuery] GetUsuarioByCredentialsRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch(UsuarionCannotLoginException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            try
            {
                var query = new GetUsuarioRequest { Id = id };
                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (UsuarioNotFoundException ex)
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CreateUsuarioResponse { Message = $"Error al crear el usuario: {ex.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] UpdateUsuarioRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new UpdateUsuarioResponse { Message = $"Error al modificar el usuario: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] int id)
        {
            try
            {
                var query = new DeleteUsuarioRequest { Id = id };

                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (UsuarioNotFoundException ex) 
            {
                var errorResponse = ex.ErrorResponse;

                return NotFound(errorResponse);
            }
        }
    }
}
