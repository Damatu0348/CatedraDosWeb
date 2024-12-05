using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using apiWebDos.Src.Models;
using Bogus.DataSets;

namespace apiWebDos.Src.Dtos
{
    public class UsuarioGetDto
    {
        [Required]
        [Key]
        public int IdUsuario {get; set;}

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El Nombre debe tener entre 3 y 20 caracteres.")]
        public string Nombre {get; set;} = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        public string Correo {get; set;} = string.Empty;

        [Required]
        public DateOnly FechaNacimiento { get; set; }
        
        [Required]
        [RegularExpression(@"Masculino|Femenino|Otro|Prefiero no decirlo", ErrorMessage = "El género no es válido.")]
        public string Genero { get; set; } = string.Empty;
    }
}