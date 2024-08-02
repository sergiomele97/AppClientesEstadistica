
namespace ApiBasesDeDatosProyecto.Models
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(25)]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public string Empleo { get; set; }

        public string NombrePais { get; set; }

        [Required]
        public int PaisId { get; set; }
    }
}
