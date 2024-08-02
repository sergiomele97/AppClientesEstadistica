
using Microsoft.EntityFrameworkCore;

namespace BackendEstadistica.Contexto
{
    /* En .NET Entity Framework, el contexto de la base de datos (DbContext) 
     * actúa como una puerta de enlace entre la aplicación y la base de datos.
     * Define las colecciones de entidades (DbSet) que representan las tablas de la base de datos.
     */

    public class ContextoBBDD : DbContext
    {

        // Constructor de la clase:
        // Se pasan opciones al constructor de la clase base DbContext.
        public ContextoBBDD(DbContextOptions<ContextoBBDD> options)
        : base(options)
        {
        }

        // DEFINIR LAS TABLAS AQUÍ:
        public DbSet<Usuario> Usuario { get; set; }     // 1º Tabla

        public DbSet<EnvioEjemplo> EnvioEjemplo { get; set; } // 2ª Tabla


    }
}
