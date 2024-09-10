namespace BackendEstadistica.Contexto;

/// <summary>
/// Contexto de la base de datos que actúa como una puerta de enlace entre la aplicación y la base de datos.
/// Define las colecciones de entidades que representan las tablas y vistas de la base de datos.
/// Hereda de <see cref="IdentityDbContext{ApplicationUser}"/> para incluir la funcionalidad de Identity.
/// </summary>
public class ContextoBBDD : IdentityDbContext<ApplicationUser>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ContextoBBDD"/>.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto de la base de datos.</param>
    public ContextoBBDD(DbContextOptions<ContextoBBDD> options)
        : base(options)
    {
    }

    /// <summary>
    /// Representa la tabla de usuarios en la base de datos.
    /// </summary>
    public DbSet<Usuario> Usuario { get; set; }

    /// <summary>
    /// Representa la tabla de clientes en la base de datos.
    /// </summary>
    public DbSet<Cliente> Clientes { get; set; }

    /// <summary>
    /// Representa la tabla de países en la base de datos.
    /// </summary>
    public DbSet<Pais> Paises { get; set; }

    /// <summary>
    /// Representa la tabla de transacciones en la base de datos.
    /// </summary>
    public DbSet<Transaccion> Transacciones { get; set; }

    /// <summary>
    /// Representa la tabla de conversiones en la base de datos.
    /// </summary>
    public DbSet<Conversion> Conversion { get; set; }

    /// <summary>
    /// Representa la tabla de divisas en la base de datos.
    /// </summary>
    public DbSet<Divisa> Divisa { get; set; }

    /// <summary>
    /// Representa una vista de clientes con balance en la base de datos.
    /// </summary>
    public DbSet<ClienteConBalance> ClientesConBalance { get; set; }

    /// <summary>
    /// Representa una tabla de procesos de transacciones en la base de datos.
    /// </summary>
    public DbSet<TransaccionProceso> TransaccionesProcesos { get; set; }

    /// <summary>
    /// Configura el modelo de la base de datos utilizando el <see cref="ModelBuilder"/>.
    /// Configura las relaciones entre las entidades y la carga inicial de datos.
    /// </summary>
    /// <param name="modelBuilder">El <see cref="ModelBuilder"/> utilizado para configurar el modelo.</param>
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
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ClienteConBalance>()
            .HasNoKey() // Indica que esta entidad no tiene clave primaria, ya que es una vista.
            .ToView("ClientesConBalance");

        // Cargar los datos de países desde el archivo JSON
        var paises = LoadPaisesJson("./data/listaPaises.json");
        var divisas = LoadListDivisasJson("./data/expdata.json");

        modelBuilder.Entity<Pais>().HasData(paises);
        modelBuilder.Entity<Divisa>().HasData(divisas);
    }

    /// <summary>
    /// Carga los países desde un archivo JSON.
    /// </summary>
    /// <param name="filePath">La ruta del archivo JSON que contiene los datos de los países.</param>
    /// <returns>Una lista de objetos <see cref="Pais"/> cargados desde el archivo JSON.</returns>
    private List<Pais> LoadPaisesJson(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        var paises = System.Text.Json.JsonSerializer.Deserialize<List<Pais>>(jsonString);
        return paises;
    }
    // Método para cargar los países desde un archivo JSON
    private List<Divisa> LoadListDivisasJson(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        var divisas = System.Text.Json.JsonSerializer.Deserialize<List<Divisa>>(jsonString);
        return divisas;
    }
}
