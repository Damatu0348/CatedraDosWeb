using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiWebDos.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace apiWebDos.Src.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions): base(dbContextOptions)
        {
            
        }
        public DbSet<Usuario> Usuario {get; set;} = null!;
    }
}