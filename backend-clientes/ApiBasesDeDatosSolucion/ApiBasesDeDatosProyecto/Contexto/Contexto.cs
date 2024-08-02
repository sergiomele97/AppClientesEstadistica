using ApiBasesDeDatosProyecto.IDentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiBasesDeDatosProyecto.Context
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Para activar el seguimiento de consultas,
            // se debe establecer el nivel de seguimiento en Debug
            // en el archivo de configuración de la aplicación (appsettings.json)
            // y se debe agregar el siguiente código 
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Necesario para Identity

            // Agregar tres paises por defecto a la base de datos
            modelBuilder.Entity<Pais>().HasData(
                new Pais { Id = 1, Nombre = "España", Divisa = "USD", Iso3 = "ESP" },
                new Pais { Id = 2, Nombre = "Francia", Divisa = "EUR", Iso3 = "FRA" },
                new Pais { Id = 3, Nombre = "Italia", Divisa = "USD", Iso3 = "ITA" }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Email = "das@gmail.com", UserName = "PEPE1" },
                new Usuario { Id = 2, Email = "daaaaaaas@gmail.com", UserName = "PEPE2" },
                new Usuario { Id = 3, Email = "dadsdsds@gmail.com", UserName = "PEPE3" }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nombre = "Juan",
                    Apellido = "Perez",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    PaisId = 1,
                    Empleo = "Delincuente"
                },
                new Cliente
                {
                    Id = 2,
                    Nombre = "Maria",
                    Apellido = "Lopez",
                    FechaNacimiento = new DateTime(1985, 5, 23),
                    PaisId = 2,
                    Empleo = "Profesor"
                },
                new Cliente
                {
                    Id = 3,
                    Nombre = "Carlos",
                    Apellido = "Gomez",
                    FechaNacimiento = new DateTime(1978, 11, 12),
                    PaisId = 3,
                    Empleo = "Abogado"
                }
            );

            modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Pais)
            .WithMany(p => p.Clientes)
            .HasForeignKey(c => c.PaisId);
        }
    }
}