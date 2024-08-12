namespace BackendEstadistica.Models;

public class ConversionDto
{
    public int ConversionId { get; set; }
    public DateTime? Fecha { get; set; }
    public string? MonedaOrigen { get; set; }
    public string? MonedaDestino { get; set; }
    public double? ValorOrigen { get; set; }
    public double? ValorDestino { get; set; }
    public int ClienteId { get; set; }

    public ClienteDto Cliente { get; set; } = new ClienteDto(); // DTO para el cliente
}
