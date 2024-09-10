namespace BackendEstadistica.Models;

/// <summary>
/// DTO para representar la información de una divisa.
/// </summary>
public class DivisaDto
{
    /// <summary>
    /// Identificador único de la divisa.
    /// </summary>
    public int DivisaId { get; set; }

    /// <summary>
    /// Nombre de la divisa (ejemplo: Dólar).
    /// </summary>
    [Required(ErrorMessage = "El nombre de la divisa es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre de la divisa no puede superar los 50 caracteres.")]
    public string? Nombre { get; set; }

    /// <summary>
    /// Valor de la divisa en relación con el dólar.
    /// </summary>
    [Range(0.01, double.MaxValue, ErrorMessage = "El valor de la divisa debe ser mayor que cero.")]
    public double? Valor { get; set; }

    /// <summary>
    /// Fecha en la que se registró el valor de la divisa.
    /// </summary>
    public DateTime? Fecha { get; set; }
}