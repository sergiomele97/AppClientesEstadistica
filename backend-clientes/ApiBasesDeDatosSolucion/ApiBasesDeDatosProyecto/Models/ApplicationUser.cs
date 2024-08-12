using Microsoft.AspNetCore.Identity;

namespace ApiBasesDeDatosProyecto.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Propiedades adicionales
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Rol { get; set; }

        public bool IsDeleted { get; set; }

    }
}
