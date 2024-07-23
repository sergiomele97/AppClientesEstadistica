using System.ComponentModel.DataAnnotations;

namespace BackendEstadistica.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }

    }
}