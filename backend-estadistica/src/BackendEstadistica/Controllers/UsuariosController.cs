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
        return Ok(UsuariosRepositorioMemoria.Instancia.Usuarios.FirstOrDefault(u => u.Id == id));
    }
}
