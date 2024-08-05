using Bogus;

namespace BackendEstadistica.Faker;

public class EnvioEjemploFaker : Faker<EnvioEjemplo>
{

    public EnvioEjemploFaker()
    {
        RuleFor(e => e.Id, f => f.IndexFaker + 1) // Genera un Id secuencial
            .RuleFor(e => e.Divisa, f => f.Finance.Currency().Code) // Genera un código de divisa
            .RuleFor(e => e.Cantidad, f => f.Random.Double(1.0, 1000.0)) // Genera una cantidad aleatoria
            .RuleFor(e => e.Fecha, f => f.Date.Past());
    }

}
