using BackendEstadistica.Entidades;

namespace BackendEstadistica.Servicios;

public interface IUsuarioRepositorio
{
    List<Usuario> GetUsuarios();
    List<Usuario> GetUsuariosFiltrando(string nombre, int numeroPagina, int tamañoPagina);
    Usuario GetUsuarioById(int id);
    bool GuardarCambios();
    void AddUsuario(Usuario usuario);
    void DeleteUsuario(Usuario usuario);
    void UpdateUsuario(Usuario usuario);
}
