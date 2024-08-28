namespace BackendEstadistica.Servicios;

public class BackgroundDataGenerator : BackgroundService
{
    private readonly ILogger<BackgroundDataGenerator> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    //------------------Configurar-volumenes-de-creación-----------------------------

    int frecuenciaMinutos = 2000;
    int volumenClientes = 5;
    int volumenTransacciones = 10;
    int volumenConversiones = 3;


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
                        var paises = await estadisticasRepositorio.GetPaisesAsync(); 
                        var clienteFaker = new ClienteFaker(paises);

                        // 1. Lógica para crear el cliente
                        for (int i = 0; i < volumenClientes; i++)
                        {
                            var clienteDto = clienteFaker.Generate();
                            var nuevoCliente = mapper.Map<Cliente>(clienteDto);
                            await estadisticasRepositorio.CrearClienteAsync(nuevoCliente); 

                        _logger.LogInformation("Cliente creado correctamente");
                    }

                        // 2. Lógica para crear transacción
                        for (int i = 0; i < volumenTransacciones; i++)
                        {
                            var clienteOrigen = await estadisticasRepositorio.GetRandomClientAsync();
                            var clienteDestino = await estadisticasRepositorio.GetRandomClientAsync(); 

                        var transaccionFaker = new TransaccionFaker(clienteOrigen, clienteDestino);
                        var transaccionDto = transaccionFaker.Generate();

                            var nuevaTransaccion = mapper.Map<Transaccion>(transaccionDto);
                            await estadisticasRepositorio.CrearTransaccionAsync(nuevaTransaccion); 

                            // Detectar si esta transacción es un outlier
                            await estadisticasRepositorio.DetectarOutliersAsync();
                        }

                        // 3. Lógica para crear conversión
                        for (int i = 0; i < volumenConversiones; i++)
                        {
                            var cliente = await estadisticasRepositorio.GetRandomClientAsync(); 
                            var conversionFaker = new ConversionFaker(cliente);

                            var conversionDto = conversionFaker.Generate();
                            var nuevaConversion = mapper.Map<Conversion>(conversionDto);
                            await estadisticasRepositorio.CrearConversionAsync(nuevaConversion);

                        _logger.LogInformation("Conversión creada correctamente");
                    }
                }

                // Esperar antes de la siguiente ejecución
                await Task.Delay(TimeSpan.FromMinutes(frecuenciaMinutos), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear datos en segundo plano");
            }
        }
    }
}
