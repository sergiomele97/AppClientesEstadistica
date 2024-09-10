namespace BackendEstadistica.Entidades;

/// <summary>
/// Representa una transacción entre dos clientes en el sistema.
/// </summary>
public class Transaccion
{
    [Key]
    public int TransaccionId { get; set; }

    /// <summary>
    /// Importe recibido en la transacción. Puede ser nulo si no se especifica un importe recibido.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "El importe recibido debe ser un valor positivo.")]
    public double? ImporteRecibido { get; set; }

    /// <summary>
    /// Importe enviado en la transacción. Puede ser nulo si no se especifica un importe enviado.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "El importe enviado debe ser un valor positivo.")]
    public double? ImporteEnviado { get; set; }

    /// <summary>
    /// Fecha en que se realizó la transacción. Puede ser nula si no se especifica una fecha.
    /// </summary>
    public DateTime? Fecha { get; set; }

    /// <summary>
    /// Indica si la transacción es un valor atípico.
    /// </summary>
    public bool? IsOutlier { get; set; }

    /// <summary>
    /// Indica si el valor atípico ha sido revisado.
    /// </summary>
    public bool? IsOutlierVisto { get; set; }

    /// <summary>
    /// ID del cliente que envió la transacción. No debe ser nulo.
    /// </summary>
    [Required(ErrorMessage = "El ID del cliente origen es obligatorio.")]
    public int ClienteOrigenId { get; set; }

    /// <summary>
    /// ID del cliente que recibió la transacción. No debe ser nulo.
    /// </summary>
    [Required(ErrorMessage = "El ID del cliente destino es obligatorio.")]
    public int ClienteDestinoId { get; set; }

    /// <summary>
    /// Cliente que envió la transacción.
    /// </summary>
    public Cliente ClienteOrigen { get; set; } = null!;

    /// <summary>
    /// Cliente que recibió la transacción.
    /// </summary>
    public Cliente ClienteDestino { get; set; } = null!;
}
