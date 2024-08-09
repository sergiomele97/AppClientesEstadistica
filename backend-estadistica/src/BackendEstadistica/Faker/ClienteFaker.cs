using Bogus;

namespace BackendEstadistica.Faker;

public class ClienteFaker : Faker<Cliente>
{

    public ClienteFaker()
    {
        RuleFor(c => c.Nombre, f => f.Name.FullName())
            .RuleFor(c => c.Contraseña, f => f.Internet.Password())
            .RuleFor(c => c.Correo, f => f.Internet.Email())
            .RuleFor(c => c.Telefono, f => f.Phone.PhoneNumber("##########"))
            .RuleFor(c => c.Edad, f => f.Random.Int(18, 80))
            .RuleFor(c => c.Sexo, f => f.PickRandom(new[] { "Masculino", "Femenino" }))
            .RuleFor(c => c.Trabajo, f => f.Name.JobTitle())
            .RuleFor(c => c.PaisId, f => f.Random.Int(1, 10));

        // Simulación de relaciones, puedes ajustar según tus necesidades
        RuleFor(c => c.Conversiones, f => new List<Conversion> {
                new ConversionFaker().Generate()
            });
        RuleFor(c => c.TransaccionesOrigen, f => new List<Transaccion> {
                new TransaccionFaker().Generate()
            });
        RuleFor(c => c.TransaccionesDestino, f => new List<Transaccion> {
                new TransaccionFaker().Generate()
            });
    }

}
