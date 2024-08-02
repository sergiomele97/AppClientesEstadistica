using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBasesDeDatosProyecto.Entities
{
    [Table("Paises")] // Opcional: Especifica el nombre de la tabla en la base de datos
    public class Pais
    {
        [Key] // Marca esta propiedad como la clave primaria
        public int Id { get; set; }

        [Required] // Indica que esta propiedad es obligatoria
        [StringLength(100)] // Limita la longitud de la cadena
        public string Nombre { get; set; }

        [StringLength(50)] // Limita la longitud de la cadena para la divisa
        public string Divisa { get; set; }

        public ICollection<Cliente> Clientes { get; set; } // Navegación a la colección de Clientes


        public static implicit operator List<object>(Pais? v)
        {
            throw new NotImplementedException();
        }
    }
}
