
using BackendEstadistica.Contexto;
using BackendEstadistica.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;

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
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDbContext<ContextoBBDD>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Filter.ByExcluding(logEvent => logEvent.Level == Serilog.Events.LogEventLevel.Debug) // Excluir eventos de nivel Debug
                .WriteTo.Console()
                .WriteTo.File("Logs/logClientes.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog(); // Usa Serilog como el logger

            builder.Services.AddControllers();

            // Configurar Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Configuración de las opciones de usuario
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ContextoBBDD>()
            .AddDefaultTokenProviders();

            // Configurar JWT
            //var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
            //builder.Services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidateAudience = true,
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});

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
