
namespace BackendEstadistica.Servicios
{
    public class ClienteConversionRepositorio : IClienteConversionRepositorio
    {
        private readonly ContextoBBDD contextoBBDD;

        public ClienteConversionRepositorio(ContextoBBDD contextoBBDD)
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

    }
}
