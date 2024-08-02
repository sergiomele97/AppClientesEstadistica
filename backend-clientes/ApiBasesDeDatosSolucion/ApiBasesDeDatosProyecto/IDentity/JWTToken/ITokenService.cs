public interface ITokenService
{
    string GenerateJwtToken(ApplicationUser user);
}
