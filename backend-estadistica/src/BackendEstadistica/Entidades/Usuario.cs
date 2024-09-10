namespace BackendEstadistica.Entidades;

/// <summary>
/// Representa un usuario en el sistema.
/// </summary>
public class Usuario
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Correo electrónico del usuario. No puede ser nulo y debe tener un formato válido.
    /// </summary>
    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    public string? Correo { get; set; }

    /// <summary>
    /// Contraseña del usuario. No puede ser nula y debe tener al menos 6 caracteres.
    /// </summary>
    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
    public string? Contraseña { get; set; }

    /// <summary>
    /// Número de teléfono del usuario. No puede ser nulo y debe tener un formato válido.
    /// </summary>
    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
    public string? Telefono { get; set; }
}
