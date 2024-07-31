using BackendEstadistica.Models;

namespace BackendEstadistica.Repositorios;


// ----------------------- ¡ESTO ES UN EJEMPLO PROVISIONAL DE PETICION DE DATOS A OTRO GRUPO. SERÁ BORRADO MÁS ADELANTE! ------------------------ //

//public class ClientesRepositorioMemoria
//{
//    public List<ClienteDto> Clientes { get; set; }
//    public static ClientesRepositorioMemoria Instancia { get; } = new ClientesRepositorioMemoria();



//    public ClientesRepositorioMemoria()
//    {

//        _httpClient = new HttpClient();
//        _httpClient.BaseAddress = new Uri("https://localhost:7138");
//    }

//    private static HttpClient _httpClient;
//    public async Task<List<ClienteDto>> ObtenerClientes()
//    {

//        var response = await _httpClient.GetAsync("api/Clientes");
//        response.EnsureSuccessStatusCode();

//        var contenido = await response.Content.ReadFromJsonAsync<List<ClienteG01Dto>>();
//        List<ClienteDto> Clientes = new List<ClienteDto>();

//        foreach (var cliente in contenido)
//        {
//            Clientes.Add(new ClienteDto()
//            {
//                Id = cliente.Id,
//                Nombre = cliente.Nombre,
//                Apellidos = cliente.Apellidos,
//                Usuario = cliente.Usuario
//            });
//        }


//        return Clientes;
//    }
//}
