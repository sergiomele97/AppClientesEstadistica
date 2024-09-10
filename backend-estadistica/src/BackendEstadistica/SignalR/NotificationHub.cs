namespace BackendEstadistica.SignalR;

/// <summary>
/// Hub de SignalR que gestiona la comunicación en tiempo real con los clientes.
/// </summary>
public class NotificationHub : Hub
{
    /// <summary>
    /// Envía una notificación a todos los clientes conectados.
    /// </summary>
    /// <param name="mensaje">El mensaje que se enviará a los clientes.</param>
    /// <returns>Una tarea que representa la operación asincrónica.</returns>
    public async Task SendNotification(string mensaje)
    {
        await Clients.All.SendAsync("ReceiveNotification", mensaje);
    }
}
