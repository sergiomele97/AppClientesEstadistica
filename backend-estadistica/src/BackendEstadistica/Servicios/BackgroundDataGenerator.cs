namespace BackendEstadistica.Servicios
{
    public class BackgroundDataGenerator : BackgroundService
    {
        private readonly ILogger<BackgroundDataGenerator> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        //------------------Configurar-volumenes-de-creación-----------------------------
        int frecuenciaMinutos = 1440;   // 1 día
        int volumenClientes = 1;
        int volumenTransacciones = 15;
        int volumenConversiones = 7;
        int volumenOutliers = 1;
        int volumenDivisas = 1;
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

                        // 4. Lógica para crear outlier
                        for (int i = 0; i < volumenOutliers; i++)
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
                        for (int i = 0; i < volumenDivisas; i++)
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
                    await Task.Delay(TimeSpan.FromMinutes(frecuenciaMinutos), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al crear datos en segundo plano");
                }
            }
        }
    }
}
