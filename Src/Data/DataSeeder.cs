using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiWebDos.Src.Models;
using Bogus;

namespace apiWebDos.Src.Data
{
    public class DataSeeder
    {
        private static Random random = new Random();
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDBContext>();

                var existingRuts = new HashSet<string>();
                var generos = new string[] {"Masculino", "Femenino", "Otro", "Prefiero no decirlo"};

                if(!context.Usuarios.Any())
                {
                    var userFaker = new Faker<Usuario>()
                        .RuleFor(u => u.Nombre, f => f.Person.FullName)
                        .RuleFor(u => u.Correo, f => f.Person.Email)
                        .RuleFor(u => u.FechaNacimiento, f => GenerarFechaNacimientoAleatoria())
                        .RuleFor(u => u.Genero, f => generos[random.Next(0, generos.Length)]);

                    var users = userFaker.Generate(10);
                    context.Usuarios.AddRange(users);
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
        }

        private static DateOnly GenerarFechaNacimientoAleatoria()
        {
            var random = new Random();
            int startYear = DateTime.Now.Year - 100; // Fecha mínima hace 100 años
            int endYear = DateTime.Now.Year - 18; // Fecha máxima hace 18 años (mayor de edad)
            int year = random.Next(startYear, endYear);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            
            return new DateOnly(year, month, day);
        }
        private static string GenerateUniqueRandomRut(HashSet<string> existingRuts)
        {
            string rut;
            do
            {
                rut = GenerateRandomRut();
            } while (existingRuts.Contains(rut));

            existingRuts.Add(rut);
            return rut;
        }

        private static string GenerateRandomRut()
        {
            Random random = new();
            int rutNumber = random.Next(1, 99999999); // Número aleatorio de 7 o 8 dígitos
            int verificator = CalculateRutVerification(rutNumber);
            string verificatorStr = verificator.ToString();
            if(verificator == 10){
                verificatorStr = "k";
            }

            return $"{rutNumber}-{verificatorStr}";
        }

        private static int CalculateRutVerification(int rutNumber)
        {
            int[] coefficients = { 2, 3, 4, 5, 6, 7 };
            int sum = 0;
            int index = 0;

            while (rutNumber != 0)
            {
                sum += rutNumber % 10 * coefficients[index];
                rutNumber /= 10;
                index = (index + 1) % 6;
            }

            int verification = 11 - (sum % 11);
            return verification == 11 ? 0 : verification;
        }
    }
}
