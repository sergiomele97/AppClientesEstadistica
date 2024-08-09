using Bogus;

namespace BackendEstadistica.Faker;

public class ClienteFaker : Faker<Cliente>
{

    public ClienteFaker()
    {
        List<Pais> paises = new List<Pais>();
        int maxPaisId = paises.Max(c => c.PaisId);

        RuleFor(c => c.Nombre, f => f.Name.FullName());
        RuleFor(c => c.Contraseña, f => f.Internet.Password());
        RuleFor(c => c.Correo, f => f.Internet.Email());
        RuleFor(c => c.Telefono, f => f.Phone.PhoneNumber());
        RuleFor(c => c.Edad, f => f.Random.Int(18, 100));
        RuleFor(c => c.Sexo, f => f.PickRandom(new[] { "Masculino", "Femenino", "Otro" }));
        RuleFor(c => c.Trabajo, f => f.Name.JobTitle());
        RuleFor(c => c.PaisId, f => f.Random.Int(1, maxPaisId));
        RuleFor(c => c.Pais, f => new PaisFaker().Generate());
    }

}
