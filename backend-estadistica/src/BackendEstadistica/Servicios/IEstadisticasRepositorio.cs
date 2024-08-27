using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendEstadistica.Servicios
{
    public interface IEstadisticasRepositorio
    {
        //Clientes
        Task<Cliente> GetRandomClientAsync();
        Task<List<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task CrearClienteAsync(Cliente cliente);

    //Conversiones
    List<Conversion> GetConversiones();
    Conversion GetConversionById(int id);
    void CrearConversion(Conversion conversion);
    // Divisas
    List<Divisa> GetDivisa();
    Divisa GetDivisaById(int id);
    void CrearDivisa(Divisa divisa);

        // Transacciones
        Task<List<Transaccion>> GetTransaccionesAsync();
        Task<Transaccion> GetTransaccionByIdAsync(int id);
        Task CrearTransaccionAsync(Transaccion transaccion);
        Task DetectarOutliersAsync();
        Task<bool> EliminarOutlierAsync(int transaccionId);

        //Paises
        Task<List<Pais>> GetPaisesAsync();
        Task<Pais> GetPaisByIdAsync(int id);
        Task CrearPaisAsync(Pais pais);
    }
}
