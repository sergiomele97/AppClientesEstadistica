
namespace BackendEstadistica.Servicios
{
    public class EstadisticasRepositorio : IEstadisticasRepositorio
    {
        private readonly ContextoBBDD contextoBBDD;

        public EstadisticasRepositorio(ContextoBBDD contextoBBDD)
        {
            this.contextoBBDD = contextoBBDD;
        }


        //Clientes

        public void CrearCliente(Cliente cliente)
        {
            var clienteFake = new ClienteFaker().Generate();

            contextoBBDD.Clientes.Add(clienteFake);
            contextoBBDD.SaveChanges();
        }

        public List<Cliente> GetClientes()
        {
            return contextoBBDD.Clientes.ToList();
        }

        public Cliente GetClienteById(int id)
        {
            return contextoBBDD.Clientes.FirstOrDefault(c => c.Id == id);
        }
        

        //Conversiones

        public void GenerarConversion(Conversion conversion)
        {
            var conversionFake = new ConversionFaker().Generate();

            contextoBBDD.Conversion.Add(conversionFake);
            contextoBBDD.SaveChanges();
        }

        public List<Conversion> GetConversiones()
        {
            return contextoBBDD.Conversion.ToList();
        }

        public Conversion GetConversionById(int id)
        {
            return contextoBBDD.Conversion.FirstOrDefault(c => c.Id == id);
        }


        //Transacciones

        public void CrearTransaccion(Conversion conversion)
        {
            var transaccionFake = new TransaccionFaker().Generate();

            contextoBBDD.Transacciones.Add(transaccionFake);
            contextoBBDD.SaveChanges();
        }

        public List<Transaccion> GetTransacciones()
        {
            return contextoBBDD.Transacciones.ToList();
        }

        public Transaccion GetTransaccionById(int id)
        {
            return contextoBBDD.Transacciones.FirstOrDefault(t => t.Id == id);
        }

    }
}
