public class DivisaFaker : Faker<DivisaDto>
{
   
    public DivisaFaker(String divisa, DateTime fecha)
    {
        

            this.RuleFor(d => d.Nombre, f => divisa) // Asignar el nombre de la divisa
                .RuleFor(d => d.Valor, f => Math.Round(f.Random.Double(0, 2), 2)) // Generar un valor aleatorio
                .RuleFor(d => d.Fecha, f => fecha); // Usar la misma fecha para todas las divisas en esta ejecución
        
    }
}
