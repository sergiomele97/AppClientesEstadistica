namespace BackendEstadistica.Faker
{
    public class OutliersFaker : Faker<Transaccion>
    {

           public OutliersFaker(Cliente origen, Cliente destino) 
        {
            RuleFor(t => t.ImporteRecibido, f => f.Random.Double(1.0, 100.0))
               .RuleFor(t => t.ImporteEnviado, f => f.Random.Double(1000.0, 5000.0))
               .RuleFor(t => t.Fecha, f => f.Date.Past(1))
               .RuleFor(t => t.ClienteOrigenId, _ => origen.ClienteId) 
               .RuleFor(t => t.ClienteDestinoId, _ => destino.ClienteId);
        }

    }
}
