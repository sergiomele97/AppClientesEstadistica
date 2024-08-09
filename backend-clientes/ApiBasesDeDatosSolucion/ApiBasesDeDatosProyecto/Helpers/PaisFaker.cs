namespace ApiBasesDeDatosProyecto.Helpers
{
    public class PaisFaker: Faker<Pais>
    {
        private static int _idCounter = 1;
        public PaisFaker() : base("es")
        {
            RuleFor(d => d.Id, f => _idCounter++);
            RuleFor(d => d.Nombre, f => f.Address.Country());
            RuleFor(d => d.Divisa, f => f.Finance.Currency().Code);
            RuleFor(d => d.Iso3, f => f.Address.CountryCode());
            RuleFor(d => d.Clientes, f => new ClienteFaker().Generate(5));
        }
    }
}
