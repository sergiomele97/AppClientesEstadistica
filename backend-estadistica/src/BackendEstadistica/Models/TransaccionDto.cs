namespace BackendEstadistica.Models;

/// <summary>
/// DTO para representar una transacción.
/// </summary>
public class TransaccionDto
{
    /// <summary>
    /// Identificador único de la transacción.
    /// </summary>
    public int TransaccionId { get; set; }

    /// <summary>
    /// Importe recibido en la transacción. Debe ser positivo.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "El importe recibido debe ser un valor positivo.")]
    public double? ImporteRecibido { get; set; }

    /// <summary>
    /// Importe enviado en la transacción. Debe ser positivo.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "El importe enviado debe ser un valor positivo.")]
    public double? ImporteEnviado { get; set; }

    /// <summary>
    /// Fecha en la que se realizó la transacción.
    /// </summary>
    public DateTime? Fecha { get; set; }

    /// <summary>
    /// Identificador del cliente que realizó la transacción.
    /// </summary>
    [Required(ErrorMessage = "El cliente origen es obligatorio.")]
    public int ClienteOrigenId { get; set; }

    /// <summary>
    /// Identificador del cliente que recibió la transacción.
    /// </summary>
    [Required(ErrorMessage = "El cliente destino es obligatorio.")]
    public int ClienteDestinoId { get; set; }

    /// <summary>
    /// DTO para el cliente que realizó la transacción.
    /// </summary>
    public ClienteDto ClienteOrigen { get; set; } = new ClienteDto();

    /// <summary>
    /// DTO para el cliente que recibió la transacción.
    /// </summary>
    public ClienteDto ClienteDestino { get; set; } = new ClienteDto();
}