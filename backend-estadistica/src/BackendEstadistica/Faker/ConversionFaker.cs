using Bogus;

namespace BackendEstadistica.Faker
{
    public class ConversionFaker : Faker<Conversion>
    {

        public ConversionFaker()
        {
            List<Cliente> clientes = new List<Cliente>();
            int maxClienteId = clientes.Max(c => c.Id);

            RuleFor(c => c.Fecha, f => f.Date.Past(1))
            .RuleFor(c => c.MonedaOrigen, f => f.Finance.Currency().Code)
            .RuleFor(c => c.MonedaDestino, f => f.Finance.Currency().Code)
            .RuleFor(c => c.ValorOrigen, f => f.Random.Double(1.0, 100.0))
            .RuleFor(c => c.ValorDestino, f => f.Random.Double(1.0, 100.0))
            .RuleFor(c => c.ClienteId, f => f.Random.Int(1, maxClienteId));

        }

    }
}
