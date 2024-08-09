
using BackendEstadistica.Contexto;
using Microsoft.EntityFrameworkCore;

namespace BackendEstadistica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IEstadisticasRepositorio, EstadisticasRepositorio>();


            builder.Services.AddControllers();

            // Servicio para el mapeado
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<ContextoBBDD>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configuración de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    builder => builder
                        .WithOrigins("http://localhost:4200")                                               // URL FRONT-END LOCAL
                        .AllowAnyHeader()
                        .AllowAnyMethod());

                options.AddPolicy("AllowAzureHost",
                    builder => builder
                        .WithOrigins("https://salmon-hill-0d0baa503.5.azurestaticapps.net")                 // URL FRONT-END PRODUCCIÓN
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            // Build
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Apply migrations at startup
            ApplyMigrations(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                // Allow Development
                app.UseCors("AllowLocalhost");
            } else
            {
                // Allow Production
                app.UseCors("AllowAzureHost");
            }

            app.UseHttpsRedirection();

            // Habilita CORS
            app.UseCors("AllowLocalhost");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }


        // Aplicar migraciones automaticamente en la BBDD Azure
        private static void ApplyMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ContextoBBDD>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
        }
    }
}
