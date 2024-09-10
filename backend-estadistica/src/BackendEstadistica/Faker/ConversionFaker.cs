namespace BackendEstadistica.Faker;

/// <summary>
/// Faker para generar datos ficticios de conversiones.
/// </summary>
public class ConversionFaker : Faker<ConversionDto>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ConversionFaker"/>.
    /// </summary>
    /// <param name="cliente">Cliente asociado a la conversión.</param>
    public ConversionFaker(Cliente cliente)
    {
        RuleFor(c => c.Fecha, f => f.Date.Past(1))
            .RuleFor(c => c.MonedaOrigen, f => f.Finance.Currency().Code)
            .RuleFor(c => c.MonedaDestino, f => f.Finance.Currency().Code)
            .RuleFor(c => c.ValorOrigen, f => f.Random.Double(1.0, 100.0))
            .RuleFor(c => c.ValorDestino, f => f.Random.Double(1.0, 100.0))
            .RuleFor(c => c.ClienteId, f => cliente.ClienteId); // Asocia el ID del cliente
    }
}
