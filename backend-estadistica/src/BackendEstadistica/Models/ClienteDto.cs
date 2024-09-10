namespace BackendEstadistica.Models;

/// <summary>
/// DTO para representar la información de un cliente.
/// </summary>
public class ClienteDto
{
    /// <summary>
    /// Identificador único del cliente.
    /// </summary>
    public int ClienteId { get; set; }

    /// <summary>
    /// Nombre del cliente. No puede exceder los 100 caracteres.
    /// </summary>
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Nombre { get; set; }

    /// <summary>
    /// Correo electrónico del cliente. Debe tener un formato válido.
    /// </summary>
    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    public string Correo { get; set; }

    /// <summary>
    /// Número de teléfono del cliente. Debe tener un formato válido.
    /// </summary>
    [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
    [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
    public string? Telefono { get; set; }

    /// <summary>
    /// Edad del cliente. Debe estar en el rango de 0 a 120.
    /// </summary>
    [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120.")]
    public int? Edad { get; set; }

    /// <summary>
    /// Sexo del cliente. No puede exceder los 10 caracteres.
    /// </summary>
    [StringLength(10, ErrorMessage = "El sexo no puede superar los 10 caracteres.")]
    public string? Sexo { get; set; }

    /// <summary>
    /// Ocupación o trabajo del cliente. No puede exceder los 100 caracteres.
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
    public PaisDto? Pais { get; set; }

    /// <summary>
    /// Lista de transacciones en las que el cliente es el origen.
    /// </summary>
    public List<TransaccionDto> TransaccionesOrigen { get; set; } = new List<TransaccionDto>();

    /// <summary>
    /// Lista de transacciones en las que el cliente es el destino.
    /// </summary>
    public List<TransaccionDto> TransaccionesDestino { get; set; } = new List<TransaccionDto>();

    /// <summary>
    /// Lista de conversiones asociadas al cliente.
    /// </summary>
    public List<ConversionDto> Conversiones { get; set; } = new List<ConversionDto>();
}
