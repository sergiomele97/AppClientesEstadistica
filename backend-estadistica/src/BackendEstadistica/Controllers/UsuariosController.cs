using BackendEstadistica.Repositorios;
using Microsoft.EntityFrameworkCore.Internal;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using AutoMapper;

namespace BackendEstadistica.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepositorio usuarioRepositorio;
    private readonly IMapper mapper;

    public UsuariosController( IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
    {
        this.usuarioRepositorio = usuarioRepositorio;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetUsuario()
    {

        List<Usuario> lista = usuarioRepositorio.GetUsuarios();

        return Ok(mapper.Map<List<Usuario>>(lista));  

    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var usuario = UsuariosRepositorioMemoria.Instancia.Usuarios.FirstOrDefault(u => u.Id == id);
        if (usuario == null)
        {
            // NotFound() -> Devuelve un objeto NotFoundResult que produce una respuesta HTTP 404.
            return NotFound();
        }

        // El método FirstOrDefault() devuelve el primer elemento de una secuencia o uno predeterminado
        return Ok(usuario);
    }

    // Post en nuestro Repositorio
    [HttpPost("local")]
    public IActionResult Post([FromBody] UsuarioDto nuevoUsuario)
    {
        // NotFound() -> El POST está vacio
        if (nuevoUsuario == null)
        {
            return NotFound();
        }
        // NotFound() -> Estos campos son obligatorios
        if (string.IsNullOrEmpty(nuevoUsuario.Nombre) ||
            string.IsNullOrEmpty(nuevoUsuario.Correo) ||
            string.IsNullOrEmpty(nuevoUsuario.Contraseña))
        {
            return BadRequest("Todos los campos del usuario (Nombre, Correo, Contraseña) son obligatorios.");
        }
        // Si todo OK: Llamamos al método Agregar usuario y devolvemos OK.
        
        return CreatedAtAction(nameof(Get), new { id = nuevoUsuario.Id }, nuevoUsuario);
    }

    // Post en el repositorio de la version modificada de clientes (PROVISIONAL, ESTE POST SE BORRARÁ)


    [HttpPost("remoto")]
    public async Task<IActionResult> Post2([FromBody] UsuarioDto nuevoUsuario)
    {
        if (nuevoUsuario == null)
        {
            return BadRequest("El usuario no puede ser nulo");
        }

        if (string.IsNullOrEmpty(nuevoUsuario.Nombre) ||
            string.IsNullOrEmpty(nuevoUsuario.Correo) ||
            string.IsNullOrEmpty(nuevoUsuario.Contraseña))
        {
            return BadRequest("Todos los campos del usuario (Nombre, Correo, Contraseña) son obligatorios.");
        }

        var jsonContent = new StringContent(JsonSerializer.Serialize(nuevoUsuario), Encoding.UTF8, "application/json");
        var response = await UsuariosRepositorioMemoria.Instancia.GetHClient().PostAsync("https://localhost:7145/api/usuarios/remoto", jsonContent);

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var createdUser = JsonSerializer.Deserialize<UsuarioDto>(responseData);
            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }

        return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
    }
}

