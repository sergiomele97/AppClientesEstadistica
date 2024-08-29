namespace BackendEstadistica.Contexto;

/* En .NET Entity Framework, el contexto de la base de datos (DbContext) 
 * actúa como una puerta de enlace entre la aplicación y la base de datos.
 * Define las colecciones de entidades (DbSet) que representan las tablas de la base de datos.
 */

public class ContextoBBDD : IdentityDbContext<ApplicationUser>
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

    public DbSet<Divisa> Divisa { get; set; } // 6ª Tabla

    public DbSet<ClienteConBalanceViewModel> ClientesConBalance { get; set; } //Vista de clientes con mas datos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Necesario para Identity

        // Configuración de relaciones de las entidades
        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.ClienteOrigen)
            .WithMany(c => c.TransaccionesOrigen)
            .HasForeignKey(t => t.ClienteOrigenId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.ClienteDestino)
            .WithMany(c => c.TransaccionesDestino)
            .HasForeignKey(t => t.ClienteDestinoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Pais)
            .WithMany(p => p.Clientes)
            .HasForeignKey(c => c.PaisId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Divisa>()
            .Property(d => d.DivisaId)
            .ValueGeneratedOnAdd(); ;
            
        // Cargar los datos de países desde el archivo JSON
        var paises = LoadPaisesJson("./data/listaPaises.json");

        modelBuilder.Entity<Pais>().HasData(paises);
    }

    // Método para cargar los países desde un archivo JSON
    private List<Pais> LoadPaisesJson(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        var paises = JsonSerializer.Deserialize<List<Pais>>(jsonString);
        return paises;
    }

}
