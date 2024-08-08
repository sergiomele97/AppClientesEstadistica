using ApiBasesDeDatosProyecto.IDentity.Serivicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IClienteService _clienteService;
    private readonly IUserService _userService;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ITokenService tokenService,
        IClienteService clienteService,
        IUserService userService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _clienteService = clienteService;
        _userService = userService;
    }

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
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

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        DateTime FechaNac = DateTimeOffset.FromUnixTimeMilliseconds(model.FechaNacimiento).UtcDateTime;
        string rolPorDefecto = "Admin";

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            DateOfBirth = FechaNac,
            Rol = rolPorDefecto
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            //Asignar un rol predeterminado
            await _userManager.AddToRoleAsync(user, rolPorDefecto);

            // Si es un cliente, guardar datos adicionales
            if (rolPorDefecto == "Client")
            {
                var cliente = new Cliente
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    PaisId = model.PaisId,
                    Empleo = model.Empleo,
                    FechaNacimiento = FechaNac,
                    // Asignar el ID del usuario si es necesario
                    //UserId = user.Id
                };
                await _clienteService.RegisterClientAsync(cliente);
            }
           
            var token = _tokenService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        return BadRequest(result.Errors);
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
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> CambiarRolUsuario([FromBody] ChangeRoleViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return NotFound();
        }

        var rolesActuales = await _userManager.GetRolesAsync(user);

        if (!await _roleManager.RoleExistsAsync(model.NuevoRol))
        {
            return BadRequest();
        }

        if (await _userManager.IsInRoleAsync(user, model.NuevoRol))
        {
            return BadRequest();
        }

        var result = await _userManager.AddToRoleAsync(user, model.NuevoRol);
        if (!result.Succeeded)
        {
            return BadRequest();
        }

        rolesActuales = await _userManager.GetRolesAsync(user);
        return Ok($"Rol actualizado correctamente - Roles actuales del usuario con Email {model.Email}: {string.Join(", ", rolesActuales)}");
    }
}
