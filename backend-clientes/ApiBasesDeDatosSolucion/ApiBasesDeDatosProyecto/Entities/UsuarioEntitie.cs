using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBasesDeDatosProyecto.Entities
{
    [Table("Usuarios")] // Opcional: Especifica el nombre de la tabla en la base de datos
    public class Usuario
    {
        [Key] // Marca esta propiedad como la clave primaria
        public int Id { get; set; }

        [Required] // Indica que esta propiedad es obligatoria
        [StringLength(40)] // Limita la longitud de la cadena para UserName
        public string UserName { get; set; }

        [Required]
        [StringLength(256)] // Limita la longitud de la cadena para Email
        [EmailAddress] // Valida que el valor sea una dirección de correo electrónico
        public string Email { get; set; }
    }
}
