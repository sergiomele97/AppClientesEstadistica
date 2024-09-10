namespace BackendEstadistica.Faker;

/// <summary>
/// Faker para generar datos ficticios de transacciones.
/// </summary>
public class TransaccionFaker : Faker<TransaccionDto>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="TransaccionFaker"/>.
    /// </summary>
    /// <param name="origen">Cliente origen de la transacción.</param>
    /// <param name="destino">Cliente destino de la transacción.</param>
    public TransaccionFaker(Cliente origen, Cliente destino)
    {
        RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 1000.0))
            .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1.0, 1000.0))
            .RuleFor(t => t.Fecha, f => f.Date.Past(1))
            .RuleFor(t => t.ClienteOrigenId, _ => origen.ClienteId)
            .RuleFor(t => t.ClienteDestinoId, _ => destino.ClienteId);
    }
}
