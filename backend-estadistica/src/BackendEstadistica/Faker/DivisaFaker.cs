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
        

            this.RuleFor(d => d.Nombre, f => divisa) // Asignar el nombre de la divisa
                .RuleFor(d => d.Valor, f => Math.Round(f.Random.Double(0, 2), 2)) // Generar un valor aleatorio
                .RuleFor(d => d.Fecha, f => fecha); // Usar la misma fecha para todas las divisas en esta ejecución
        
    }
}