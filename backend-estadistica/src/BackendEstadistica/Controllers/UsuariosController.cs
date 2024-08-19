using System.Runtime.InteropServices;

namespace BackendEstadistica.Controllers;

/* Los controllers en ASP.NET Core MVC son responsables de manejar las solicitudes 
 * HTTP entrantes y coordinar la respuesta adecuada. 
 * Reciben los datos de la solicitud, procesan la lógica de negocio utilizando
 * modelos y servicios, y finalmente devuelven una vista o una respuesta JSON/XML al cliente. 
 * Cada método en un controller, conocido como una acción, corresponde a una ruta
 * específica en la aplicación
 */

[Route("api/usuarios")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepositorio usuarioRepositorio;
    private readonly IMapper mapper;
    private readonly ILogger<UsuariosController> _logger;


    //  Constructor de la clase:
    public UsuariosController( IUsuarioRepositorio usuarioRepositorio, IMapper mapper, ILogger<UsuariosController> logger)
    {
        this.usuarioRepositorio = usuarioRepositorio;
        this.mapper = mapper;
        _logger = logger;
    }

    //---------------------------------------------------------------------------------- Gestión de REGISTRO:

    // Post en nuestro Repositorio


    [HttpPost]
    public async Task<ActionResult> PostUsuario([FromBody] Usuario usuario)
    {
        // Logger
        _logger.LogInformation("Creando un nuevo usuario.");

        // Validar si el usuario es nulo
        if (usuario == null)
        {
            _logger.LogWarning("El modelo Usuario está vacío.");
            return NotFound();
        }

        // Validar los campos obligatorios
        if (string.IsNullOrEmpty(usuario.Correo) ||
            string.IsNullOrEmpty(usuario.Contraseña) ||
            string.IsNullOrEmpty(usuario.Telefono))
        {
            _logger.LogWarning("Faltan campos obligatorios en el modelo Usuario.");
            return BadRequest("Todos los campos del usuario (Correo, Contraseña) son obligatorios.");
        }

        // Validar el formato del correo electrónico
        if (!usuario.Correo.IsValidEmail())
        {
            _logger.LogWarning("El formato del correo electrónico no es válido.");
            return BadRequest("El formato del correo no es válido.");
        }

        // Verificar si el correo ya existe en el repositorio
        if (usuarioRepositorio.EmailExist(usuario.Correo))
        {
            _logger.LogWarning("El correo electrónico ya está en uso.");
            return BadRequest("El email ya está en uso.");
        }

        // Validar el modelo
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("El modelo Usuario no es válido.");
            return BadRequest(ModelState);
        }

        try
        {            // ADD
            usuarioRepositorio.AddUsuario(usuario);

            if (await usuarioRepositorio.GuardarCambios())
            {
                _logger.LogInformation($"Usuario con ID {usuario.Id} creado correctamente.");
                return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
            }
            else
            {
                _logger.LogError("No se pudo agregar el usuario.");
                return BadRequest("No se pudo agregar el usuario.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al agregar el usuario: {ex.Message}");
            return StatusCode(500, $"Error al agregar el usuario: {ex.Message}");
        }
    }


    //---------------------------------------------------------------------------------- Gestión de REGISTRO:


    //  Otros métodos:


    //      Get Usuarios
    // -------------------- Método Sergio para Debuggear en Azure, no borrar:
    [HttpGet("{id}")]
    public IActionResult GetUsuarioById(int id)
    {

        Usuario usarioId = usuarioRepositorio.GetUsuarioById(id);

        return Ok(mapper.Map<Usuario>(usarioId));

    }
    // -------------------- Fin Método Sergio para Debuggear en Azure, no borrar:

    //      Get Usuarios By Id
    


 
    


    //      Delete Usuario
    [HttpDelete("borrarUsuario/{id}")]
    public IActionResult DeleteUsuario(int id)
    {

        bool usuarioEliminado = usuarioRepositorio.DeleteUsuario(id);

        if (!usuarioEliminado)
        {
            return NotFound("El usuario que intenta borrar no existe");
        }

        return Ok("El usuario se borró correctamente");

    }

}