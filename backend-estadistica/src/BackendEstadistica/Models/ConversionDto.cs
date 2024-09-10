namespace BackendEstadistica.Models;

/// <summary>
/// DTO para representar una conversión de divisa.
/// </summary>
public class ConversionDto
{
    /// <summary>
    /// Identificador único de la conversión.
    /// </summary>
    public int ConversionId { get; set; }

    /// <summary>
    /// Fecha en la que se realizó la conversión.
    /// </summary>
    public DateTime? Fecha { get; set; }

    /// <summary>
    /// Código de la moneda origen (ejemplo: USD).
    /// </summary>
    [Required(ErrorMessage = "La moneda origen es obligatoria.")]
    [StringLength(3, ErrorMessage = "El código de la moneda origen debe tener 3 caracteres.")]
    public string? MonedaOrigen { get; set; }

    /// <summary>
    /// Código de la moneda destino (ejemplo: EUR).
    /// </summary>
    [Required(ErrorMessage = "La moneda destino es obligatoria.")]
    [StringLength(3, ErrorMessage = "El código de la moneda destino debe tener 3 caracteres.")]
    public string? MonedaDestino { get; set; }

    /// <summary>
    /// Valor de la moneda origen en la conversión. Debe ser positivo.
    /// </summary>
    [Range(0.01, double.MaxValue, ErrorMessage = "El valor de la moneda origen debe ser mayor que cero.")]
    public double? ValorOrigen { get; set; }

    /// <summary>
    /// Valor de la moneda destino en la conversión. Debe ser positivo.
    /// </summary>
    [Range(0.01, double.MaxValue, ErrorMessage = "El valor de la moneda destino debe ser mayor que cero.")]
    public double? ValorDestino { get; set; }

    /// <summary>
    /// Identificador del cliente asociado a la conversión.
    /// </summary>
    public int ClienteId { get; set; }

    /// <summary>
    /// DTO para el cliente asociado a la conversión.
    /// </summary>
    public ClienteDto Cliente { get; set; } = new ClienteDto();
}