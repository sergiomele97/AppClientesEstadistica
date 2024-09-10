namespace BackendEstadistica.Servicios;

/// <summary>
/// Repositorio para manejar operaciones relacionadas con usuarios.
/// </summary>
public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly ContextoBBDD _contextoBBDD;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="UsuarioRepositorio"/> con el contexto de base de datos proporcionado.
    /// </summary>
    /// <param name="contexto">El contexto de base de datos.</param>
    public UsuarioRepositorio(ContextoBBDD contexto)
    {
        _contextoBBDD = contexto;
    }

    /// <summary>
    /// Verifica si un correo electrónico ya existe en la base de datos.
    /// </summary>
    /// <param name="email">El correo electrónico a verificar.</param>
    /// <returns>Verdadero si el correo electrónico existe, de lo contrario falso.</returns>
    public async Task<bool> EmailExistAsync(string email)
    {
        return await _contextoBBDD.Usuario.AnyAsync(u => u.Correo == email);
    }

    /// <summary>
    /// Añade un nuevo usuario a la base de datos.
    /// </summary>
    /// <param name="usuario">El usuario a añadir.</param>
    public async Task AddUsuarioAsync(Usuario usuario)
    {
        await _contextoBBDD.Usuario.AddAsync(usuario);
        await GuardarCambiosAsync(); // Utiliza el método asincrónico para guardar cambios
    }

    /// <summary>
    /// Elimina un usuario de la base de datos por su identificador.
    /// </summary>
    /// <param name="id">El identificador del usuario a eliminar.</param>
    /// <returns>Verdadero si el usuario fue eliminado, de lo contrario falso.</returns>
    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        var usuario = await _contextoBBDD.Usuario.FindAsync(id);
        if (usuario == null)
        {
            return false;
        }

        _contextoBBDD.Usuario.Remove(usuario);
        return await GuardarCambiosAsync(); // Utiliza el método asincrónico para guardar cambios
    }

    /// <summary>
    /// Obtiene un usuario de la base de datos por su identificador.
    /// </summary>
    /// <param name="id">El identificador del usuario.</param>
    /// <returns>El usuario con el identificador especificado.</returns>
    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _contextoBBDD.Usuario.FirstOrDefaultAsync(u => u.Id == id);
    }

    /// <summary>
    /// Obtiene una lista de todos los usuarios en la base de datos.
    /// </summary>
    /// <returns>Una lista de usuarios.</returns>
    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        return await _contextoBBDD.Usuario.ToListAsync();
    }

    /// <summary>
    /// Obtiene una lista de usuarios filtrados por nombre y paginados.
    /// </summary>
    /// <param name="nombre">El nombre o parte del nombre a filtrar.</param>
    /// <param name="numeroPagina">El número de la página de resultados.</param>
    /// <param name="tamañoPagina">El tamaño de la página (número de resultados por página).</param>
    /// <returns>Una lista de usuarios que coinciden con los criterios de filtrado.</returns>
    public async Task<List<Usuario>> GetUsuariosFiltrandoAsync(string nombre, int numeroPagina, int tamañoPagina)
    {
        return await _contextoBBDD.Usuario
            .Where(u => u.Correo.Contains(nombre))
            .Skip((numeroPagina - 1) * tamañoPagina)
            .Take(tamañoPagina)
            .ToListAsync();
    }

    /// <summary>
    /// Guarda los cambios realizados en el contexto de base de datos de forma asincrónica.
    /// </summary>
    /// <returns>Verdadero si se guardaron los cambios correctamente, de lo contrario falso.</returns>
    public async Task<bool> GuardarCambiosAsync()
    {
        try
        {
            return await _contextoBBDD.SaveChangesAsync() > 0;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Actualiza un usuario existente en la base de datos.
    /// </summary>
    /// <param name="usuario">El usuario con los datos actualizados.</param>
    public async Task UpdateUsuarioAsync(Usuario usuario)
    {
        _contextoBBDD.Usuario.Update(usuario);
        await GuardarCambiosAsync(); // Utiliza el método asincrónico para guardar cambios
    }
}
