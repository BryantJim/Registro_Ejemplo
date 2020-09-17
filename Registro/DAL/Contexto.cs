using Microsoft.EntityFrameworkCore;
using Registro.Models;

namespace Registro.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) :base(options){}
        public DbSet<Estudiantes> Estudiantes { get; set; }
        
    }
}