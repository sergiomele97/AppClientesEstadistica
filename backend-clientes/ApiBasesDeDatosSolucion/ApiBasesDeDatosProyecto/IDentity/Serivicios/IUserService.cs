namespace ApiBasesDeDatosProyecto.IDentity.Serivicios
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser?> GetUserByEmailAsync(string mail);

        Task<bool> DeleteUserAsync(string userId);
    }
}
