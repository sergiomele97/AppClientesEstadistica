using BackendEstadistica.SignalR;

namespace BackendEstadistica;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuración de los servicios
        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IEstadisticasRepositorio, EstadisticasRepositorio>();
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddDbContext<ContextoBBDD>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Filter.ByExcluding(logEvent => logEvent.Level == Serilog.Events.LogEventLevel.Debug)
            .WriteTo.Console()
            .WriteTo.File("Logs/logClientes.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ContextoBBDD>()
        .AddDefaultTokenProviders();

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

        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddSignalR();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost",
                builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            options.AddPolicy("AllowAzureHost",
                builder => builder
                    .WithOrigins("https://salmon-hill-0d0baa503.5.azurestaticapps.net")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHostedService<BackgroundDataGenerator>();

        var app = builder.Build();

        ApplyMigrations(app);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowLocalhost");
        }
        else
        {
            app.UseCors("AllowAzureHost");
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.MapHub<NotificationHub>("/notificationHub");

        app.Run();
    }

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
