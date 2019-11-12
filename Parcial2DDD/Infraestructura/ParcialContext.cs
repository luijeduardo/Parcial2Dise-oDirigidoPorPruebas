using Dominio.Entities;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class ParcialContext : DbContextBase
    {
        public ParcialContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
    }
}
