namespace BackendEstadistica.Entidades;

/// <summary>
/// Representa un país en el sistema.
/// </summary>
public class Pais
{
    [Key]
    public int PaisId { get; set; }

    /// <summary>
    /// Nombre del país (ejemplo: España).
    /// </summary>
    [StringLength(100, ErrorMessage = "El nombre del país no puede superar los 100 caracteres.")]
    public string? Nombre { get; set; }

    /// <summary>
    /// Código de la divisa del país (ejemplo: EUR).
    /// </summary>
    [StringLength(3, ErrorMessage = "El código de la divisa debe tener 3 caracteres.")]
    public string? Divisa { get; set; }

    /// <summary>
    /// Código ISO 3166-1 alfa-3 del país (ejemplo: ESP).
    /// </summary>
    [StringLength(3, ErrorMessage = "El código ISO debe tener 3 caracteres.")]
    public string? Iso3 { get; set; }

    /// <summary>
    /// Colección de clientes asociados a este país.
    /// </summary>
    [JsonIgnore]
    public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
