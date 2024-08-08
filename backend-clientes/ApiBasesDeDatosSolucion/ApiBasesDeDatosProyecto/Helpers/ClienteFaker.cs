namespace ApiBasesDeDatosProyecto.Helpers
{
    public class ClienteFaker: Faker<Cliente>
    {
        public ClienteFaker()
        {
            RuleFor(d => d.Nombre, f => f.Name.ToString());
            RuleFor(d => d.Apellido, f => f.Name.LastName());
            RuleFor(d => d.FechaNacimiento, f => f.Date.Past());
            RuleFor(d => d.Empleo, f => f.Name.JobTitle());
            RuleFor(d => d.PaisId, f => f.PickRandom(1,3));
        }
    }
}
