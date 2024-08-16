namespace BackendEstadistica.Faker;
// Faker para Conversión
public class ConversionFaker : Faker<ConversionDto>
{
    public ConversionFaker(IEnumerable<Cliente> clientes)
    {
        RuleFor(c => c.Fecha, f => f.Date.Past(1))
            .RuleFor(c => c.MonedaOrigen, f => f.Finance.Currency().Code)
            .RuleFor(c => c.MonedaDestino, f => f.Finance.Currency().Code)
            .RuleFor(c => c.ValorOrigen, f => f.Random.Double(1.0, 100.0))
            .RuleFor(c => c.ValorDestino, f => f.Random.Double(1.0, 100.0))
            .RuleFor(c => c.ClienteId, f => f.PickRandom(clientes).ClienteId); // Selecciona un PaisId existente    }

    }
}