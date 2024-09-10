namespace BackendEstadistica.Servicios;

/// <summary>
/// Servicio para la generación de tokens JWT.
/// </summary>
public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="TokenService"/> con la configuración proporcionada.
    /// </summary>
    /// <param name="configuration">La configuración de la aplicación.</param>
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Genera un token JWT para el usuario especificado.
    /// </summary>
    /// <param name="user">El usuario para el que se genera el token.</param>
    /// <returns>El token JWT generado.</returns>
    public string GenerateJwtToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        // Obtiene la clave secreta para firmar el token desde la configuración
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        // Define los detalles del token, como el sujeto, la fecha de expiración, el emisor, el receptor y las credenciales de firma
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1), // Expiración del token en 1 hora
            Issuer = _configuration["Jwt:Issuer"], // Emisor del token
            Audience = _configuration["Jwt:Audience"], // Audiencia del token
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature // Algoritmo de firma del token
            )
        };

        // Crea el token JWT
        var token = tokenHandler.CreateToken(tokenDescriptor);

        // Escribe el token en formato string
        return tokenHandler.WriteToken(token);
    }
}
