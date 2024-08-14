using Bogus;

namespace BackendEstadistica.Faker;


// Faker para País
public class PaisFaker : Faker<PaisDto>
{
    public PaisFaker()
    {
        RuleFor(p => p.Nombre, f => f.Address.Country())
            .RuleFor(p => p.Divisa, f => f.Finance.Currency().Code);
    }
}
