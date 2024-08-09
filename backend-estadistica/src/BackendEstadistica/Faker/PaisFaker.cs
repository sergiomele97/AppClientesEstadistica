using Bogus;

namespace BackendEstadistica.Faker
{
    public class PaisFaker : Faker<Pais>
    {

        public PaisFaker() 
        {

            RuleFor(p => p.Nombre, f => f.Address.Country()) 
               .RuleFor(p => p.Divisa, f => f.Finance.Currency().Code);

        }
    }
}
