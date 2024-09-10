namespace BackendEstadistica.Models;

/// <summary>
/// Modelo de vista para el inicio de sesión de usuarios.
/// </summary>
public class LoginViewModel
{
    /// <summary>
    /// Dirección de correo electrónico del usuario. Debe ser una dirección válida.
    /// </summary>
    [Required(ErrorMessage = "El correo electrónico es requerido.")]
    [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
    public string Email { get; set; }

    /// <summary>
    /// Contraseña del usuario. Debe ser un campo requerido.
    /// </summary>
    [Required(ErrorMessage = "La contraseña es requerida.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
    public string Password { get; set; }

    /// <summary>
    /// Indica si el usuario desea que la sesión se mantenga iniciada en futuras visitas.
    /// </summary>
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
