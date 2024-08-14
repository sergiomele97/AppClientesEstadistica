namespace ApiBasesDeDatosProyecto.Models
{
    public class EditViewModel
    {
        [Required]
        public string Email { get; set; }

        public string? Empleo { get; set; }

        // Campos adicionales para clientes
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public long FechaNacimiento { get; set; }
        public int PaisId { get; set; }
    }
}
