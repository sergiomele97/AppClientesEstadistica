namespace BackendEstadistica.Faker;

// Faker para Transacción
public class TransaccionFaker : Faker<TransaccionDto>
{
    public TransaccionFaker(IEnumerable<Cliente> clientes)
    {
        RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 100.0))
            .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1.0, 100.0))
            .RuleFor(t => t.Fecha, f => f.Date.Past(1))
            .RuleFor(t => t.ClienteOrigenId, f => f.PickRandom(clientes).ClienteId)
            .RuleFor(t => t.ClienteDestinoId, (f, t) =>
                {
                    int destinoId;
                    do
                    {
                        destinoId = f.PickRandom(clientes).ClienteId;
                    } while (destinoId == t.ClienteOrigenId);
                    return destinoId;
                });
    }
}
