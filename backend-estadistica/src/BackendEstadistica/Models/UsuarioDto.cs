namespace BackendEstadistica.Models
{
    /* Modelo de Usuario para intercambiar objetos usuarios fuera de la base de datos */
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? Rol { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }

    }
}
