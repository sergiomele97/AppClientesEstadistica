namespace BackendEstadistica.Entidades;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string? Rol { get; set; }
    public string? Correo { get; set; }
    public string? Contraseña { get; set; }

}