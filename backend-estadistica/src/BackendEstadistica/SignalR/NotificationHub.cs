namespace BackendEstadistica.SignalR;

public class NotificationHub : Hub
{
    public async Task SendNotification(string mensaje) 
    {
        await Clients.All.SendAsync("ReceiveNotification", mensaje);
    }
}
