namespace BackendEstadistica.Entidades;

/// <summary>
/// Representa una conversión de divisa.
/// </summary>
public class Conversion
{
    [Key]
    public int ConversionId { get; set; }

    /// <summary>
    /// Fecha en la que se realizó la conversión.
    /// </summary>
    public DateTime? Fecha { get; set; }

    /// <summary>
    /// Código de la moneda origen (ejemplo: USD).
    /// </summary>
    [StringLength(3, ErrorMessage = "El código de moneda origen debe tener 3 caracteres.")]
    public string? MonedaOrigen { get; set; }

    /// <summary>
    /// Código de la moneda destino (ejemplo: EUR).
    /// </summary>
    [StringLength(3, ErrorMessage = "El código de moneda destino debe tener 3 caracteres.")]
    public string? MonedaDestino { get; set; }

    /// <summary>
    /// Valor de la moneda origen en la conversión.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "El valor de la moneda origen debe ser un valor positivo.")]
    public double? ValorOrigen { get; set; }

    /// <summary>
    /// Valor de la moneda destino en la conversión.
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "El valor de la moneda destino debe ser un valor positivo.")]
    public double? ValorDestino { get; set; }

    /// <summary>
    /// Identificador del cliente asociado a la conversión.
    /// </summary>
    [Required(ErrorMessage = "El cliente asociado es obligatorio.")]
    public int ClienteId { get; set; }

    /// <summary>
    /// Cliente asociado a la conversión.
    /// </summary>
    public Cliente Cliente { get; set; } = null!;
}
