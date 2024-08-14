using BackendEstadistica.Contexto;
using Bogus;

namespace BackendEstadistica.Faker;
// Faker para Conversión
public class ConversionFaker : Faker<ConversionDto>
{
    public ConversionFaker()
    {
        //int maxClienteId = contextoBBDD.Paises.Max(p => p.PaisId); // Obtén el máximo ClienteId en la base de datos

        RuleFor(c => c.Fecha, f => f.Date.Past(1))
            .RuleFor(c => c.MonedaOrigen, f => f.Finance.Currency().Code)
            .RuleFor(c => c.MonedaDestino, f => f.Finance.Currency().Code)
            .RuleFor(c => c.ValorOrigen, f => f.Random.Double(1.0, 100.0))
            .RuleFor(c => c.ValorDestino, f => f.Random.Double(1.0, 100.0))
            .RuleFor(c => c.ClienteId, f => f.Random.Int(1, 10));
    }
}