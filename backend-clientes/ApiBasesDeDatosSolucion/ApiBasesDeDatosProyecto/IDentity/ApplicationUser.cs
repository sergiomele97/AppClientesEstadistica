using Microsoft.AspNetCore.Identity;

namespace ApiBasesDeDatosProyecto.IDentity
{
    public class ApplicationUser : IdentityUser
    {
        // Propiedades adicionales
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public required string Rol { get; set; } 

    }
}
