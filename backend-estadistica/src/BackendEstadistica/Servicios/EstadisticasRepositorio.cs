﻿
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
            return contextoBBDD.Clientes.FirstOrDefault(c => c.ClienteId == id);
        }
        

        //Conversiones

        public void CrearConversion(Conversion conversion)
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
            return contextoBBDD.Conversion.FirstOrDefault(c => c.ConversionId == id);
        }


        //Transacciones

        public void CrearTransaccion(Transaccion transaccion)
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
            return contextoBBDD.Transacciones.FirstOrDefault(t => t.TransaccionId == id);
        }



        //Paises

        public void CrearPais(Pais pais)
        {
            var paisFake = new PaisFaker().Generate();

            contextoBBDD.Paises.Add(paisFake);
            contextoBBDD.SaveChanges();
        }

        public List<Pais> GetPaises()
        {
            return contextoBBDD.Paises.ToList();
        }

        public Pais GetPaisById(int id)
        {
            return contextoBBDD.Paises.FirstOrDefault(p => p.PaisId == id);
        }
    }
}