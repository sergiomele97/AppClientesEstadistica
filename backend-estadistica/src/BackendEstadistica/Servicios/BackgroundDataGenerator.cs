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

        //------------------Configurar-volumenes-de-creación-----------------------------

        int frecuenciaMinutos = 20;
        int volumenClientes = 1;
        int volumenTransacciones = 10;
        int volumenConversiones = 5;


        //------------------Fin-de-configurar-volumenes-de-creación----------------------
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

                        // 1. Lógica para crear el cliente

                        for (int i = 0; i < volumenClientes; i++)
                        {
                            var clienteDto = clienteFaker.Generate();
                            var nuevoCliente = mapper.Map<Cliente>(clienteDto);
                            estadisticasRepositorio.CrearCliente(nuevoCliente);

                            _logger.LogInformation("Cliente creado correctamente");
                        }


                        // 2. Lógica para crear transaccion

                        // Seleccionamos dos clientes random y se los pasamos en una lista
                        for (int i = 0; i < volumenTransacciones; i++)
                        {
                            var cliente_origen = estadisticasRepositorio.GetRandomClient();
                            var cliente_destino = estadisticasRepositorio.GetRandomClient();

                            var transaccionFaker = new TransaccionFaker(cliente_origen, cliente_destino);
                            var transaccionDto = transaccionFaker.Generate();

                            var nuevaTransaccion = mapper.Map<Transaccion>(transaccionDto);
                            estadisticasRepositorio.CrearTransaccion(nuevaTransaccion);

                            // Detectar si esta transacción es un outlier
                            estadisticasRepositorio.DetectarOutliers();
                        }


                        // 3. Lógica para crear conversion
                        for (int i = 0; i < volumenConversiones; i++)
                        {
                            Cliente cliente = estadisticasRepositorio.GetRandomClient();
                            var conversionFaker = new ConversionFaker(cliente);

                            var conversionDto = conversionFaker.Generate();
                            var nuevaConversion = mapper.Map<Conversion>(conversionDto);
                            estadisticasRepositorio.CrearConversion(nuevaConversion);

                            _logger.LogInformation("Conversión creada correctamente");
                        }

                    }

                    // Esperar 5 segundos antes de la siguiente ejecución
                    await Task.Delay(TimeSpan.FromMinutes(frecuenciaMinutos), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al crear cliente");
                }
            }
        }
    }
}