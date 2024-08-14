using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBasesDeDatosProyecto.IDentity.Serivicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
    {
        return _userManager.Users.ToList(); // Asegúrate de manejar la paginación si es necesario
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return false;
        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(string mail)
    {
        // Utiliza el UserManager para encontrar el usuario por su correo electrónico.
        return await _userManager.FindByEmailAsync(mail);
    }

    
}

