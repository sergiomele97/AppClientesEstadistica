using Bogus;

namespace BackendEstadistica.Faker
{
    public class TransaccionFaker : Faker<Transaccion>
    {

        public TransaccionFaker()
        {
            List<Cliente> clientes = new List<Cliente>();
            int maxClienteId = clientes.Max(c => c.ClienteId);

            RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 100.0))
                .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1.0, 100.0))
                .RuleFor(t => t.Fecha, f => f.Date.Past(1))
                .RuleFor(t => t.ClienteOrigenId, f => f.Random.Int(1, maxClienteId))
                .RuleFor(t => t.ClienteDestinoId, f => f.Random.Int(1, maxClienteId));

        }

    }
}
