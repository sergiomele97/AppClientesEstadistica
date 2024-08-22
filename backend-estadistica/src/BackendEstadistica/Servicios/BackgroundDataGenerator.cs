using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace BackendEstadistica.Servicios
{
    public class BackgroundDataGenerator : BackgroundService
    {
        private readonly ILogger<BackgroundDataGenerator> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BackgroundDataGenerator(
            ILogger<BackgroundDataGenerator> logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var estadisticasRepositorio = scope.ServiceProvider.GetRequiredService<IEstadisticasRepositorio>();
                        var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                        // Obtener los países para inicializar ClienteFaker
                        var paises = estadisticasRepositorio.GetPaises();
                        var clienteFaker = new ClienteFaker(paises);

                        // Lógica para crear el cliente
                        var clienteDto = clienteFaker.Generate();
                        var nuevoCliente = mapper.Map<Cliente>(clienteDto);
                        estadisticasRepositorio.CrearCliente(nuevoCliente);

                        _logger.LogInformation("Cliente creado correctamente");
                    }

                    // Esperar 5 segundos antes de la siguiente ejecución
                    await Task.Delay(TimeSpan.FromMinutes(20), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al crear cliente");
                }
            }
        }
    }
}