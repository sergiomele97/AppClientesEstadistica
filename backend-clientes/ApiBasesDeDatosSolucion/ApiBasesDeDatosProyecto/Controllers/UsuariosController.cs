
namespace ApiBasesDeDatosProyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.ObtenerTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsuario(Usuario usuario)
        {
            //string cadena = new string('A', 5000);
            //usuario.UserName += cadena;

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _usuarioRepository.Agregar(usuario);
            if (await _usuarioRepository.GuardarCambios())
            {
                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
            }
            return BadRequest("No se pudo agregar el usuario");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest("ID del usuario no coincide");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _usuarioRepository.Actualizar(usuario);
            if (await _usuarioRepository.GuardarCambios())
            {
                return NoContent();
            }
            return BadRequest("No se pudo actualizar el usuario");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioRepository.Eliminar(usuario);
            if (await _usuarioRepository.GuardarCambios())
            {
                return NoContent();
            }
            return BadRequest("No se pudo eliminar el usuario");
        }
    }
}
