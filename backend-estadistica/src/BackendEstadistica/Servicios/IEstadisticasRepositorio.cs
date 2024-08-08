namespace BackendEstadistica.Servicios
{
    public interface IEstadisticasRepositorio
    {
        //Clientes
        List<Cliente> GetClientes();
        Cliente GetClienteById(int id);
        void CrearCliente(Cliente cliente);

        //Conversiones
        List<Conversion> GetConversiones();
        Conversion GetConversionById(int id);
        void GenerarConversion(Conversion conversion);

        // Transacciones
        List<Transaccion> GetTransacciones();
        Transaccion GetTransaccionById(int id);
        void CrearTransaccion(Conversion conversion);

        //Pais
        List<Pais>GetPais();
        Pais GetPaisById(int id);
        void CrearPais(Pais pais);

    }
}
