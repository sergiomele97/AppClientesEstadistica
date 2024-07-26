
using Microsoft.EntityFrameworkCore;

namespace BackendEstadistica.Contexto
{
    public class ContextoBBDD : DbContext
    {
        public ContextoBBDD(DbContextOptions<ContextoBBDD> options)
        : base(options)
        {
        }

        // Define tus DbSet aquí.
        // DbSet = entiedad = tabla     Atributos = columnas
        public DbSet<Usuario> Usuario { get; set; }


    }
}
