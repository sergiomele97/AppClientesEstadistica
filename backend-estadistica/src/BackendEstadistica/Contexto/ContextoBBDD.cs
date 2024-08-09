namespace BackendEstadistica.Contexto;

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
    public DbSet<Usuario> Usuario { get; set; } // 1º Tabla

    public DbSet<Cliente> Clientes { get; set; } // 2ª Tabla

    public DbSet<Pais> Paises { get; set; } // 3ª Tabla

    public DbSet<Transaccion> Transacciones { get; set; } // 4ª Tabla

    public DbSet<Conversion> Conversion { get; set; } // 5ª Tabla

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Relación Cliente-Pais
        modelBuilder.Entity<Cliente>()
       .HasOne(c => c.Pais)
       .WithMany(p => p.Clientes)
       .HasForeignKey(c => c.PaisId);

        // Relación Cliente-Conversion
        modelBuilder.Entity<Conversion>()
            .HasOne(c => c.Cliente)
            .WithMany(c => c.Conversiones)
            .HasForeignKey(c => c.ClienteId);

        // Relación Transacción con Cliente (envío y recibo)
        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.ClienteDestino)
            .WithMany(c => c.TransaccionesDestino)
            .HasForeignKey(t => t.ClienteDestinoId)
            .OnDelete(DeleteBehavior.Restrict); // Para evitar ciclos de eliminación

        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.ClienteOrigen)
            .WithMany(c => c.TransaccionesOrigen)
            .HasForeignKey(t => t.ClienteOrigenId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}
