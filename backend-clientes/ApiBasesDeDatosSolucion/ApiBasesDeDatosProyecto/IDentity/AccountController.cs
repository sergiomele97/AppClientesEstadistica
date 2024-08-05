﻿[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IClienteService _clienteService;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ITokenService tokenService,
        IClienteService clienteService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _clienteService = clienteService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        // Validar que el rol sea válido
        if (!await _roleManager.RoleExistsAsync(model.Rol))
        {
            return BadRequest("Role does not exist.");
        }

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            Rol = model.Rol // Asignar el rol recibido
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            // Asignar rol a usuario
            await _userManager.AddToRoleAsync(user, user.Rol);

            // Si es un cliente, guardar datos adicionales
            if (user.Rol == "Client")
            {
                var cliente = new Cliente
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    FechaNacimiento = model.FechaNacimiento,
                    PaisId = model.PaisId,
                    Empleo = model.Empleo
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
}
