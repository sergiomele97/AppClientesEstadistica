using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public class IdentityInitializer
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
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
        var adminUser = await _userManager.FindByNameAsync("admin@domain.com");
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                Email = "admin@domain.com",
                Rol = "Cliente"
                // Inicializa aquí las propiedades obligatorias si las hay
            };
            var result = await _userManager.CreateAsync(adminUser, "Password123!");
            if (!result.Succeeded)
            {
                throw new System.Exception("No se pudo crear el usuario admin.");
            }
        }

        // Asignar el rol de admin al usuario admin
        if (!await _userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await _userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}