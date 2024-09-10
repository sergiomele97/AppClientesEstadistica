namespace BackendEstadistica.Servicios;

/// <summary>
/// Interfaz para el repositorio de usuarios.
/// </summary>
public interface IUsuarioRepositorio
{
    /// <summary>
    /// Obtiene la lista de todos los usuarios.
    /// </summary>
    /// <returns>Una lista de usuarios.</returns>
    Task<List<Usuario>> GetUsuariosAsync();

    /// <summary>
    /// Obtiene una lista de usuarios filtrados por correo electrónico, con paginación.
    /// </summary>
    /// <param name="email">El correo electrónico para filtrar los usuarios.</param>
    /// <param name="numeroPagina">El número de la página para la paginación.</param>
    /// <param name="tamañoPagina">El tamaño de la página para la paginación.</param>
    /// <returns>Una lista de usuarios que coinciden con el filtro.</returns>
    Task<List<Usuario>> GetUsuariosFiltrandoAsync(string email, int numeroPagina, int tamañoPagina);

    /// <summary>
    /// Obtiene un usuario por su identificador.
    /// </summary>
    /// <param name="id">El identificador del usuario.</param>
    /// <returns>El usuario correspondiente al identificador proporcionado.</returns>
    Task<Usuario> GetUsuarioByIdAsync(int id);

    /// <summary>
    /// Guarda los cambios realizados en el repositorio.
    /// </summary>
    /// <returns>Un valor booleano que indica si los cambios se guardaron correctamente.</returns>
    Task<bool> GuardarCambiosAsync();

    /// <summary>
    /// Verifica si el correo electrónico ya existe en el repositorio.
    /// </summary>
    /// <param name="email">El correo electrónico a verificar.</param>
    /// <returns>Un valor booleano que indica si el correo electrónico ya existe.</returns>
    Task<bool> EmailExistAsync(string email);

    /// <summary>
    /// Agrega un nuevo usuario al repositorio.
    /// </summary>
    /// <param name="usuario">El usuario a agregar.</param>
    /// <returns>Una tarea que representa la operación asincrónica.</returns>
    Task AddUsuarioAsync(Usuario usuario);

    /// <summary>
    /// Elimina un usuario del repositorio por su identificador.
    /// </summary>
    /// <param name="id">El identificador del usuario a eliminar.</param>
    /// <returns>Un valor booleano que indica si la eliminación fue exitosa.</returns>
    Task<bool> DeleteUsuarioAsync(int id);

    /// <summary>
    /// Actualiza un usuario existente en el repositorio.
    /// </summary>
    /// <param name="usuario">El usuario con las actualizaciones.</param>
    /// <returns>Una tarea que representa la operación asincrónica.</returns>
    Task UpdateUsuarioAsync(Usuario usuario);
}
