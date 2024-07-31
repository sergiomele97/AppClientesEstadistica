using BackendEstadistica.Entidades;

namespace BackendEstadistica.Servicios;

public interface IUsuarioRepositorio
{
    List<Usuario> GetUsuarios();
    List<Usuario> GetUsuariosFiltrando(string nombre, int numeroPagina, int tamañoPagina);
    Usuario GetUsuarioById(int id);
    bool GuardarCambios();
    bool EmailExist(string email);
    void AddUsuario(Usuario usuario);
    bool DeleteUsuario(int id);
    void UpdateUsuario(Usuario usuario);
}
