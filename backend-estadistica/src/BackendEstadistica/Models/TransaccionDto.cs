namespace BackendEstadistica.Models;

public class TransaccionDto
{
    public int TransaccionId { get; set; }
    public double? ImporteRecibido { get; set; }
    public double? ImporteEnviado { get; set; }
    public DateTime? Fecha { get; set; }
    public int ClienteOrigenId { get; set; }
    public int ClienteDestinoId { get; set; }

    public ClienteDto ClienteOrigen { get; set; } = new ClienteDto(); // DTO para el cliente origen
    public ClienteDto ClienteDestino { get; set; } = new ClienteDto(); // DTO para el cliente destino
}
