namespace BackendEstadistica.Servicios;

public interface IEstadisticasRepositorio
{
    //Clientes
    Cliente GetRandomClient();
    List<Cliente> GetClientes();
    Cliente GetClienteById(int id);
    void CrearCliente(Cliente cliente);

    //Conversiones
    List<Conversion> GetConversiones();
    Conversion GetConversionById(int id);
    void CrearConversion(Conversion conversion);
    // Divisas
    List<Divisa> GetDivisa();
    List<Divisa> GetDivisaByName(string nombre);
    void CrearDivisa(Divisa divisa);

    // Transacciones
    List<Transaccion> GetTransacciones();
    Transaccion GetTransaccionById(int id);
    void CrearTransaccion(Transaccion transaccion);
    void DetectarOutliers();

    //Pais 
    List<Pais> GetPaises();
    Pais GetPaisById(int id);
    void CrearPais(Pais pais);

}
