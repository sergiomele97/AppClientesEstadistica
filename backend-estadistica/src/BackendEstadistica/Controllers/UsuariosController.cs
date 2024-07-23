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
}

