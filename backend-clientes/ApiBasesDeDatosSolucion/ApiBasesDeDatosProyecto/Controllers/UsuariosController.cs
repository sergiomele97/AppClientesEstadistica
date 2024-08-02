
namespace ApiBasesDeDatosProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IUsuarioRepository usuarioRepository, ILogger<UsuariosController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            _logger.LogInformation($"Obteniendo todos los usuarios.");
            var usuarios = await _usuarioRepository.ObtenerTodos();
            _logger.LogInformation($"Se obtuvieron {usuarios.Count} usuarios.");
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            _logger.LogInformation($"Obteniendo usuario con ID {id}.");
                var usuario = await _usuarioRepository.ObtenerPorId(id);
                if (usuario == null)
                {
                    _logger.LogWarning($"Usuario con ID {id} no encontrado.");
                    return NotFound();
                }
                return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsuario(Usuario usuario)
        {
            //string cadena = new string('A', 5000);
            //usuario.UserName += cadena;

            //Logger
            _logger.LogInformation("Creando un nuevo usuario.");

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("El modelo Usuario no es válido.");
                return BadRequest(ModelState);
            }

            _usuarioRepository.Agregar(usuario);

            if (await _usuarioRepository.GuardarCambios())
            {
                _logger.LogInformation($"Usuario con ID {usuario.Id} creado correctamente.");
                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
            }
            _logger.LogError("No se pudo agregar el usuario.");
            return BadRequest("No se pudo agregar el usuario");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsuario(int id, Usuario usuario)
        {
            _logger.LogInformation($"Actualizando usuario con ID {id}.");
            if (id != usuario.Id)
            {
                _logger.LogWarning($"El id del usuario en la solicitud ({usuario.Id}) no coincide con el id de la url ({id})");
                return BadRequest("ID del usuario no coincide");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("El modelo Usuario no es válido.");
                return BadRequest(ModelState);
            }

            _usuarioRepository.Actualizar(usuario);

            if (await _usuarioRepository.GuardarCambios())
            {
                _logger.LogInformation($"Usuario con ID {id} actualizado correctamente.");
                return NoContent();
            }

            _logger.LogError("No se pudo actualizar el usuario.");
            return BadRequest("No se pudo actualizar el usuario");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            _logger.LogInformation($"Eliminando usuario con ID {id}.");
            var usuario = await _usuarioRepository.ObtenerPorId(id);
            if (usuario == null)
            {
                _logger.LogWarning($"Usuario con ID {id} no encontrado.");
                return NotFound();
            }

            _usuarioRepository.Eliminar(usuario);
            if (await _usuarioRepository.GuardarCambios())
            {
                _logger.LogInformation($"Usuario con ID {id} eliminado correctamente.");
                return NoContent();
            }

            _logger.LogError($"Error al eliminar el usuario con ID {id}.");
            return BadRequest("No se pudo eliminar el usuario");
        }
    }
}
