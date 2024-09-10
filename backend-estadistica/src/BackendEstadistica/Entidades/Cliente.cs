using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace BackendEstadistica.Entidades;

/// <summary>
/// Representa un cliente en el sistema.
/// </summary>
public class Cliente
{
    [Key]
    public int ClienteId { get; set; }

    /// <summary>
    /// Nombre del cliente. No debe exceder los 100 caracteres.
    /// </summary>
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string? Nombre { get; set; }

    /// <summary>
    /// Correo electrónico del cliente. Debe tener un formato válido.
    /// </summary>
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    public string? Correo { get; set; }

    /// <summary>
    /// Número de teléfono del cliente. Debe tener un formato válido.
    /// </summary>
    [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
    public string? Telefono { get; set; }

    /// <summary>
    /// Edad del cliente. Debe estar en el rango de 0 a 120.
    /// </summary>
    [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120.")]
    public int? Edad { get; set; }

    /// <summary>
    /// Sexo del cliente. No debe exceder los 10 caracteres.
    /// </summary>
    [StringLength(10, ErrorMessage = "El sexo no puede superar los 10 caracteres.")]
    public string? Sexo { get; set; }

    /// <summary>
    /// Ocupación o trabajo del cliente. No debe exceder los 100 caracteres.
    /// </summary>
    [StringLength(100, ErrorMessage = "El trabajo no puede superar los 100 caracteres.")]
    public string? Trabajo { get; set; }

    /// <summary>
    /// Identificador del país al que pertenece el cliente.
    /// </summary>
    [Required(ErrorMessage = "El país es obligatorio.")]
    public int PaisId { get; set; }

    /// <summary>
    /// Información del país al que pertenece el cliente.
    /// </summary>
    public Pais Pais { get; set; } = null!;

    /// <summary>
    /// Conversiones asociadas al cliente.
    /// </summary>
    [JsonIgnore]
    public ICollection<Conversion>? Conversiones { get; set; } = new List<Conversion>();

    /// <summary>
    /// Transacciones en las que el cliente es el origen.
    /// </summary>
    [JsonIgnore]
    public ICollection<Transaccion>? TransaccionesOrigen { get; set; } = new List<Transaccion>();

    /// <summary>
    /// Transacciones en las que el cliente es el destino.
    /// </summary>
    [JsonIgnore]
    public ICollection<Transaccion>? TransaccionesDestino { get; set; } = new List<Transaccion>();
}
