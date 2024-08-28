namespace BackendEstadistica.Servicios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly ContextoBBDD _contextoBBDD;

    public UsuarioRepositorio(ContextoBBDD contexto)
    {
        _contextoBBDD = contexto;
    }

    public async Task<bool> EmailExistAsync(string email)
    {
        return await _contextoBBDD.Usuario.AnyAsync(u => u.Correo == email);
    }

    public async Task AddUsuarioAsync(Usuario usuario)
    {
        await _contextoBBDD.Usuario.AddAsync(usuario);
        await GuardarCambiosAsync(); // Utiliza el método asincrónico para guardar cambios
    }

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

    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _contextoBBDD.Usuario.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        return await _contextoBBDD.Usuario.ToListAsync();
    }

    public async Task<List<Usuario>> GetUsuariosFiltrandoAsync(string nombre, int numeroPagina, int tamañoPagina)
    {
     
        return await _contextoBBDD.Usuario
            .Where(u => u.Correo.Contains(nombre)) 
            .Skip((numeroPagina - 1) * tamañoPagina)
            .Take(tamañoPagina)
            .ToListAsync();
    }

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

    public async Task UpdateUsuarioAsync(Usuario usuario)
    {
        _contextoBBDD.Usuario.Update(usuario);
        await GuardarCambiosAsync(); // Utiliza el método asincrónico para guardar cambios
    }
}
