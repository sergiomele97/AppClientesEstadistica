namespace BackendEstadistica.Servicios
{
    public interface IClienteConversionRepositorio
    {
        //Clientes
        List<Cliente> GetClientes();
        Cliente GetClienteById(int id);
        void CrearCliente(Cliente cliente);

        //Conversiones
        List<Conversion> GetConversiones();
        Conversion GetConversionById(int id);
        void GenerarConversion(Conversion conversion);

    }
}
