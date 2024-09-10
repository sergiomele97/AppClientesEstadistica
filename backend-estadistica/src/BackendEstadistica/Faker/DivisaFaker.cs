namespace BackendEstadistica.Faker;

/// <summary>
/// Faker para generar datos ficticios de divisas.
/// </summary>
public class DivisaFaker : Faker<DivisaDto>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="DivisaFaker"/>.
    /// </summary>
    /// <param name="divisa">Nombre de la divisa.</param>
    /// <param name="fecha">Fecha de registro de la divisa.</param>
    public DivisaFaker(string divisa, DateTime fecha)
    {
        RuleFor(d => d.Nombre, f => divisa)
            .RuleFor(d => d.Valor, f => Math.Round(f.Random.Double(0.01, 100.00), 2))
            .RuleFor(d => d.Fecha, f => fecha);
    }
}