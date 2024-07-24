using System.Net.Http;

namespace BackendEstadistica.Repositorios;

public class UsuariosRepositorioMemoria
{
    public List<UsuarioDto> Usuarios { get; set; }

    // Creamos una instancia en la propia clase
    // No desaparece de memoria hasta que no se pare la aplicación
    // PATRON SINGLETON
    public static UsuariosRepositorioMemoria Instancia { get; } = new UsuariosRepositorioMemoria();

    public static HttpClient _httpClient;

    public UsuariosRepositorioMemoria()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7138");

        Usuarios = new List<UsuarioDto>
        {
            new UsuarioDto { Id = 1, Nombre = "Juan Pérez", Correo = "juan.perez@example.com", Contraseña = "password123" },
            new UsuarioDto { Id = 2, Nombre = "Ana Gómez", Correo = "ana.gomez@example.com", Contraseña = "securepass456" },
            new UsuarioDto { Id = 3, Nombre = "Luis Rodríguez", Correo = "luis.rodriguez@example.com", Contraseña = "mypassword789" },
            new UsuarioDto { Id = 4, Nombre = "María Sánchez", Correo = "maria.sanchez@example.com", Contraseña = "pass1234" }

        };

    }

    public void AgregarUsuario(UsuarioDto nuevoUsuario)
    {
        var nuevoId = Usuarios.Max(u => u.Id) + 1;
        nuevoUsuario.Id = nuevoId;
        Usuarios.Add(nuevoUsuario);
    }


}
