using System.ComponentModel.DataAnnotations;

namespace BackendEstadistica.Entidades
{
    /* Las entidades en ASP.NET Core representan los objetos que se almacenan en la base de datos.
     * Son clases que definen las propiedades y relaciones de los datos que la aplicación manejará 
     * como tablas en una base de datos relacional. Cada entidad se mapea a una tabla en la base de datos a través 
     * de Entity Framework Core, y sus propiedades corresponden a las columnas de esa tabla.
     */

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