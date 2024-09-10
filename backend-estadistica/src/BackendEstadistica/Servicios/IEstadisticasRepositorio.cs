namespace BackendEstadistica.Servicios;

/// <summary>
/// Interfaz para el repositorio de estadísticas, que proporciona operaciones para gestionar clientes, divisas, conversiones, transacciones y países.
/// </summary>
public interface IEstadisticasRepositorio
{
    #region Clientes

    /// <summary>
    /// Obtiene un cliente aleatorio de la base de datos.
    /// </summary>
    /// <returns>Un cliente aleatorio.</returns>
    Task<Cliente> GetRandomClientAsync();

    /// <summary>
    /// Obtiene una lista de todos los clientes.
    /// </summary>
    /// <returns>Lista de clientes.</returns>
    Task<List<Cliente>> GetClientesAsync();

    /// <summary>
    /// Obtiene un cliente por su identificador.
    /// </summary>
    /// <param name="id">El identificador del cliente.</param>
    /// <returns>El cliente con el identificador especificado.</returns>
    Task<Cliente> GetClienteByIdAsync(int id);

    /// <summary>
    /// Crea un nuevo cliente en la base de datos.
    /// </summary>
    /// <param name="cliente">Los datos del cliente a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    Task CrearClienteAsync(Cliente cliente);

    #endregion

    #region Conversiones

    /// <summary>
    /// Obtiene una lista de todas las conversiones.
    /// </summary>
    /// <returns>Lista de conversiones.</returns>
    Task<List<Conversion>> GetConversionesAsync();

    /// <summary>
    /// Obtiene una conversión por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la conversión.</param>
    /// <returns>La conversión con el identificador especificado.</returns>
    Task<Conversion> GetConversionByIdAsync(int id);

    /// <summary>
    /// Crea una nueva conversión en la base de datos.
    /// </summary>
    /// <param name="conversion">Los datos de la conversión a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    Task CrearConversionAsync(Conversion conversion);

    #endregion

    #region Divisas

    /// <summary>
    /// Obtiene una lista de todas las divisas.
    /// </summary>
    /// <returns>Lista de divisas.</returns>
    Task<List<Divisa>> GetDivisasAsync();

    /// <summary>
    /// Obtiene una lista de divisas por nombre.
    /// </summary>
    /// <param name="nombre">El nombre de la divisa.</param>
    /// <returns>Lista de divisas con el nombre especificado.</returns>
    Task<List<Divisa>> GetDivisaByNameAsync(string nombre);

    /// <summary>
    /// Crea una nueva divisa en la base de datos.
    /// </summary>
    /// <param name="divisa">Los datos de la divisa a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    Task CrearDivisaAsync(Divisa divisa);

    #endregion

    #region Transacciones

    /// <summary>
    /// Obtiene una lista de todas las transacciones.
    /// </summary>
    /// <returns>Lista de transacciones.</returns>
    Task<List<Transaccion>> GetTransaccionesAsync();

    /// <summary>
    /// Obtiene una transacción por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la transacción.</param>
    /// <returns>La transacción con el identificador especificado.</returns>
    Task<Transaccion> GetTransaccionByIdAsync(int id);

    /// <summary>
    /// Crea una nueva transacción en la base de datos.
    /// </summary>
    /// <param name="transaccion">Los datos de la transacción a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    Task CrearTransaccionAsync(Transaccion transaccion);

    #endregion

    #region Outliers

    /// <summary>
    /// Detecta outliers en las transacciones y los marca.
    /// </summary>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    Task DetectarOutliersAsync();

    /// <summary>
    /// Elimina un outlier específico si existe.
    /// </summary>
    /// <param name="transaccionId">El identificador de la transacción que se desea eliminar.</param>
    /// <returns>Un valor booleano que indica si el outlier fue eliminado con éxito.</returns>
    Task<bool> EliminarOutlierAsync(int transaccionId);

    #endregion

    #region Paises

    /// <summary>
    /// Obtiene una lista de todos los países.
    /// </summary>
    /// <returns>Lista de países.</returns>
    Task<List<Pais>> GetPaisesAsync();

    /// <summary>
    /// Obtiene un país por su identificador.
    /// </summary>
    /// <param name="id">El identificador del país.</param>
    /// <returns>El país con el identificador especificado.</returns>
    Task<Pais> GetPaisByIdAsync(int id);

    /// <summary>
    /// Crea un nuevo país en la base de datos.
    /// </summary>
    /// <param name="pais">Los datos del país a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    Task CrearPaisAsync(Pais pais);

    #endregion
}
