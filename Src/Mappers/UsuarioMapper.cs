using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiWebDos.Src.Dtos;
using apiWebDos.Src.Models;

namespace apiWebDos.Src.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioGetDto ToGetUsuarioDto(this Usuario usuarioModel)
        {
            return new UsuarioGetDto
            {
                IdUsuario = usuarioModel.IdUsuario,
                Nombre = usuarioModel.Nombre,
                Correo = usuarioModel.Correo,
                FechaNacimiento = usuarioModel.FechaNacimiento,
                Genero = usuarioModel.Genero
            };
        }

        public static Usuario ToPostUsuarioDto(this UsuarioPostDto usuarioPostDto)
        {
            return new Usuario
            {
                Nombre = usuarioPostDto.Nombre,
                Correo = usuarioPostDto.Correo,
                FechaNacimiento = usuarioPostDto.FechaNacimiento,
                Genero = usuarioPostDto.Genero
            };
        }
    }
}