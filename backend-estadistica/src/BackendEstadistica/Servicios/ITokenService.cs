namespace BackendEstadistica.Servicios;

public interface ITokenService
{
    string GenerateJwtToken(ApplicationUser user);
}
