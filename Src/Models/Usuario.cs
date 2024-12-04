using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiWebDos.Src.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario {get; set;}

        [StringLength(20, MinimumLength = 3, ErrorMessage = "El RUT debe tener entre 3 y 20 caracteres.")]
        public string Nombre {get; set;} = string.Empty;

        [EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        public string Correo {get; set;} = string.Empty;

        [DataType(DataType.Date)]
        [CustomValidation(typeof(Usuario), "ValidateBirthDate")]
        public string FechaNacimiento { get; set; } = string.Empty;
        
        [RegularExpression(@"Masculino|Femenino|Otro|Prefiero no decirlo", ErrorMessage = "El género no es válido.")]
        public string Genero { get; set; } = string.Empty;

        public static ValidationResult? ValidateBirthDate(DateTime FechaNacimiento, ValidationContext context)
        {
            return FechaNacimiento < DateTime.Now ? ValidationResult.Success : new ValidationResult("La fecha de nacimiento debe ser menor a la fecha actual.");
        }


    }
}