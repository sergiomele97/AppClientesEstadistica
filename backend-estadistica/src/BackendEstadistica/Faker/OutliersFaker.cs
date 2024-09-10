namespace BackendEstadistica.Faker;

/// <summary>
/// Faker para generar datos ficticios de transacciones con valores atípicos.
/// </summary>
public class OutliersFaker : Faker<Transaccion>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="OutliersFaker"/>.
    /// </summary>
    /// <param name="origen">Cliente origen.</param>
    /// <param name="destino">Cliente destino.</param>
    public OutliersFaker(Cliente origen, Cliente destino)
    {
        RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 100.0))
           .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1000.0, 5000.0))
           .RuleFor(t => t.Fecha, f => f.Date.Past(1))
           .RuleFor(t => t.ClienteOrigenId, _ => origen.ClienteId) // Asocia el ID del cliente origen
           .RuleFor(t => t.ClienteDestinoId, _ => destino.ClienteId); // Asocia el ID del cliente destino
    }
}