namespace ApiBasesDeDatosProyecto.Models
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
