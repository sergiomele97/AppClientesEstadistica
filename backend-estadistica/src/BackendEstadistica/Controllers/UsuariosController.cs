namespace BackendEstadistica.Controllers;

/// <summary>
/// Controlador para la gestión de usuarios.
/// </summary>
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IMapper _mapper;
    private readonly ILogger<UsuariosController> _logger;

    /// <summary>
    /// Constructor del controlador de usuarios.
    /// </summary>
    /// <param name="usuarioRepositorio">Repositorio de usuarios.</param>
    /// <param name="mapper">Servicio de mapeo.</param>
    /// <param name="logger">Servicio de registro.</param>
    /// <param name="userManager">Servicio de gestión de usuarios.</param>
    /// <param name="signInManager">Servicio de gestión de inicio de sesión.</param>
    /// <param name="tokenService">Servicio de generación de tokens.</param>
    public UsuariosController(
        IUsuarioRepositorio usuarioRepositorio,
        IMapper mapper,
        ILogger<UsuariosController> logger,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ITokenService tokenService)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _mapper = mapper;
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    /// <summary>
    /// Registra un nuevo usuario en el sistema.
    /// </summary>
    /// <param name="model">Modelo de vista para el registro de usuario.</param>
    /// <returns>Resultado de la operación de registro.</returns>
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

    /// <summary>
    /// Inicia sesión con un usuario existente.
    /// </summary>
    /// <param name="model">Modelo de vista para el inicio de sesión.</param>
    /// <returns>Resultado del inicio de sesión con el token JWT si es exitoso.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return Unauthorized();
        }

        var result = await _signInManager.PasswordSignInAsync(
            user.UserName,
            model.Password,
            model.RememberMe,
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var token = _tokenService.GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                Username = user.UserName
            });
        }

        return Unauthorized();
    }

    /// <summary>
    /// Obtiene la lista de todos los usuarios del sistema.
    /// </summary>
    /// <returns>Lista de usuarios.</returns>
    [HttpGet("getUsers")]
    public async Task<IActionResult> GetUsuarios()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(users);
    }

    /// <summary>
    /// Obtiene un usuario por su identificador.
    /// </summary>
    /// <param name="id">Identificador del usuario.</param>
    /// <returns>Detalles del usuario.</returns>
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

    /// <summary>
    /// Crea un usuario ficticio para pruebas.
    /// </summary>
    /// <param name="usuarioDto">Datos del usuario a crear.</param>
    /// <returns>Resultado de la operación de creación.</returns>
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

    /// <summary>
    /// Elimina un usuario por su identificador.
    /// </summary>
    /// <param name="id">Identificador del usuario a eliminar.</param>
    /// <returns>Resultado de la operación de eliminación.</returns>
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
