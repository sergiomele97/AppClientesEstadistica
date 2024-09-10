namespace BackendEstadistica.Models;

/// <summary>
/// DTO para representar un usuario.
/// </summary>
public class UsuarioDto
{
    /// <summary>
    /// Identificador único del usuario.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Correo electrónico del usuario.
    /// </summary>
    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    public string? Correo { get; set; }

    /// <summary>
    /// Contraseña del usuario.
    /// </summary>
    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres.")]
    public string? Contraseña { get; set; }

    /// <summary>
    /// Número de teléfono del usuario.
    /// </summary>
    [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
    [StringLength(15, ErrorMessage = "El teléfono no puede superar los 15 caracteres.")]
    public string? Telefono { get; set; }
}