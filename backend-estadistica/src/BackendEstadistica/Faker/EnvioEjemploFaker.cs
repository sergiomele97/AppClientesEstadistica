using Bogus;

namespace BackendEstadistica.Faker;

public class EnvioEjemploFaker : Faker<EnvioEjemplo>
{

    public EnvioEjemploFaker()
    {

            RuleFor(e => e.Divisa, f => f.Finance.Currency().Code) // Genera un código de divisa
            .RuleFor(e => e.Cantidad, f => f.Random.Double(1.0, 100.0)) // Genera una cantidad aleatoria
            .RuleFor(e => e.Fecha, f => f.Date.Past());

    }
    
}
