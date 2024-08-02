namespace ApiBasesDeDatosProyecto.Models
{
    public class PaisDto
    {
        public int PaisId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Divisa { get; set; }

        [Required]
        [StringLength(3)]
        public string Iso3 { get; set; }
    }
}
