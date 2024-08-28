using BackendEstadistica.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace BackendEstadistica.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IMapper _mapper;
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(
        IUsuarioRepositorio usuarioRepositorio,
        IMapper mapper,
        ILogger<UsuariosController> logger,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService
       
    )
    {
        _usuarioRepositorio = usuarioRepositorio;
        _mapper = mapper;
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            return BadRequest("Las contraseñas no coinciden.");
        }

        var emailParts = model.Email.Split('@');
        var userName = emailParts.Length > 1 ? emailParts[0] : model.Email;

        var user = new ApplicationUser
        {
            UserName = userName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        var token = _tokenService.GenerateJwtToken(user);

        return Ok(new { Token = token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return Unauthorized();
        }

            // Ahora que hemos encontrado al usuario, usamos su UserName (en lugar del email) para intentar iniciar sesión.
            // Esto es importante porque 'PasswordSignInAsync' generalmente espera un UserName.
            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,  // Usamos el UserName del usuario que acabamos de encontrar.
                model.Password, // La contraseña proporcionada en el modelo.
                model.RememberMe, // Si se debe recordar al usuario en futuras sesiones.
                lockoutOnFailure: false); // No bloquear al usuario en caso de múltiples intentos fallidos.

            // Si el resultado es exitoso, significa que el inicio de sesión fue correcto.
            if (result.Succeeded)
            {
                // Generamos un token JWT para el usuario autenticado.
                var token = _tokenService.GenerateJwtToken(user);

                // Devolvemos una respuesta HTTP 200 OK con el token JWT y el UserName.
                return Ok(new {
                    Token = token,
                    Username = user.UserName
                });
            }

        return Unauthorized();
    }

    [HttpGet("getUsers")]
    public async Task<IActionResult> GetUsuarios()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioById(int id)
    {
        var usuarioId = await _usuarioRepositorio.GetUsuarioByIdAsync(id);

        if (usuarioId == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        return Ok(_mapper.Map<Usuario>(usuarioId));
    }

    [HttpPost("fake")]
    public async Task<IActionResult> GuardarUsuario([FromBody] UsuarioDto usuarioDto)
    {
        if (usuarioDto == null)
        {
            return BadRequest("El usuario no puede ser nulo.");
        }

        var usuario = _mapper.Map<Usuario>(usuarioDto);

        await _usuarioRepositorio.AddUsuarioAsync(usuario);

        return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, _mapper.Map<UsuarioDto>(usuario));
    }

    [HttpDelete("borrarUsuario/{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuarioEliminado = await _usuarioRepositorio.DeleteUsuarioAsync(id);

        if (!usuarioEliminado)
        {
            return NotFound("El usuario que intenta borrar no existe");
        }

        return Ok("El usuario se borró correctamente");
    }
}
