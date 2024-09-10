namespace BackendEstadistica;
/// <summary>
/// La clase principal que configura y ejecuta la aplicación web.
/// </summary>
public class Program
{
    /// <summary>
    /// El punto de entrada principal para la aplicación.
    /// </summary>
    /// <param name="args">Argumentos de la línea de comandos pasados a la aplicación.</param>
    public static async Task Main(string[] args)
    {
        // Crea un builder para configurar la aplicación web.
        var builder = WebApplication.CreateBuilder(args);

        // Configuración de servicios para la aplicación.

        // Registra los repositorios con un alcance de solicitud.
        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IEstadisticasRepositorio, EstadisticasRepositorio>();

        // Agrega los servicios necesarios para los controladores de API.
        builder.Services.AddControllers();

        // Configura SignalR para el soporte de WebSockets.
        builder.Services.AddSignalR();

        // Configura AutoMapper con el perfil de mapeo definido.
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        // Configura Entity Framework Core para usar SQL Server.
        builder.Services.AddDbContext<ContextoBBDD>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Configura Serilog para logging.
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Filter.ByExcluding(logEvent => logEvent.Level == Serilog.Events.LogEventLevel.Debug)
            .WriteTo.Console()
            .WriteTo.File("Logs/logClientes.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.Host.UseSerilog();  // Configura Serilog como el proveedor de logging.

        // Configura Identity para la autenticación de usuarios.
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ContextoBBDD>()
        .AddDefaultTokenProviders();

        // Configura la autenticación JWT.
        var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        // Registra los servicios para la generación de tokens y otros servicios.
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<TransaccionService>();

        // Registra el servicio SignalRService
        builder.Services.AddScoped<SignalRService>(provider =>
        {
            var contextoBBDD = provider.GetRequiredService<ContextoBBDD>();
            var hubContext = provider.GetRequiredService<IHubContext<NotificationHub>>();
            var estadisticasRepositorio = provider.GetRequiredService<IEstadisticasRepositorio>();
            return new SignalRService(contextoBBDD, hubContext, estadisticasRepositorio);
        });

        // Configura CORS para permitir solicitudes desde orígenes específicos.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost",
                builder => builder
                    .WithOrigins("http://localhost:4200")  // Permite solicitudes desde localhost:4200.
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            options.AddPolicy("AllowAzureHost",
                builder => builder
                    .WithOrigins("https://wonderful-meadow-07530fe03.5.azurestaticapps.net", "https://cleancashcourierapi-fdg9f7d4chb4gshy.spaincentral-01.azurewebsites.net")  // Permite solicitudes desde el host de Azure.
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            options.AddPolicy("AllowTrans",
                builder => builder
                    .WithOrigins("http://localhost:4200", "http://172.30.137.232", "https://cleancashcourierapi-fdg9f7d4chb4gshy.spaincentral-01.azurewebsites.net")  // Permite solicitudes desde localhost y la IP 172.30.137.232.
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
        });

        // Configura el explorador de endpoints y Swagger para la documentación de la API.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Registra un servicio en segundo plano para la generación de datos.
        builder.Services.AddHostedService<BackgroundDataGenerator>();

        // Construye la aplicación.
        var app = builder.Build();

        // Aplica las migraciones de base de datos.
        ApplyMigrations(app);


        // Configura el middleware según el entorno.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowTrans");
        }
        else
        {
            app.UseCors("AllowAzureHost");
        }

        // Configura el middleware de redirección HTTPS, autenticación y autorización.
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        // Mapea los controladores para manejar las solicitudes HTTP.
        app.MapControllers();

        // Configura el endpoint de SignalR para NotificationHub.
        app.MapHub<NotificationHub>("/notificationHub");

        // Iniciar el servicio de SignalR
        using (var scope = app.Services.CreateScope())
        {
            var signalRService = scope.ServiceProvider.GetRequiredService<SignalRService>();
            await signalRService.StartListeningAsync();

            // Detener el servicio de SignalR al detener la aplicación
            app.Lifetime.ApplicationStopping.Register(async () =>
            {
                await signalRService.StopListeningAsync();
            });
        }

        // Ejecuta la aplicación.
        app.Run();
    }

    /// <summary>
    /// Aplica las migraciones de base de datos y crea roles iniciales.
    /// </summary>
    /// <param name="app">La instancia de la aplicación web.</param>
    private static void ApplyMigrations(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                // Obtiene el contexto de base de datos y aplica las migraciones.
                var context = services.GetRequiredService<ContextoBBDD>();
                context.Database.Migrate();

                // Crea roles y un usuario admin por defecto al iniciar la aplicación.
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                CreateRoles(roleManager, userManager).Wait();
            }
            catch (Exception ex)
            {
                // Registra cualquier error que ocurra durante la aplicación de migraciones.
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }

    /// <summary>
    /// Crea roles iniciales y un usuario admin por defecto si no existen.
    /// </summary>
    /// <param name="roleManager">El administrador de roles de Identity.</param>
    /// <param name="userManager">El administrador de usuarios de Identity.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    private static async Task CreateRoles(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        // Definir roles.
        string[] roleNames = { "Admin", "User", "Manager" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Crear un usuario Admin por defecto si no existe.
        var user = await userManager.FindByEmailAsync("admin@example.com");
        if (user == null)
        {
            var adminUser = new ApplicationUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com"
            };
            var result = await userManager.CreateAsync(adminUser, "AdminPassword123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}