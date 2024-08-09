using Bogus.DataSets;

namespace ApiBasesDeDatosProyecto.Helpers;
public class ClienteFaker: Faker<Cliente>
{
    private static int _idCounter = 1;
    public ClienteFaker(): base("es")
    {
        RuleFor(d => d.Id, f => _idCounter++);
        RuleFor(d => d.Nombre, f => f.Internet.UserName());
        RuleFor(d => d.Apellido, f => f.Name.LastName());
        RuleFor(d => d.FechaNacimiento, f => f.Date.Past());
        RuleFor(d => d.Empleo, f => f.Name.JobTitle());
        RuleFor(d => d.PaisId, f => f.PickRandom(1,3));
    }
}
