using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public class IdentityInitializer
{
    private readonly UserManager<ApplicationUser> _userManagerIdentity;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManagerIdentity = userManager;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        // Crear roles si no existen
        string[] roleNames = { "Cliente", "Admin" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Crear un usuario admin por defecto
        var adminUser = await _userManagerIdentity.FindByEmailAsync("admin@domain.com");
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                Email = "admin@domain.com",
                Rol = "Admin"
                // Inicializa aquí las propiedades obligatorias si las hay
            };
            var result = await _userManagerIdentity.CreateAsync(adminUser, "Password123!");
            if (!result.Succeeded)
            {
                throw new System.Exception("No se pudo crear el usuario admin.");
            }
        }

        // Asignar el rol de admin al usuario admin
        if (!await _userManagerIdentity.IsInRoleAsync(adminUser, "Admin"))
        {
            await _userManagerIdentity.AddToRoleAsync(adminUser, "Admin");
        }
    }
}