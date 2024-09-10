namespace BackendEstadistica.Servicios;

/// <summary>
/// Servicio en segundo plano para generar datos ficticios de forma periódica.
/// </summary>
public class BackgroundDataGenerator : BackgroundService
{
    private readonly ILogger<BackgroundDataGenerator> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    /// <summary>
    /// Frecuencia en minutos con la que se ejecuta el generador de datos.
    /// </summary>
    private readonly int _frecuenciaMinutos;

    /// <summary>
    /// Volumen de datos de clientes a generar en cada ejecución.
    /// </summary>
    private readonly int _volumenClientes;

    /// <summary>
    /// Volumen de datos de transacciones a generar en cada ejecución.
    /// </summary>
    private readonly int _volumenTransacciones;

    /// <summary>
    /// Volumen de datos de conversiones a generar en cada ejecución.
    /// </summary>
    private readonly int _volumenConversiones;

    /// <summary>
    /// Volumen de datos de outliers a generar en cada ejecución.
    /// </summary>
    private readonly int _volumenOutliers;

    /// <summary>
    /// Volumen de datos de divisas a generar en cada ejecución.
    /// </summary>
    private readonly int _volumenDivisas;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="BackgroundDataGenerator"/>.
    /// </summary>
    /// <param name="logger">El logger para registrar información y errores.</param>
    /// <param name="serviceScopeFactory">La fábrica para crear ámbitos de servicio.</param>
    /// <param name="configuration">La configuración de la aplicación.</param>
    public BackgroundDataGenerator(
        ILogger<BackgroundDataGenerator> logger,
        IServiceScopeFactory serviceScopeFactory,
        IConfiguration configuration)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;

        _frecuenciaMinutos = configuration.GetValue<int>("DataGenerator:FrecuenciaMinutos");
        _volumenClientes = configuration.GetValue<int>("DataGenerator:VolumenClientes");
        _volumenTransacciones = configuration.GetValue<int>("DataGenerator:VolumenTransacciones");
        _volumenConversiones = configuration.GetValue<int>("DataGenerator:VolumenConversiones");
        _volumenOutliers = configuration.GetValue<int>("DataGenerator:VolumenOutliers");
        _volumenDivisas = configuration.GetValue<int>("DataGenerator:VolumenDivisas");

        // Validar valores de configuración
        if (_frecuenciaMinutos <= 0) throw new ArgumentOutOfRangeException(nameof(_frecuenciaMinutos), "La frecuencia en minutos debe ser mayor que cero.");
        if (_volumenClientes < 0) throw new ArgumentOutOfRangeException(nameof(_volumenClientes), "El volumen de clientes no puede ser negativo.");
        if (_volumenTransacciones < 0) throw new ArgumentOutOfRangeException(nameof(_volumenTransacciones), "El volumen de transacciones no puede ser negativo.");
        if (_volumenConversiones < 0) throw new ArgumentOutOfRangeException(nameof(_volumenConversiones), "El volumen de conversiones no puede ser negativo.");
        if (_volumenOutliers < 0) throw new ArgumentOutOfRangeException(nameof(_volumenOutliers), "El volumen de outliers no puede ser negativo.");
        if (_volumenDivisas < 0) throw new ArgumentOutOfRangeException(nameof(_volumenDivisas), "El volumen de divisas no puede ser negativo.");
    }

    /// <summary>
    /// Ejecuta el servicio en segundo plano de forma asíncrona.
    /// </summary>
    /// <param name="stoppingToken">Token de cancelación para detener la ejecución.</param>
    /// <returns>Tarea que representa la operación asíncrona.</returns>
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
                    for (int i = 0; i < _volumenClientes; i++)
                    {
                        var clienteDto = clienteFaker.Generate();
                        var nuevoCliente = mapper.Map<Cliente>(clienteDto);
                        await estadisticasRepositorio.CrearClienteAsync(nuevoCliente);
                        _logger.LogInformation("Cliente creado correctamente");
                    }

                    // 2. Lógica para crear transacción
                    for (int i = 0; i < _volumenTransacciones; i++)
                    {
                        var clienteOrigen = await estadisticasRepositorio.GetRandomClientAsync();
                        var clienteDestino = await estadisticasRepositorio.GetRandomClientAsync();
                        var transaccionFaker = new TransaccionFaker(clienteOrigen, clienteDestino);
                        var transaccionDto = transaccionFaker.Generate();
                        var nuevaTransaccion = mapper.Map<Transaccion>(transaccionDto);
                        await estadisticasRepositorio.CrearTransaccionAsync(nuevaTransaccion);
                        await estadisticasRepositorio.DetectarOutliersAsync();
                    }

                    // 3. Lógica para crear conversión
                    for (int i = 0; i < _volumenConversiones; i++)
                    {
                        var cliente = await estadisticasRepositorio.GetRandomClientAsync();
                        var conversionFaker = new ConversionFaker(cliente);
                        var conversionDto = conversionFaker.Generate();
                        var nuevaConversion = mapper.Map<Conversion>(conversionDto);
                        await estadisticasRepositorio.CrearConversionAsync(nuevaConversion);
                        _logger.LogInformation("Conversión creada correctamente");
                    }

                    // 4. Lógica para crear outlier
                    for (int i = 0; i < _volumenOutliers; i++)
                    {
                        var clienteOrigen = await estadisticasRepositorio.GetRandomClientAsync();
                        var clienteDestino = await estadisticasRepositorio.GetRandomClientAsync();
                        var outlierFaker = new OutliersFaker(clienteOrigen, clienteDestino);
                        var transaccionDto = outlierFaker.Generate();
                        var nuevaTransaccion = mapper.Map<Transaccion>(transaccionDto);
                        await estadisticasRepositorio.CrearTransaccionAsync(nuevaTransaccion);
                        await estadisticasRepositorio.DetectarOutliersAsync();
                    }

                    // 5. Lógica para crear divisa
                    for (int i = 0; i < _volumenDivisas; i++)
                    {
                        // Lista de nombres de divisas
                        var divisas = new List<string>
                        {
                            "AFN", "ALL", "EUR", "AOA", "XCD", "SAR", "DZD", "ARS", "AMD", "AUD", "AZN", "BSD", "BHD",
                            "BDT", "BBD", "BZD", "XOF", "BYN", "MMK", "BOB", "BAM", "BWP", "BRL", "BND", "BGN", "BIF",
                            "INR", "CVE", "KHR", "XAF", "CAD", "QAR", "CLP", "CNY", "COP", "KMF", "KPW", "KRW", "CRC",
                            "HRK", "CUP", "CZK", "DKK", "EGP", "USD", "AED", "ERN", "GBP", "SZL", "GTQ", "GNF", "GYD",
                            "HTG", "HNL", "HUF", "IDR", "IRR", "IQD", "ISK", "JMD", "JPY", "JOD", "KZT", "KES", "KGS",
                            "KWD", "LAK", "LVL", "LBP", "LRD", "LYD", "CHF", "MGA", "MYR", "MWK", "MVR", "MDL", "MNT",
                            "MAD", "MUR", "MRU", "MXN", "NAD", "NPR", "NIO", "NGN", "NOK", "NZD", "OMR", "PKR", "PAB",
                            "PGK", "PYG", "PEN", "PLN", "RON", "RUB", "RSD", "SCR", "SLL", "SGD", "SYP", "SOS", "LKR",
                            "SDG", "SEK", "STN", "RWF"
                        };

                        var fecha = DateTime.Now;

                        foreach (var divisa in divisas)
                        {
                            var divisaFaker = new DivisaFaker(divisa, fecha);
                            var divisaDto = divisaFaker.Generate();
                            var nuevaDivisa = mapper.Map<Divisa>(divisaDto);
                            await estadisticasRepositorio.CrearDivisaAsync(nuevaDivisa);
                        }
                    }
                }

                // Esperar antes de la siguiente ejecución
                await Task.Delay(TimeSpan.FromMinutes(_frecuenciaMinutos), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear datos en segundo plano");
            }
        }
    }
}
