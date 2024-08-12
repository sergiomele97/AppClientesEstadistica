using BackendEstadistica.Contexto;
using Bogus;

namespace BackendEstadistica.Faker;

// Faker para Transacción
public class TransaccionFaker : Faker<TransaccionDto>
{
    public TransaccionFaker()
    {
        //int maxClienteId = contextoBBDD.Paises.Max(p => p.PaisId); // Obtén el máximo PaisId en la base de datos

        RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 100.0))
            .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1.0, 100.0))
            .RuleFor(t => t.Fecha, f => f.Date.Past(1))
            .RuleFor(t => t.ClienteOrigenId, f => f.Random.Int(1, 10))
            .RuleFor(t => t.ClienteDestinoId, (f, t) =>
                {
                    int destinoId;
                    do
                    {
                        destinoId = f.Random.Int(1, 10);
                    } while (destinoId == t.ClienteOrigenId);
                    return destinoId;
                });
    }
}
