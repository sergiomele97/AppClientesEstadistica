using ApiBasesDeDatosProyecto.IDentity.Serivicios;
using ApiBasesDeDatosProyecto.Models;
using ApiBasesDeDatosProyecto.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBasesDeDatosProyecto.Controllers
{
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
        private readonly IPaisRepository _paisRepository; // Añadido

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService,
            IClienteService clienteService,
            IUserService userService,
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
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
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
            // Validar que el rol sea válido
            if (!await _roleManager.RoleExistsAsync(model.Rol))
            {
                return BadRequest("Role does not exist.");
            }

            DateTime FechaNac = DateTimeOffset.FromUnixTimeMilliseconds(model.FechaNacimiento).UtcDateTime;

            // Obtener el ID del país a través del repositorio
            var pais = await _paisRepository.ObtenerPorNombre(model.PaisNombre);
            if (pais == null)
            {
                return BadRequest("Country not found.");
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                Rol = model.Rol, // Asignar el rol recibido
                DateOfBirth = FechaNac
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
                        PaisId = pais.Id, // Asignar el ID del país obtenido
                        Empleo = model.Empleo,
                        FechaNacimiento = FechaNac
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

        [HttpPost("change-role")]
        public async Task<IActionResult> ChangeRole([FromBody] ChangeRoleViewModel model)
        {
            // Validar que el rol sea válido
            if (!await _roleManager.RoleExistsAsync(model.NuevoRol))
            {
                return BadRequest("Role does not exist.");
            }

            // Buscar el usuario por su ID
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Obtener los roles actuales del usuario
            var currentRoles = await _userManager.GetRolesAsync(user);

            // Eliminar todos los roles actuales del usuario
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                return BadRequest("Failed to remove current roles.");
            }

            // Asignar el nuevo rol al usuario
            var addResult = await _userManager.AddToRoleAsync(user, model.NuevoRol);
            if (!addResult.Succeeded)
            {
                return BadRequest("Failed to add new role.");
            }

            return Ok("Role changed successfully.");
        }
    }
}
