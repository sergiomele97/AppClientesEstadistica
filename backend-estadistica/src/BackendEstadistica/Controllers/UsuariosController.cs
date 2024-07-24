using BackendEstadistica.Repositorios;
using Microsoft.EntityFrameworkCore.Internal;

namespace BackendEstadistica.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UsuariosController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(UsuariosRepositorioMemoria.Instancia.Usuarios);

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

    [HttpPost]
    public IActionResult Post([FromBody] UsuarioDto nuevoUsuario)
    {
        if (string.IsNullOrEmpty(nuevoUsuario.Nombre) ||
            string.IsNullOrEmpty(nuevoUsuario.Correo) ||
            string.IsNullOrEmpty(nuevoUsuario.Contraseña))
        {
            return BadRequest("Todos los campos del usuario (Nombre, Correo, Contraseña) son obligatorios.");
        }

        UsuariosRepositorioMemoria.Instancia.AgregarUsuario(nuevoUsuario);
        return CreatedAtAction(nameof(Get), new { id = nuevoUsuario.Id }, nuevoUsuario);
    }

}

