using BackendEstadistica.SignalR;

namespace BackendEstadistica;

public class Program
{
    public static void Main(string[] args)
    {
        // Crea un builder para configurar la aplicaci�n web.
        var builder = WebApplication.CreateBuilder(args);

        // Configuraci�n de servicios para la aplicaci�n.

        // Registro de repositorios con alcance de solicitud (Scoped).
        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IEstadisticasRepositorio, EstadisticasRepositorio>();

        // Agrega los servicios necesarios para los controladores de API.
        builder.Services.AddControllers();



        // A�ade Signal R
        builder.Services.AddSignalR();

        // Configura AutoMapper con el perfil de mapeo definido.
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddHttpClient<DivisaRepositorio>();
        // Configura Entity Framework Core para usar SQL Server.
        builder.Services.AddDbContext<ContextoBBDD>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<DivisaRepositorio>();
        // Configura Serilog para logging.
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()  // Nivel m�nimo de logging.
            .Filter.ByExcluding(logEvent => logEvent.Level == Serilog.Events.LogEventLevel.Debug)  // Excluye logs de nivel Debug.
            .WriteTo.Console()  // Escribe logs en la consola.
            .WriteTo.File("Logs/logClientes.txt", rollingInterval: RollingInterval.Day)  // Escribe logs en un archivo con un intervalo de rotaci�n diario.
            .CreateLogger();

        builder.Host.UseSerilog();  // Usa Serilog como el proveedor de logging.

        // Configura Identity para la autenticaci�n de usuarios.
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;  // Requiere que los correos electr�nicos sean �nicos.
        })
        .AddEntityFrameworkStores<ContextoBBDD>()  // Usa EF Core para el almacenamiento de usuarios.
        .AddDefaultTokenProviders();  // Agrega proveedores de tokens por defecto.

        // Configuraci�n del esquema de autenticaci�n JWT.
        var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);  // Clave secreta para la firma de tokens.
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  // Define el esquema de autenticaci�n.
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  // Define el esquema de desaf�o.
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;  // Permite el uso de HTTP en desarrollo.
            x.SaveToken = true;  // Guarda el token en el contexto de la solicitud.
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,  // Valida la clave de firma del emisor.
                IssuerSigningKey = new SymmetricSecurityKey(key),  // Clave de firma sim�trica.
                ValidateIssuer = true,  // Valida el emisor del token.
                ValidIssuer = builder.Configuration["Jwt:Issuer"],  // Emisor v�lido del token.
                ValidateAudience = true,  // Valida el p�blico del token.
                ValidAudience = builder.Configuration["Jwt:Audience"],  // P�blico v�lido del token.
                ValidateLifetime = true,  // Valida la vida �til del token.
                ClockSkew = TimeSpan.Zero  // Configura el desfase del reloj a cero.
            };
        });

        // Registra el servicio para la generaci�n de tokens.
        builder.Services.AddScoped<ITokenService, TokenService>();
        // Registra el servicio TransaccionService.
        builder.Services.AddScoped<TransaccionService>();
        // Configuraci�n de CORS para permitir solicitudes desde or�genes espec�ficos.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost",
                builder => builder
                    .WithOrigins("http://localhost:4200")  // Permite solicitudes desde localhost:4200.
                    .AllowAnyHeader()  // Permite cualquier encabezado.
                    .AllowAnyMethod()  // Permite cualquier m�todo HTTP.
                    .AllowCredentials());  // Permite el uso de credenciales.

            options.AddPolicy("AllowAzureHost",
                builder => builder
                    .WithOrigins("https://wonderful-meadow-07530fe03.5.azurestaticapps.net")  // Permite solicitudes desde el host de Azure.
                    .AllowAnyHeader()  // Permite cualquier encabezado.
                    .AllowAnyMethod()  // Permite cualquier m�todo HTTP.
                    .AllowCredentials());  // Permite el uso de credenciales.
            options.AddPolicy("AllowTrans",
                builder => builder
                    .WithOrigins("http://localhost:4200", "http://172.30.137.232") // Permite solicitudes desde localhost y la IP 172.30.137.232
                    .AllowAnyHeader()  // Permite cualquier encabezado.
                    .AllowAnyMethod()  // Permite cualquier m�todo HTTP.
                    .AllowCredentials());  // Permite el uso de credenciales.
        });

        // Configura el explorador de endpoints y Swagger para la documentaci�n de la API.
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Registra un servicio en segundo plano para la generaci�n de datos.
        builder.Services.AddHostedService<BackgroundDataGenerator>();

        // Construye la aplicaci�n.
        var app = builder.Build();

        // Aplica las migraciones de base de datos.
        ApplyMigrations(app);

        // Configuraci�n del middleware seg�n el entorno.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();  // Habilita Swagger en desarrollo.
            app.UseSwaggerUI();  // Habilita la interfaz de usuario de Swagger.
            app.UseCors("AllowTrans");  // Usa la pol�tica de CORS para localhost.
        }
        else
        {
            app.UseCors("AllowAzureHost");  // Usa la pol�tica de CORS para el host de Azure.
        }

        // Configura el middleware de redirecci�n HTTPS, autenticaci�n y autorizaci�n.
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        // Mapea los controladores para manejar las solicitudes HTTP.
        app.MapControllers();


        // Configurar el endpoint de SignalR para NotificationHub
        app.MapHub<NotificationHub>("/notificationHub");


        // Ejecuta la aplicaci�n.
        app.Run();
    }

    // M�todo para aplicar las migraciones de base de datos.
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

                // Crear roles al iniciar la aplicaci�n
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                CreateRoles(roleManager, userManager).Wait();
            }
            catch (Exception ex)
            {
                // Registra cualquier error que ocurra durante la aplicaci�n de migraciones.
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }

    private static async Task CreateRoles(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        // Definir roles
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

        // Crear un usuario Admin por defecto si no existe
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
