namespace ApiBasesDeDatosProyecto.Helpers;

public class UserFaker: Faker<Usuario>
{
    private static int _idCounter = 1;
    public UserFaker() : base("es")
    {
        RuleFor(d => d.Id, f => _idCounter++);
        RuleFor(d => d.UserName, f => f.Internet.UserName());
        RuleFor(d => d.Email, f => f.Internet.Email());
    }
}
