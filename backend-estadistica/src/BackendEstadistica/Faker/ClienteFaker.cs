namespace BackendEstadistica.Faker;

/// <summary>
/// Faker para generar datos ficticios de clientes.
/// </summary>
public class ClienteFaker : Faker<ClienteDto>
{
    private static readonly string[] Sexos = { "Masculino", "Femenino" };
    private static readonly string[] Trabajos =
    {
        "Agricultura y ganadería",
        "Comercio y ventas",
        "Servicios de alimentos y hospitalidad",
        "Manufactura",
        "Construcción",
        "Transporte y logística",
        "Educación",
        "Salud y servicios sociales",
        "Tecnología de la información",
        "Servicios financieros y seguros"
    };

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ClienteFaker"/>.
    /// </summary>
    /// <param name="paises">Colección de países existentes para seleccionar un <see cref="PaisId"/>.</param>
    public ClienteFaker(IEnumerable<Pais> paises)
    {
        RuleFor(c => c.Nombre, f => f.Name.FullName())
            .RuleFor(c => c.Correo, f => f.Internet.Email())
            .RuleFor(c => c.Telefono, f => f.Phone.PhoneNumber("##########"))
            .RuleFor(c => c.Edad, f => f.Random.Int(18, 80))
            .RuleFor(c => c.Sexo, f => f.PickRandom(Sexos))
            .RuleFor(c => c.Trabajo, f => f.PickRandom(Trabajos))
            .RuleFor(c => c.PaisId, f => f.PickRandom(paises).PaisId);
    }
}
