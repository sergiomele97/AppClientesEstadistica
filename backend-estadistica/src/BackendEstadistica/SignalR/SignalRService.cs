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
                            // Código para manejar transacciones
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

    private async Task RegistrarClienteAsync(string nombre, string apellido, DateTime fechaNacimiento, string empleo, int paisId, string email)
    {
        try
        {
            // Calcular la edad a partir de la fecha de nacimiento
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (fechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;

            // Crear una nueva instancia de Cliente
            var nuevoCliente = new Cliente
            {
                Nombre = $"{nombre} {apellido}", // Combinar nombre y apellido si es necesario
                Correo = email,
                Telefono = string.Empty, // Deberías definir cómo manejar el teléfono (si aplica)
                Edad = edad,
                Sexo = string.Empty, // Deberías definir cómo manejar el sexo (si aplica)
                Trabajo = empleo,
                PaisId = paisId
            };

            // Registrar el cliente usando el repositorio
            await _estadisticasRepositorio.CrearClienteAsync(nuevoCliente);

            Console.WriteLine($"Cliente registrado: {nuevoCliente.Nombre}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al registrar el cliente: {ex.Message}");
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
