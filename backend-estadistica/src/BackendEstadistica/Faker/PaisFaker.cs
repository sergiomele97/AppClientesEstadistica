namespace BackendEstadistica.Faker;

/// <summary>
/// Faker para generar datos ficticios de países.
/// </summary>
public class PaisFaker : Faker<PaisDto>
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="PaisFaker"/>.
    /// </summary>
    public PaisFaker()
    {
        RuleFor(p => p.Iso3, f => f.Address.CountryCode(Bogus.DataSets.Iso3166Format.Alpha3))
            .RuleFor(p => p.Nombre, f => f.Address.Country())
            .RuleFor(p => p.Divisa, f => f.Finance.Currency().Code);
    }
}
