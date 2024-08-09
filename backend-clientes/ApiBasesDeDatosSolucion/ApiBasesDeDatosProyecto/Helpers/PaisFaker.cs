namespace ApiBasesDeDatosProyecto.Helpers
{
    public class PaisFaker: Faker<Pais>
    {
        public PaisFaker() : base("es")
        {
            RuleFor(d => d.Nombre, f => f.Address.Country());
            RuleFor(d => d.Divisa, f => f.Finance.Currency().Code);
            RuleFor(d => d.Iso3, f => f.Address.CountryCode());
        }
    }
}
