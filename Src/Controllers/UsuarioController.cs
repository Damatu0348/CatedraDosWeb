using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiWebDos.Src.Data;
using apiWebDos.Src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace apiWebDos.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UsuarioController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdUsuario([FromRoute] int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult PostUsuario([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
    }
}