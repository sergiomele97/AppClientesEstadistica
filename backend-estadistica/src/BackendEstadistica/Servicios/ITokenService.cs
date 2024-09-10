namespace BackendEstadistica.Servicios;

/// <summary>
/// Interfaz para los servicios de generación de tokens de autenticación.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Genera un token JWT (JSON Web Token) para un usuario dado.
    /// </summary>
    /// <param name="user">El usuario para el cual se generará el token.</param>
    /// <returns>El token JWT generado.</returns>
    string GenerateJwtToken(ApplicationUser user);
}
