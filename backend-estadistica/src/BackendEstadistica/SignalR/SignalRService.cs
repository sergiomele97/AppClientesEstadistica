namespace BackendEstadistica.SignalR;

public class SignalRService
{
    private readonly HubConnection _hubConnection;
    private readonly ContextoBBDD _contextoBBDD;
    private readonly IHubContext<NotificationHub> _hubContext; // Añadido
    private readonly IEstadisticasRepositorio _estadisticasRepositorio; // Añadido
    private bool _isEventRegistered = false;

    // Modifica el constructor para aceptar IHubContext<NotificationHub>
    public SignalRService(ContextoBBDD contextoBBDD, IHubContext<NotificationHub> hubContext)
    {
        _contextoBBDD = contextoBBDD;
        _hubContext = hubContext; // Inicializa el campo

        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://chachibackend-cudsb0anfdcncddp.spaincentral-01.azurewebsites.net/notificationHub")
            .WithAutomaticReconnect()
            .Build();
    }

    public async Task StartListeningAsync()
    {
        try
        {
            if (_hubConnection.State != HubConnectionState.Disconnected)
            {
                await _hubConnection.StopAsync();
            }

            if (!_isEventRegistered)
            {
                _hubConnection.On<string>("RecibirMensaje", async (mensaje) =>
                {
                    try
                    {
                        var transaccionJson = JObject.Parse(mensaje);

                        if (transaccionJson["TipoAcceso"]?.ToString() == "Transaccion")
                        {
                            string clienteOrigenId = transaccionJson["ClienteOrigenId"]?.ToString() ?? string.Empty;
                            string clienteDestinoId = transaccionJson["ClienteDestinoId"]?.ToString() ?? string.Empty;
                            int paisOrigen = transaccionJson["PaisOrigen"]?.ToObject<int>() ?? 0;
                            int paisDestino = transaccionJson["PaisDestino"]?.ToObject<int>() ?? 0;
                            double valorOrigen = transaccionJson["ValorOrigen"]?.ToObject<double>() ?? 0;
                            double valorDestino = transaccionJson["ValorDestino"]?.ToObject<double>() ?? 0;
                            DateTime timestamp = transaccionJson["Timestamp"]?.ToObject<DateTime>() ?? DateTime.UtcNow;

                            await GuardarTransaccionAsync(clienteOrigenId, clienteDestinoId, paisOrigen, paisDestino, valorOrigen, valorDestino, timestamp);
                        }
                        else
                        {
                            Console.WriteLine("Mensaje recibido no es de tipo 'Transaccion'.");
                        }
                    }
                    catch (JsonException jsonEx)
                    {
                        Console.WriteLine($"Error al procesar el mensaje: {jsonEx.Message}");
                    }
                });
                _isEventRegistered = true;
            }

            await _hubConnection.StartAsync();
            Console.WriteLine("Conectado al hub de SignalR");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar al hub de SignalR: {ex.Message}");
        }
    }

    private async Task GuardarTransaccionAsync(string clienteOrigenId, string clienteDestinoId, int paisOrigen, int paisDestino, double valorOrigen, double valorDestino, DateTime timestamp)
    {
        try
        {
            using var transaction = await _contextoBBDD.Database.BeginTransactionAsync();

            // Buscar o crear ClienteOrigen usando el ID proporcionado
            var clienteOrigen = await _contextoBBDD.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId.ToString() == clienteOrigenId);

            if (clienteOrigen == null)
            {
                // Si no se encuentra el cliente, se podría optar por no continuar o crear el cliente dependiendo del contexto
                Console.WriteLine($"Cliente origen con ID {clienteOrigenId} no encontrado.");
                return;
            }

            // Buscar o crear ClienteDestino usando el ID proporcionado
            var clienteDestino = await _contextoBBDD.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId.ToString() == clienteDestinoId);

            if (clienteDestino == null)
            {
                // Si no se encuentra el cliente, se podría optar por no continuar o crear el cliente dependiendo del contexto
                Console.WriteLine($"Cliente destino con ID {clienteDestinoId} no encontrado.");
                return;
            }

            // Crear una nueva transacción
            var nuevaTransaccion = new Transaccion
            {
                ImporteRecibido = valorDestino,
                ImporteEnviado = valorOrigen,
                Fecha = timestamp,
                ClienteOrigenId = clienteOrigen.ClienteId,
                ClienteDestinoId = clienteDestino.ClienteId,
                IsOutlier = false,  // Inicialmente, no se marca como outlier
                IsOutlierVisto = false
            };

            // Guardar la transacción en la base de datos
            _contextoBBDD.Transacciones.Add(nuevaTransaccion);
            await _contextoBBDD.SaveChangesAsync();

            // Detectar outliers usando el repositorio
            await _estadisticasRepositorio.DetectarOutliersAsync();

            // Verificar si la nueva transacción es un outlier
            var transaccionGuardada = await _contextoBBDD.Transacciones
                .Include(t => t.ClienteOrigen)
                .FirstOrDefaultAsync(t => t.TransaccionId == nuevaTransaccion.TransaccionId);

            if (transaccionGuardada != null && transaccionGuardada.IsOutlier == true)
            {
                await _hubContext.Clients.All.SendAsync("OutlierDetected", new
                {
                    Message = "Outlier detectado",
                    Cliente = transaccionGuardada.ClienteOrigen.Nombre,
                    ImporteEnviado = transaccionGuardada.ImporteEnviado
                });

                Console.WriteLine($"Outlier detectado: {transaccionGuardada.ClienteOrigen.Nombre} -> Importe Enviado: {transaccionGuardada.ImporteEnviado}");
            }

            await transaction.CommitAsync();

            Console.WriteLine($"Transacción guardada: {clienteOrigen.Nombre} -> {clienteDestino.Nombre}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar la transacción: {ex.Message}");
            throw;
        }
    }

    public async Task StopListeningAsync()
    {
        if (_hubConnection.State == HubConnectionState.Connected)
        {
            await _hubConnection.StopAsync();
            Console.WriteLine("Desconectado del hub de SignalR");
        }
    }
}
