namespace BackendEstadistica.Controllers
{
    /* Los controladores en ASP.NET Core MVC manejan las solicitudes HTTP entrantes,
     * coordinan la lógica de negocio y devuelven respuestas JSON/XML al cliente.
     * Cada método dentro del controlador, conocido como una acción, corresponde a 
     * una ruta específica en la aplicación.
     */

    [Route("api/usuarios")] // Define la ruta base para las acciones en este controlador.
    [ApiController] // Marca la clase como un controlador de API con características adicionales.
    public class UsuariosController : ControllerBase
    {
        // UserManager: Clase para la gestión de usuarios en ASP.NET Core Identity.
        private readonly UserManager<ApplicationUser> _userManager;
        // SignInManager: Clase para manejar el inicio de sesión de usuarios.
        private readonly SignInManager<ApplicationUser> _signInManager;
        // TokenService: Servicio para generar y devolver tokens JWT.
        private readonly ITokenService _tokenService;

        // Repositorio para operaciones relacionadas con usuarios.
        private readonly IUsuarioRepositorio usuarioRepositorio;
        // Servicio para mapear entre diferentes tipos de objetos (DTOs y entidades).
        private readonly IMapper mapper;
        // Servicio para registrar mensajes de log.
        private readonly ILogger<UsuariosController> _logger;

        // Constructor del controlador para inyectar las dependencias necesarias.
        public UsuariosController(
            IUsuarioRepositorio usuarioRepositorio, // Repositorio para acceder a datos de usuarios.
            IMapper mapper, // Servicio para el mapeo de objetos.
            ILogger<UsuariosController> logger, // Servicio para registrar mensajes de log.
            UserManager<ApplicationUser> userManager, // Gestor de operaciones relacionadas con usuarios.
            SignInManager<ApplicationUser> signInManager, // Gestor de operaciones relacionadas con el inicio de sesión.
            ITokenService tokenService // Servicio para la generación de tokens JWT.
        )
        {
            // Asigna las dependencias inyectadas a los campos privados.
            this.usuarioRepositorio = usuarioRepositorio;
            this.mapper = mapper;
            _logger = logger;

            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        //--------------------------------- Gestión de REGISTRO:

        // Post en nuestro Repositorio
        [HttpPost("register")] // Ruta: POST api/usuarios/register
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            // Validar que la contraseña y la confirmación de contraseña coincidan.
            if (model.Password != model.ConfirmPassword)
            {
                // Si las contraseñas no coinciden, devuelve un error de solicitud incorrecta.
                return BadRequest("Las contraseñas no coinciden.");
            }

            // Extraer la parte local del correo electrónico (todo lo que está antes del '@')
            var emailParts = model.Email.Split('@');
            var userName = emailParts.Length > 1 ? emailParts[0] : model.Email;

            // Crear una nueva instancia de ApplicationUser usando los datos del modelo.
            var user = new ApplicationUser
            {
                // El nombre de usuario es el correo electrónico. En IdentityUser, 'UserName' es obligatorio.
                UserName = userName,
                // El correo electrónico del usuario. Se usa para la verificación de correo electrónico en muchas configuraciones.
                Email = model.Email,
                // Asignar el número de teléfono si es necesario, el modelo no tiene esta información, puedes omitirlo si no se requiere.
                PhoneNumber = model.PhoneNumber, // Asignar un valor por defecto o una lógica adecuada si tienes esta información.
            };

            // Crear el usuario en el sistema usando el UserManager.
            var result = await _userManager.CreateAsync(user, model.Password);

            // Verificar si la creación del usuario fue exitosa.
            if (!result.Succeeded)
            {
                // Si la creación falla, devuelve los errores de la creación.
                return BadRequest(result.Errors);
            }

            // Generar un token JWT para el usuario recién creado.
            var token = _tokenService.GenerateJwtToken(user);

            // Devolver una respuesta HTTP 200 OK con el token JWT en el cuerpo de la respuesta.
            return Ok(new { Token = token });
        }

        //--------------------------------- Gestión de REGISTRO:

        //--------------------------------- Gestión de LOGIN:

        [HttpPost("login")] // Ruta: POST api/usuarios/login
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            // Intentamos buscar al usuario en la base de datos usando su correo electrónico.
            // 'FindByEmailAsync' busca un usuario que coincida con el email proporcionado.
            var user = await _userManager.FindByEmailAsync(model.Email);

            // Si el usuario no se encuentra en la base de datos, devolvemos una respuesta 401 Unauthorized.
            // Esto indica que el usuario no existe o las credenciales son incorrectas.
            if (user == null)
            {
                return Unauthorized(); // No se encontró el usuario, por lo que no se puede autenticar.
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

                // Devolvemos una respuesta HTTP 200 OK con el token JWT.
                return Ok(new { Token = token });
            }

            // Si el inicio de sesión falla, devolvemos una respuesta 401 Unauthorized.
            // Esto puede suceder si la contraseña es incorrecta o si el usuario está bloqueado.
            return Unauthorized();
        }


        //--------------------------------- Gestión de LOGIN:

        [HttpGet("getUsers")]
        public IActionResult GetUsuarios()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
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

        //      Get Usuarios
        // -------------------- Método Sergio para Debuggear en Azure, no borrar:
        [HttpPost("fake")]
        public IActionResult GuardarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            // Mapear el DTO a la entidad de dominio
            Usuario usuario = mapper.Map<Usuario>(usuarioDto);

            // Guardar el usuario en el repositorio
            usuarioRepositorio.AddUsuario(usuario);

            // Devolver el usuario guardado con su nuevo ID
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, mapper.Map<UsuarioDto>(usuario));
        }

        // -------------------- Fin Método Sergio para Debuggear en Azure, no borrar:



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

}