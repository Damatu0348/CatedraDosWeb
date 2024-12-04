using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiWebDos.Src.Models;

namespace apiWebDos.Src.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObtenerTodosLosUsuarios();
        Task<Usuario> AgregarUsuario(Usuario usuario);
        Task<Usuario?> ObtenerPorIdUsuario(int id);
    }
}