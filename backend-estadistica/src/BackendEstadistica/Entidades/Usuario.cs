using Microsoft.AspNetCore.Identity;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace BackendEstadistica.Entidades;

public class Usuario : IValidatableObject


{


    [Key]
    public int Id { get; set; }
    [Required]
    public string? Correo { get ; set; }
    [Required]
    public string? Contraseña { get; set; }
    [Required]
    public string? Telefono { get; set; }

    // Poner dentro del validador
    public bool EsCorreoValido()
    {
        return !string.IsNullOrEmpty(Correo) && Correo.Contains("@"); // devuelve True si no es vacio y tiene @
    }

    public bool EsContraseñaValida()
    {
        return !string.IsNullOrEmpty(Contraseña) && Contraseña.Length >= 6;  // devuelve True si no es vacio y tiene + 6 caracteres
    }

    public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EsCorreoValido() == false)
        {
            yield return new ValidationResult("Email no válido");
        }

        if (EsContraseñaValida() == false)
        {
            yield return new ValidationResult("Contraseña no válida");
        }
    }

    
}