public class RegisterViewModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Rol { get; set; } // Ejemplo: "Client" o "Admin"

    public string ?Empleo { get; set; }

    // Campos adicionales para clientes
    public string ?Nombre { get; set; }
    public string ?Apellido { get; set; }
    public long FechaNacimiento { get; set; }
    public string PaisNombre { get; set; }
}
