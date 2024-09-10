namespace BackendEstadistica.Models;

/// <summary>
/// Modelo de vista para el registro de nuevos usuarios.
/// </summary>
public class RegisterViewModel
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
    /// Confirmación de la contraseña del usuario. Debe coincidir con la contraseña.
    /// </summary>
    [Required(ErrorMessage = "La confirmación de la contraseña es requerida.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden.")]
    public string ConfirmPassword { get; set; }

    /// <summary>
    /// Número de teléfono del usuario. Debe ser un número válido.
    /// </summary>
    [Required(ErrorMessage = "El número de teléfono es requerido.")]
    [Phone(ErrorMessage = "El número de teléfono no tiene un formato válido.")]
    public string PhoneNumber { get; set; }
}
