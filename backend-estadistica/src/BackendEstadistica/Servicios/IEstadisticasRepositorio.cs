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
        Task<List<Conversion>> GetConversionesAsync();
        Task<Conversion> GetConversionByIdAsync(int id);
        Task CrearConversionAsync(Conversion conversion);

        // Divisas
        Task<List<Divisa>> GetDivisasAsync();
        Task<Divisa> GetDivisaByIdAsync(int id);
        Task CrearDivisaAsync(Divisa divisa);

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
