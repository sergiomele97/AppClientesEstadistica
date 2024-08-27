namespace BackendEstadistica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Crea un nuevo builder para configurar los servicios y la aplicación.
            var builder = WebApplication.CreateBuilder(args);

            // Añade servicios al contenedor.
            // Registra repositorios y servicios específicos
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IEstadisticasRepositorio, EstadisticasRepositorio>();

            // Añade soporte para controladores
            builder.Services.AddControllers();

            // Configura AutoMapper para el mapeo de objetos
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Configura el contexto de la base de datos usando SQL Server
            builder.Services.AddDbContext<ContextoBBDD>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configura Serilog para el registro de eventos
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Filter.ByExcluding(logEvent => logEvent.Level == Serilog.Events.LogEventLevel.Debug) // Excluir eventos de nivel Debug
                .WriteTo.Console()
                .WriteTo.File("Logs/logClientes.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Configura el host para usar Serilog como el logger
            builder.Host.UseSerilog();

            // Configura Identity para manejar la autenticación y autorización de usuarios
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Asegura que cada usuario tenga un correo electrónico único
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ContextoBBDD>() // Usa el contexto de EF Core para almacenar los usuarios
            .AddDefaultTokenProviders(); // Proveedores de token predeterminados

            // Configura JWT (JSON Web Token) para la autenticación
            var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]); // Obtiene la clave de firma desde la configuración
            builder.Services.AddAuthentication(x =>
            {
                // Configura el esquema de autenticación predeterminado y el esquema de desafío
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                // Configura el middleware JWT
                x.RequireHttpsMetadata = false; // Si no usas HTTPS en desarrollo
                x.SaveToken = true; // Guarda el token en el contexto de la solicitud
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // Valida la clave de firma del token
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Usa la clave de firma configurada
                    ValidateIssuer = true, // Valida el emisor del token
                    ValidIssuer = builder.Configuration["Jwt:Issuer"], // Emisor válido
                    ValidateAudience = true, // Valida el receptor del token
                    ValidAudience = builder.Configuration["Jwt:Audience"], // Receptor válido
                    ValidateLifetime = true, // Valida la fecha de expiración del token
                    ClockSkew = TimeSpan.Zero // Permite que la fecha de expiración no tenga margen de error
                };
            });

            // Configura el servicio para generar JWT tokens
            builder.Services.AddScoped<ITokenService, TokenService>();

            // Configuración de CORS (Cross-Origin Resource Sharing)
            builder.Services.AddCors(options =>
            {
                // Política para permitir solicitudes desde el front-end en desarrollo
                options.AddPolicy("AllowLocalhost",
                    builder => builder
                        .WithOrigins("http://localhost:4200") // URL del front-end local
                        .AllowAnyHeader()
                        .AllowAnyMethod());

                // Política para permitir solicitudes desde el front-end en producción
                options.AddPolicy("AllowAzureHost",
                    builder => builder
                        .WithOrigins("https://salmon-hill-0d0baa503.5.azurestaticapps.net") // URL del front-end en producción
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            // Agrega Swagger para documentación de la API
            builder.Services.AddEndpointsApiExplorer(); // Agrega el explorador de puntos finales para Swagger
            builder.Services.AddSwaggerGen(); // Agrega Swagger para documentación de la API

            // Agrega servicio en segundo plano
            builder.Services.AddHostedService<BackgroundDataGenerator>(); // Servicio en segundo plano para generar datos

            var app = builder.Build(); // Construye la aplicación

            // Aplica migraciones automáticamente al iniciar la aplicación
            ApplyMigrations(app);

            // Configura el pipeline de solicitudes HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Usa Swagger en desarrollo
                app.UseSwaggerUI(); // Interfaz de usuario de Swagger
                app.UseCors("AllowLocalhost"); // Usa la política CORS para desarrollo
            }
            else
            {
                app.UseCors("AllowAzureHost"); // Usa la política CORS para producción
            }

            app.UseHttpsRedirection(); // Redirige HTTP a HTTPS

            app.UseAuthentication(); // Habilita el middleware de autenticación
            app.UseAuthorization(); // Habilita el middleware de autorización

            app.MapControllers(); // Mapea los controladores a las rutas

            app.Run(); // Ejecuta la aplicación
        }

        // Aplicar migraciones automáticamente al iniciar la aplicación
        private static void ApplyMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ContextoBBDD>();
                    context.Database.Migrate(); // Aplica las migraciones pendientes a la base de datos
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database."); // Registra el error si ocurre uno
                }
            }
        }
    }
}
