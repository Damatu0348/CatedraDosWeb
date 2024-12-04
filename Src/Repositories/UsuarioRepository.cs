using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiWebDos.Src.Data;
using apiWebDos.Src.Interfaces;
using apiWebDos.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace apiWebDos.Src.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDBContext _context;
        public UsuarioRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Usuario> AgregarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> ObtenerPorIdUsuario(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<List<Usuario>> ObtenerTodosLosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}