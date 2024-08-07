namespace ApiBasesDeDatosProyecto.Entities
{
    [Table("Clientes")]
    public class Cliente : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey(nameof(Usuario))]
        //public int UserId { get; set; }

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        public string Empleo { get; set; }

        [Required]
        public int PaisId { get; set; }

        //[ForeignKey(nameof(PaisId))]
        public Pais Pais { get; set; }  // Navegación a la entidad Pais

        //public Usuario? Usuario { get; set; }  // Navegación a la entidad Usuario

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaNacimiento > DateTime.Now)
            {
                yield return new ValidationResult(
                    "La fecha de nacimiento no puede ser en el futuro.",
                    new[] { nameof(FechaNacimiento) }
                );
            }

            if (Nombre.Equals(Apellido, StringComparison.OrdinalIgnoreCase))
            {
                yield return new ValidationResult(
                    "El nombre y el apellido no pueden ser iguales.",
                    new[] { nameof(Nombre), nameof(Apellido) }
                );
            }
        }
    }
}
