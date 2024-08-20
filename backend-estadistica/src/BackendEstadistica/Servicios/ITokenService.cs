namespace BackendEstadistica.Servicios
{
    public interface ITokenService
    {
        string GenerateJwtToken(Usuario user);
    }

}
