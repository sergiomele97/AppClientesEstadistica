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

    // Gestión de registro:
    
        // Post en nuestro Repositorio


    [HttpPost("crearUsuario")]
    public IActionResult AddUsuario([FromBody] Usuario nuevoUsuario)
    {


        // NotFound() -> El POST está vacio
        if (nuevoUsuario == null)
        {
            return NotFound();
        }
        // NotFound() -> Estos campos son obligatorios
        if (string.IsNullOrEmpty(nuevoUsuario.Telefono) ||
            string.IsNullOrEmpty(nuevoUsuario.Correo) ||
            string.IsNullOrEmpty(nuevoUsuario.Contraseña))
        {
            return BadRequest("Todos los campos del usuario (Nombre, Correo, Contraseña) son obligatorios.");
        }
        // Si todo OK: Llamamos al método Agregar usuario y devolvemos OK.
        if (!nuevoUsuario.Correo.IsValidEmail())
        {

            return BadRequest("El formato del correo no es válido");

        }

        if (usuarioRepositorio.EmailExist(nuevoUsuario.Correo))
        {

            return BadRequest("El email ya está en uso.");

        }

        try
        {
            // Agregar el usuario usando el repositorio
            usuarioRepositorio.AddUsuario(nuevoUsuario);

            // Devolver un código de estado 201 (Creado) y la ubicación del nuevo recurso
            return CreatedAtAction(nameof(AddUsuario), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }
        catch (Exception ex)
        {
            // Manejar errores, por ejemplo, problemas con la base de datos
            return StatusCode(500, $"Error al agregar el usuario: {ex.Message}");
        }

    }


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