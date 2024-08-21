using BackendEstadistica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
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
    // UserManager: clase en ASP.NET Core Identity que administra las operaciones relacionadas con los usuarios
    private readonly UserManager<ApplicationUser> _userManager;
    // SignInManager: clase en ASP.NET Core Identity que maneja el inicio de sesión del usuario
    private readonly SignInManager<ApplicationUser> _signInManager;
    // TokenService: servicio para devolver un token
    //private readonly ITokenService _tokenService;

    private readonly IUsuarioRepositorio usuarioRepositorio;
    private readonly IMapper mapper;
    private readonly ILogger<UsuariosController> _logger;


    //  Constructor de la clase:
    public UsuariosController( 
        IUsuarioRepositorio usuarioRepositorio, 
        IMapper mapper, 
        ILogger<UsuariosController> logger,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
        //ITokenService tokenService 

        )

    {
        this.usuarioRepositorio = usuarioRepositorio;
        this.mapper = mapper;
        _logger = logger;

        // Instancias para el login:
        _userManager = userManager;
        _signInManager = signInManager;
        //_tokenService = tokenService;

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

        //----------------------------- Identity

        // Se guarda en el Identity
        var user = new ApplicationUser { UserName = usuario.Correo, Email = usuario.Correo };
        var result = await _userManager.CreateAsync(user, usuario.Contraseña);

        if (!result.Succeeded) 
        {
            _logger.LogError("No se pudo agregar el usuario.");
            return BadRequest(result.Errors); 
        }

        //Aquí habria que devolver el token en el OK en vez del user

        return Ok(user);
        
    }


    //---------------------------------------------------------------------------------- Gestión de REGISTRO:


    //---------------------------------------------------------------------------------- Gestión de LOGIN:

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(
            model.Email,
            model.Password,
            model.RememberMe,
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            // var token = _tokenService.GenerateJwtToken(user);
            // return Ok(new { Token = token });
            return Ok();
        }

        return Unauthorized();
    }

    //---------------------------------------------------------------------------------- Gestión de LOGIN:


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