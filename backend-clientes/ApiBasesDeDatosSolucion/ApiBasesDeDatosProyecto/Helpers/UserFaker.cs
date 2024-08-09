namespace ApiBasesDeDatosProyecto.Helpers;

public class UserFaker: Faker<Usuario>
{
    public UserFaker() : base("es")
    {
        RuleFor(d => d.UserName, f => f.Name.ToString());
        RuleFor(d => d.Email, f => f.Name.ToString().ToLower() + "@example.com");
    }
}
