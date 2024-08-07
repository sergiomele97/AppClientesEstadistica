namespace ApiBasesDeDatosProyecto.IDentity.Serivicios
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(string userId);
    }
}
