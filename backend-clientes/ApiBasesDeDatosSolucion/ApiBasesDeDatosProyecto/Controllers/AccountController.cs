using ApiBasesDeDatosProyecto.Entities;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IClienteService _clienteService;
    private readonly ApiBasesDeDatosProyecto.IDentity.Serivicios.IUserService _userService;
    private readonly IPaisRepository _paisRepository; // Añadido

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ITokenService tokenService,
        IClienteService clienteService,
        ApiBasesDeDatosProyecto.IDentity.Serivicios.IUserService userService,
        IPaisRepository paisRepository) // Añadido
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _clienteService = clienteService;
        _userService = userService;
        _paisRepository = paisRepository; // Añadido
    }
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers(string? mail = null)
    {
        if (string.IsNullOrEmpty(mail))
        {
            // Si no se proporciona un mail, devuelve todos los usuarios.
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        else
        {
            // Si se proporciona un mail, busca un usuario específico por correo electrónico.
            var user = await _userService.GetUserByEmailAsync(mail);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(user);
        }
    }

    [HttpGet("verificarRol")]
    public async Task<IActionResult> VerificarRol(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        var roles = await _userManager.GetRolesAsync(user);
        return Ok(new { roles });
    }

    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var result = await _userService.DeleteUserAsync(id);
        if (result)
        {
            return Ok(new { message = "User deleted successfully" });
        }
        return NotFound(new { message = "User not found" });
    }

    [HttpGet("users/{email}")]
    public async Task<ActionResult<ApplicationUser>> GetUserByEmail(string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }
        return Ok(user);
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        
        string rolPorDefecto = "Admin";
        DateTime FechaNac = DateTimeOffset.FromUnixTimeMilliseconds(model.FechaNacimiento).UtcDateTime;


        var user = new ApplicationUser
        {
            FullName = model.Nombre + " " + model.Apellido,
            UserName = model.Email,
            Email = model.Email,
            DateOfBirth = FechaNac,
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        // Generar el token y devolverlo
        var token = _tokenService.GenerateJwtToken(user);
        return Ok(new { Token = token });
    }


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
            var token = _tokenService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }

    [HttpPost("cambiarRolPorEmail")]
    public async Task<IActionResult> CambiarRolUsuario([FromBody] ChangeRoleViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        if (!await _roleManager.RoleExistsAsync(model.NuevoRol))
        {
            return BadRequest("Role does not exist.");
        }

        // Obtener los roles actuales del usuario
        var currentRoles = await _userManager.GetRolesAsync(user);

        // Eliminar roles antiguos si es necesario
        foreach (var role in currentRoles)
        {
            if (await _userManager.IsInRoleAsync(user, role))
            {
                var removeResult = await _userManager.RemoveFromRoleAsync(user, role);
                if (!removeResult.Succeeded)
                {
                    return BadRequest("Failed to remove old role.");
                }
            }
        }

        // Asignar el nuevo rol al usuario
        var addResult = await _userManager.AddToRoleAsync(user, model.NuevoRol);
        if (!addResult.Succeeded)
        {
            return BadRequest("Failed to add new role.");
        }

        if (model.NuevoRol == "Client")
        {

         // Obtener el ID del país a través del repositorio
        var pais = await _paisRepository.ObtenerPorNombre(model.Pais);
        if (pais == null)
        {
            return BadRequest("Country not found.");
        }

        DateTime FechaNac = DateTimeOffset.FromUnixTimeMilliseconds(model.FechaNacimiento).UtcDateTime;
            // Si es un cliente, guardar datos adicionales
            var cliente = new Cliente
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                PaisId = pais.Id, // Asignar el ID del país obtenido
                Empleo = model.Empleo,
                FechaNacimiento = FechaNac,
                // Asignar el ID del usuario si es necesario
                //UserId = user.Id
            };
            await _clienteService.RegisterClientAsync(cliente);
        }


        return Ok(new { message = "Role changed successfully." });
    }
}