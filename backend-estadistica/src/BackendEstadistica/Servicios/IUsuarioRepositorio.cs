using BackendEstadistica.Entidades;

namespace BackendEstadistica.Servicios;

public interface IUsuarioRepositorio
{
    Task<List<Usuario>> GetUsuariosAsync();
    Task<List<Usuario>> GetUsuariosFiltrandoAsync(string email, int numeroPagina, int tamañoPagina);
    Task<Usuario> GetUsuarioByIdAsync(int id);
    Task<bool> GuardarCambiosAsync();
    Task<bool> EmailExistAsync(string email);
    Task AddUsuarioAsync(Usuario usuario);
    Task<bool> DeleteUsuarioAsync(int id);
    Task UpdateUsuarioAsync(Usuario usuario);
}
