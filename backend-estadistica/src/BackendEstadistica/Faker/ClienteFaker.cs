using BackendEstadistica.Contexto;
using Bogus;

namespace BackendEstadistica.Faker;

// Faker para Cliente
public class ClienteFaker : Faker<ClienteDto>
{
    public ClienteFaker()
    {
        //int maxPaisId = contextoBBDD.Paises.Max(p => p.PaisId); // Obtén el máximo PaisId en la base de datos

        RuleFor(c => c.Nombre, f => f.Name.FullName())
            .RuleFor(c => c.Contraseña, f => f.Internet.Password())
            .RuleFor(c => c.Correo, f => f.Internet.Email())
            .RuleFor(c => c.Telefono, f => f.Phone.PhoneNumber("##########"))
            .RuleFor(c => c.Edad, f => f.Random.Int(18, 80))
            .RuleFor(c => c.Sexo, f => f.PickRandom(new[] { "Masculino", "Femenino" }))
            .RuleFor(c => c.Trabajo, f => f.Name.JobTitle())
            .RuleFor(c => c.PaisId, f => f.Random.Int(1, 10));
    }
}
