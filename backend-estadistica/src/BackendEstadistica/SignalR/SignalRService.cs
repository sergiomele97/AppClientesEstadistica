namespace BackendEstadistica.SignalR;

/// <summary>
/// Servicio que maneja la conexión con SignalR y procesa los mensajes recibidos.
/// </summary>
public class SignalRService
{
    private readonly HubConnection _hubConnection;
    private readonly ContextoBBDD _contextoBBDD;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly IEstadisticasRepositorio _estadisticasRepositorio;
    private bool _isEventRegistered = false;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="SignalRService"/>.
    /// </summary>
    /// <param name="contextoBBDD">El contexto de la base de datos.</param>
    /// <param name="hubContext">El contexto del hub de SignalR.</param>
    /// <param name="estadisticasRepositorio">El repositorio de estadísticas.</param>
    public SignalRService(ContextoBBDD contextoBBDD, IHubContext<NotificationHub> hubContext, IEstadisticasRepositorio estadisticasRepositorio)
    {
        _contextoBBDD = contextoBBDD;
        _hubContext = hubContext;
        _estadisticasRepositorio = estadisticasRepositorio;

        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://cleancashcourierapi-fdg9f7d4chb4gshy.spaincentral-01.azurewebsites.net/signalrhubnotificacion")
            .WithAutomaticReconnect()
            .Build();
    }

    /// <summary>
    /// Inicia la escucha de mensajes desde el hub de SignalR.
    /// </summary>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
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
                _hubConnection.On<object>("RecibirMensaje", async (mensaje) =>
                {
                    try
                    {
                        var transaccionJson = JObject.FromObject(mensaje);

                        if (transaccionJson["TipoAcceso"]?.ToString() == "Transaccion")
                        {
                            double valorOrigen = transaccionJson["ValorOrigen"]?.ToObject<double>() ?? 0;
                            double valorDestino = transaccionJson["ValorDestino"]?.ToObject<double>() ?? 0;
                            DateTime fecha = transaccionJson["Fecha"]?.ToObject<DateTime>() ?? DateTime.UtcNow;
                            string clienteOrigenId = transaccionJson["ClienteOrigenId"]?.ToString() ?? string.Empty;
                            string clienteDestinoId = transaccionJson["ClienteDestinoId"]?.ToString() ?? string.Empty;
                            int paisOrigen = transaccionJson["PaisOrigen"]?.ToObject<int>() ?? 0;
                            int paisDestino = transaccionJson["PaisDestino"]?.ToObject<int>() ?? 0;

                            await GuardarTransaccionAsync(clienteOrigenId, clienteDestinoId, paisOrigen, paisDestino, valorOrigen, valorDestino, fecha);
                        }
                        else if (transaccionJson["TipoAcceso"]?.ToString() == "Registro")
                        {
                            string nombre = transaccionJson["Nombre"]?.ToString() ?? string.Empty;
                            string apellido = transaccionJson["Apellido"]?.ToString() ?? string.Empty;
                            DateTime fechaNacimiento = transaccionJson["FechaNacimiento"]?.ToObject<DateTime>() ?? DateTime.UtcNow;
                            string empleo = transaccionJson["Empleo"]?.ToString() ?? string.Empty;
                            int paisId = transaccionJson["PaisId"]?.ToObject<int>() ?? 0;
                            string email = transaccionJson["Email"]?.ToString() ?? string.Empty;

                            await RegistrarClienteAsync(nombre, apellido, fechaNacimiento, empleo, paisId, email);
                        }
                        else
                        {
                            Console.WriteLine("Mensaje recibido no es de tipo 'Transaccion' ni 'Registro'.");
                        }
                    }
                    catch (System.Text.Json.JsonException jsonEx)
                    {
                        Console.WriteLine($"Error al procesar el mensaje: {jsonEx.Message}");
                    }
                });

                _hubConnection.On<object>("newtransaction", async (mensaje) =>
                {
                    try
                    {
                        var transaccionJson = mensaje as JObject ?? JObject.Parse(mensaje.ToString());

                        double valorOrigen = transaccionJson["valorOrigen"]?.ToObject<double>() ?? 0;
                        double valorDestino = transaccionJson["valorDestino"]?.ToObject<double>() ?? 0;
                        DateTime fecha = transaccionJson["timestamp"]?.ToObject<DateTime>() ?? DateTime.UtcNow;
                        string clienteOrigenId = transaccionJson["clienteOrigenId"]?.ToString() ?? string.Empty;
                        string clienteDestinoId = transaccionJson["clienteDestinoId"]?.ToString() ?? string.Empty;
                        int paisOrigen = transaccionJson["paisOrigen"]?.ToObject<int>() ?? 0;
                        int paisDestino = transaccionJson["paisDestino"]?.ToObject<int>() ?? 0;

                        Console.WriteLine($"Mensaje: {mensaje}");
                        Console.WriteLine($"País de Origen: {paisOrigen}, País de Destino: {paisDestino}");
                        Console.WriteLine($"Cliente Origen ID: {clienteOrigenId}, Cliente Destino ID: {clienteDestinoId}");
                        Console.WriteLine($"Valor Origen: {valorOrigen}, Valor Destino: {valorDestino}");
                        Console.WriteLine($"Timestamp: {fecha}");

                        await GuardarTransaccionAsync(clienteOrigenId, clienteDestinoId, paisOrigen, paisDestino, valorOrigen, valorDestino, fecha);
                    }
                    catch (System.Text.Json.JsonException jsonEx)
                    {
                        Console.WriteLine($"Error al procesar el mensaje de nueva transacción: {jsonEx.Message}");
                    }
                });

                _hubConnection.On<object>("newregister", async (mensaje) =>
                {
                    try
                    {
                        var registroJson = JObject.FromObject(mensaje);

                        string nombre = registroJson["Nombre"]?.ToString() ?? string.Empty;
                        string apellido = registroJson["Apellido"]?.ToString() ?? string.Empty;
                        DateTime fechaNacimiento = registroJson["FechaNacimiento"]?.ToObject<DateTime>() ?? DateTime.UtcNow;
                        string empleo = registroJson["Empleo"]?.ToString() ?? string.Empty;
                        int paisId = registroJson["PaisId"]?.ToObject<int>() ?? 0;
                        string email = registroJson["Email"]?.ToString() ?? string.Empty;

                        await RegistrarClienteAsync(nombre, apellido, fechaNacimiento, empleo, paisId, email);
                    }
                    catch (System.Text.Json.JsonException jsonEx)
                    {
                        Console.WriteLine($"Error al procesar el mensaje de nuevo registro: {jsonEx.Message}");
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

    /// <summary>
    /// Guarda una transacción en la base de datos y realiza las operaciones asociadas.
    /// </summary>
    /// <param name="clienteOrigenId">ID del cliente origen.</param>
    /// <param name="clienteDestinoId">ID del cliente destino.</param>
    /// <param name="paisOrigen">ID del país de origen.</param>
    /// <param name="paisDestino">ID del país de destino.</param>
    /// <param name="valorOrigen">Valor enviado desde el cliente origen.</param>
    /// <param name="valorDestino">Valor recibido por el cliente destino.</param>
    /// <param name="timestamp">Fecha y hora de la transacción.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    private async Task GuardarTransaccionAsync(string clienteOrigenId, string clienteDestinoId, int paisOrigen, int paisDestino, double valorOrigen, double valorDestino, DateTime timestamp)
    {
        try
        {
            var clienteOrigen = await _contextoBBDD.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId.ToString() == clienteOrigenId);

            if (clienteOrigen == null)
            {
                Console.WriteLine($"Cliente origen con ID {clienteOrigenId} no encontrado.");
                return;
            }

            var clienteDestino = await _contextoBBDD.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId.ToString() == clienteDestinoId);

            if (clienteDestino == null)
            {
                Console.WriteLine($"Cliente destino con ID {clienteDestinoId} no encontrado.");
                return;
            }

            var nuevaTransaccion = new Transaccion
            {
                ImporteRecibido = valorDestino,
                ImporteEnviado = valorOrigen,
                Fecha = timestamp,
                ClienteOrigenId = clienteOrigen.ClienteId,
                ClienteDestinoId = clienteDestino.ClienteId,
                IsOutlier = false,
                IsOutlierVisto = false
            };

            await using var transaction = await _contextoBBDD.Database.BeginTransactionAsync();

            try
            {
                _contextoBBDD.Transacciones.Add(nuevaTransaccion);
                await _contextoBBDD.SaveChangesAsync();

                await _estadisticasRepositorio.DetectarOutliersAsync();

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
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw; // Re-lanzar la excepción después de revertir la transacción
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar la transacción: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Registra un nuevo cliente en la base de datos.
    /// </summary>
    /// <param name="nombre">Nombre del cliente.</param>
    /// <param name="apellido">Apellido del cliente.</param>
    /// <param name="fechaNacimiento">Fecha de nacimiento del cliente.</param>
    /// <param name="empleo">Empleo del cliente.</param>
    /// <param name="paisId">ID del país del cliente.</param>
    /// <param name="email">Correo electrónico del cliente.</param>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    private async Task RegistrarClienteAsync(string nombre, string apellido, DateTime fechaNacimiento, string empleo, int paisId, string email)
    {
        try
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (fechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;

            var nuevoCliente = new Cliente
            {
                Nombre = $"{nombre} {apellido}",
                Correo = email,
                Telefono = string.Empty,
                Edad = edad,
                Sexo = string.Empty,
                Trabajo = empleo,
                PaisId = paisId
            };

            await _estadisticasRepositorio.CrearClienteAsync(nuevoCliente);

            Console.WriteLine($"Cliente registrado: {nuevoCliente.Nombre}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al registrar el cliente: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Detiene la escucha de mensajes del hub de SignalR.
    /// </summary>
    /// <returns>Una tarea que representa la operación asíncrona.</returns>
    public async Task StopListeningAsync()
    {
        if (_hubConnection.State == HubConnectionState.Connected)
        {
            await _hubConnection.StopAsync();
            Console.WriteLine("Desconectado del hub de SignalR");
        }
    }
}
