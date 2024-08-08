using Bogus;

namespace BackendEstadistica.Faker
{
    public class TransaccionFaker : Faker<Transaccion>
    {

        public TransaccionFaker(List<Cliente> clientes)
        {
            int maxClienteId = clientes.Max(c => c.Id);

            RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 100.0))
                .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1.0, 100.0))
                .RuleFor(t => t.Fecha, f => f.Date.Past(1))
                .RuleFor(t => t.IdOrigen, f => f.Random.Int(1, maxClienteId))
                .RuleFor(t => t.IdDestino, f => f.Random.Int(1, maxClienteId));

        }

    }
}
