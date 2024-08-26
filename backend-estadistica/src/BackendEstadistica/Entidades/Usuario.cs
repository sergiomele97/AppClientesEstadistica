using Microsoft.AspNetCore.Identity;

namespace BackendEstadistica.Entidades;

public class Usuario 


{


    [Key]
    public int Id { get; set; }
    public string? Correo { get ; set; }
    public string? Contraseña { get; set; }
    public string? Telefono { get; set; }
    public bool EsCorreoValido()
    {
        return !string.IsNullOrEmpty(Correo) && Correo.Contains("@"); // devuelve True si no es vacio y tiene @
    }

    public bool EsContraseñaValida()
    {
        return !string.IsNullOrEmpty(Contraseña) && Contraseña.Length >= 6;  // devuelve True si no es vacio y tiene + 6 caracteres
    }
}