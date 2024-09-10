namespace BackendEstadistica.Models;

/// <summary>
/// DTO para representar un país.
/// </summary>
public class PaisDto
{
    /// <summary>
    /// Identificador único del país.
    /// </summary>
    public int PaisId { get; set; }

    /// <summary>
    /// Nombre del país (ejemplo: España).
    /// </summary>
    [Required(ErrorMessage = "El nombre del país es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre del país no puede superar los 100 caracteres.")]
    public string? Nombre { get; set; }

    /// <summary>
    /// Código de la divisa del país (ejemplo: EUR).
    /// </summary>
    [Required(ErrorMessage = "El código de la divisa es obligatorio.")]
    [StringLength(3, ErrorMessage = "El código de la divisa debe tener 3 caracteres.")]
    public string? Divisa { get; set; }

    /// <summary>
    /// Código ISO 3166-1 alfa-3 del país (ejemplo: ESP).
    /// </summary>
    [Required(ErrorMessage = "El código ISO es obligatorio.")]
    [StringLength(3, ErrorMessage = "El código ISO debe tener 3 caracteres.")]
    public string? Iso3 { get; set; }
}