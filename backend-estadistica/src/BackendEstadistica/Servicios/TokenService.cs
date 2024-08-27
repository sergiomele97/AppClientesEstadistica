namespace BackendEstadistica.Servicios;

// Implementación del servicio para generar tokens JWT
public class TokenService : ITokenService
{
    // Configuración inyectada a través del constructor
    private readonly IConfiguration _configuration;

    // Constructor que recibe la configuración para acceder a las claves y otros parámetros
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Método para generar un token JWT para un usuario específico
    public string GenerateJwtToken(ApplicationUser user)
    {
        // Crea un manejador para tokens JWT
        var tokenHandler = new JwtSecurityTokenHandler();

        // Obtiene la clave secreta de firma desde la configuración
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        // Configura las propiedades del token
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            // Define los claims (reclamaciones) del token. Estos son los datos que el token llevará
            // Aquí se incluyen el nombre de usuario y el correo electrónico del usuario.
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName), // Nombre de usuario
                new Claim(ClaimTypes.Email, user.Email) // Correo electrónico
            }),
            // Define la fecha de expiración del token
            Expires = DateTime.UtcNow.AddHours(1), // El token expirará en 1 hora
            // Define el emisor y el receptor del token
            Issuer = _configuration["Jwt:Issuer"], // Emisor del token (ej. "localhost")
            Audience = _configuration["Jwt:Audience"], // Receptor del token (ej. "localhost")
            // Define las credenciales de firma del token, utilizando la clave secreta
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), // Clave secreta para firmar el token
                SecurityAlgorithms.HmacSha256Signature // Algoritmo de firma
            )
        };

        // Crea el token usando el descriptor configurado
        var token = tokenHandler.CreateToken(tokenDescriptor);

        // Devuelve el token como una cadena de texto
        return tokenHandler.WriteToken(token);
    }
}
