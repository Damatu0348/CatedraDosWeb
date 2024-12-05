using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiWebDos.Src.Data;
using apiWebDos.Src.Dtos;
using apiWebDos.Src.Interfaces;
using apiWebDos.Src.Mappers;
using apiWebDos.Src.Models;
using apiWebDos.Src.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace apiWebDos.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.ObtenerTodosLosUsuarios();
            var usuarioDto = usuarios.Select(u => u.ToGetUsuarioDto());
            return Ok(usuarioDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUsuario([FromRoute] int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdUsuario(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario.ToGetUsuarioDto());
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] UsuarioPostDto usuarioDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nowDate = DateTime.Now;

            if(usuarioDto.FechaNacimiento >= DateOnly.FromDateTime(nowDate))
            {
                return BadRequest("Fecha de nacimiento NO debe ser la actual.");
            }
            var usuarioModel = usuarioDto.ToPostUsuarioDto();
            await _usuarioRepository.AgregarUsuario(usuarioModel);
            return CreatedAtAction(nameof(GetByIdUsuario), new {id = usuarioModel.IdUsuario}, usuarioModel.ToGetUsuarioDto());
        }
    }
}