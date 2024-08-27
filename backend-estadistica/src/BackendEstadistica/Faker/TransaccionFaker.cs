namespace BackendEstadistica.Faker
{
    // Faker para Transacción
    public class TransaccionFaker : Faker<TransaccionDto>
    {
        public TransaccionFaker(Cliente origen, Cliente destino)
        {
            RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 100.0))
                .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1000.0, 2000.0))
                .RuleFor(t => t.Fecha, f => f.Date.Past(1))
                .RuleFor(t => t.ClienteOrigenId, _ => origen.ClienteId)  // Asignar ID de origen
                .RuleFor(t => t.ClienteDestinoId, _ => destino.ClienteId);  // Asignar ID de destino
        }
    }
}