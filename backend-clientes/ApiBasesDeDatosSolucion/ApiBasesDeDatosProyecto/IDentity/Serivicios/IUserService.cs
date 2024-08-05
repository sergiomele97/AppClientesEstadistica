using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBasesDeDatosProyecto.IDentity.Servicios
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(string userId);
    }
}
