namespace BackendEstadistica.Servicios;

/// <summary>
/// Repositorio para gestionar las operaciones de datos relacionadas con clientes, divisas, conversiones, transacciones y países.
/// </summary>
public class EstadisticasRepositorio : IEstadisticasRepositorio
{
    private readonly ContextoBBDD _contextoBBDD;
    private readonly IMapper _mapper;
    private readonly ILogger<EstadisticasRepositorio> _logger;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="EstadisticasRepositorio"/>.
    /// </summary>
    /// <param name="contextoBBDD">El contexto de la base de datos.</param>
    /// <param name="mapper">El objeto de mapeo de datos.</param>
    /// <param name="logger">El objeto de registro de logs.</param>
    public EstadisticasRepositorio(ContextoBBDD contextoBBDD, IMapper mapper, ILogger<EstadisticasRepositorio> logger)
    {
        _contextoBBDD = contextoBBDD;
        _mapper = mapper;
        _logger = logger;
    }

    #region Métodos de Cliente

    /// <summary>
    /// Crea un nuevo cliente en la base de datos.
    /// </summary>
    /// <param name="cliente">El cliente a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    public async Task CrearClienteAsync(Cliente cliente)
    {
        try
        {
            var clienteEntity = _mapper.Map<Cliente>(cliente);
            await _contextoBBDD.Clientes.AddAsync(clienteEntity);
            await _contextoBBDD.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear cliente.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene un cliente aleatorio de la base de datos.
    /// </summary>
    /// <returns>El cliente aleatorio.</returns>
    public async Task<Cliente> GetRandomClientAsync()
    {
        try
        {
            int totalClientes = await _contextoBBDD.Clientes.CountAsync();
            if (totalClientes == 0)
            {
                throw new InvalidOperationException("No hay clientes disponibles.");
            }

            var clienteAleatorio = await _contextoBBDD.Clientes
                .OrderBy(c => Guid.NewGuid()) // Selección aleatoria más eficiente
                .FirstOrDefaultAsync();

            if (clienteAleatorio == null)
            {
                throw new InvalidOperationException("No se pudo seleccionar un cliente.");
            }

            return clienteAleatorio;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener cliente aleatorio.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene todos los clientes de la base de datos.
    /// </summary>
    /// <returns>Lista de todos los clientes.</returns>
    public async Task<List<Cliente>> GetClientesAsync()
    {
        try
        {
            return await _contextoBBDD.Clientes
                .Include(c => c.Pais)
                .Include(c => c.Conversiones)
                .Include(c => c.TransaccionesOrigen)
                .Include(c => c.TransaccionesDestino)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los clientes.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene un cliente por su identificador.
    /// </summary>
    /// <param name="id">El identificador del cliente.</param>
    /// <returns>El cliente con el identificador especificado.</returns>
    public async Task<Cliente> GetClienteByIdAsync(int id)
    {
        try
        {
            return await _contextoBBDD.Clientes
                .Include(c => c.Pais)
                .Include(c => c.Conversiones)
                .Include(c => c.TransaccionesOrigen)
                .Include(c => c.TransaccionesDestino)
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener cliente por ID.");
            throw;
        }
    }

    #endregion

    #region Métodos de Divisa

    /// <summary>
    /// Crea una nueva divisa en la base de datos.
    /// </summary>
    /// <param name="divisa">La divisa a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    public async Task CrearDivisaAsync(Divisa divisa)
    {
        try
        {
            var divisaEntity = _mapper.Map<Divisa>(divisa);
            await _contextoBBDD.Divisa.AddAsync(divisaEntity);
            await _contextoBBDD.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear divisa.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene una lista de divisas por su nombre.
    /// </summary>
    /// <param name="nombre">El nombre de la divisa.</param>
    /// <returns>Lista de divisas con el nombre especificado.</returns>
    public async Task<List<Divisa>> GetDivisaByNameAsync(string nombre)
    {
        try
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return new List<Divisa>();
            }

            return await _contextoBBDD.Divisa
                .Where(d => d.Nombre == nombre)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener divisa por nombre.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene todas las divisas de la base de datos.
    /// </summary>
    /// <returns>Lista de todas las divisas.</returns>
    public async Task<List<Divisa>> GetDivisasAsync()
    {
        try
        {
            return await _contextoBBDD.Divisa.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las divisas.");
            throw;
        }
    }

    #endregion

    #region Métodos de Conversión

    /// <summary>
    /// Crea una nueva conversión en la base de datos.
    /// </summary>
    /// <param name="conversion">La conversión a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    public async Task CrearConversionAsync(Conversion conversion)
    {
        try
        {
            var conversionEntity = _mapper.Map<Conversion>(conversion);
            await _contextoBBDD.Conversion.AddAsync(conversionEntity);
            await _contextoBBDD.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear conversión.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene todas las conversiones de la base de datos.
    /// </summary>
    /// <returns>Lista de todas las conversiones.</returns>
    public async Task<List<Conversion>> GetConversionesAsync()
    {
        try
        {
            return await _contextoBBDD.Conversion
                .Include(c => c.Cliente)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las conversiones.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene una conversión por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la conversión.</param>
    /// <returns>La conversión con el identificador especificado.</returns>
    public async Task<Conversion> GetConversionByIdAsync(int id)
    {
        try
        {
            return await _contextoBBDD.Conversion
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(c => c.ConversionId == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener conversión por ID.");
            throw;
        }
    }

    #endregion

    #region Métodos de Transacción

    /// <summary>
    /// Crea una nueva transacción en la base de datos.
    /// </summary>
    /// <param name="transaccion">La transacción a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    public async Task CrearTransaccionAsync(Transaccion transaccion)
    {
        try
        {
            var clienteOrigen = await _contextoBBDD.Clientes.FindAsync(transaccion.ClienteOrigenId);
            var clienteDestino = await _contextoBBDD.Clientes.FindAsync(transaccion.ClienteDestinoId);

            if (clienteOrigen != null && clienteDestino != null)
            {
                var transaccionEntity = _mapper.Map<Transaccion>(transaccion);

                clienteOrigen.TransaccionesDestino.Add(transaccionEntity);
                clienteDestino.TransaccionesOrigen.Add(transaccionEntity);
                await _contextoBBDD.Transacciones.AddAsync(transaccionEntity);
                await _contextoBBDD.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear transacción.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene todas las transacciones de la base de datos.
    /// </summary>
    /// <returns>Lista de todas las transacciones.</returns>
    public async Task<List<Transaccion>> GetTransaccionesAsync()
    {
        try
        {
            return await _contextoBBDD.Transacciones
                .Include(t => t.ClienteOrigen)
                    .ThenInclude(co => co.Pais)
                .Include(t => t.ClienteDestino)
                    .ThenInclude(cd => cd.Pais)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las transacciones.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene una transacción por su identificador.
    /// </summary>
    /// <param name="id">El identificador de la transacción.</param>
    /// <returns>La transacción con el identificador especificado.</returns>
    public async Task<Transaccion> GetTransaccionByIdAsync(int id)
    {
        try
        {
            return await _contextoBBDD.Transacciones
                .Include(t => t.ClienteOrigen)
                .Include(t => t.ClienteDestino)
                .FirstOrDefaultAsync(t => t.TransaccionId == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener transacción por ID.");
            throw;
        }
    }

    #endregion

    #region Métodos de Outlier

    /// <summary>
    /// Detecta los outliers en las transacciones de los clientes.
    /// </summary>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    public async Task DetectarOutliersAsync()
    {
        try
        {
            var transaccionesByCliente = await _contextoBBDD.Transacciones
                .Include(t => t.ClienteOrigen)
                .Where(t => t.ImporteEnviado.HasValue)
                .GroupBy(t => t.ClienteOrigenId)
                .ToListAsync();

            foreach (var group in transaccionesByCliente)
            {
                var amounts = group.Select(t => t.ImporteEnviado.Value).OrderBy(a => a).ToList();

                if (amounts.Count < 10)
                    continue;

                double q1 = GetQuantile(amounts, 0.25);
                double q3 = GetQuantile(amounts, 0.75);
                double iqr = q3 - q1;

                double upperBound = q3 + 3 * iqr;

                foreach (var transaccion in group)
                {
                    transaccion.IsOutlier = transaccion.ImporteEnviado > upperBound;
                }
            }

            await _contextoBBDD.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al detectar outliers.");
            throw;
        }
    }

    /// <summary>
    /// Calcula el cuantil de una lista de valores ordenados.
    /// </summary>
    /// <param name="sortedValues">Lista de valores ordenados.</param>
    /// <param name="percentile">El percentil a calcular.</param>
    /// <returns>El valor del cuantil calculado.</returns>
    private double GetQuantile(List<double> sortedValues, double percentile)
    {
        int N = sortedValues.Count;
        double index = percentile * (N - 1);
        int lowerIndex = (int)Math.Floor(index);
        int upperIndex = (int)Math.Ceiling(index);

        if (lowerIndex == upperIndex)
            return sortedValues[lowerIndex];
        return sortedValues[lowerIndex] * (1 - (index - lowerIndex)) + sortedValues[upperIndex] * (index - lowerIndex);
    }

    /// <summary>
    /// Elimina el estado de outlier de una transacción.
    /// </summary>
    /// <param name="transaccionId">El identificador de la transacción.</param>
    /// <returns>Valor booleano que indica si se eliminó el outlier.</returns>
    public async Task<bool> EliminarOutlierAsync(int transaccionId)
    {
        try
        {
            var transaccion = await _contextoBBDD.Transacciones
                .FirstOrDefaultAsync(t => t.TransaccionId == transaccionId);

            if (transaccion == null || !(transaccion.IsOutlier ?? false))
            {
                return false;
            }

            transaccion.IsOutlier = false;
            transaccion.IsOutlierVisto = true;
            await _contextoBBDD.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar outlier.");
            return false;
        }
    }

    #endregion

    #region Métodos de País

    /// <summary>
    /// Crea un nuevo país en la base de datos.
    /// </summary>
    /// <param name="pais">El país a crear.</param>
    /// <returns>Tarea que representa la operación asincrónica.</returns>
    public async Task CrearPaisAsync(Pais pais)
    {
        try
        {
            var paisEntity = _mapper.Map<Pais>(pais);
            await _contextoBBDD.Paises.AddAsync(paisEntity);
            await _contextoBBDD.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear país.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene todos los países de la base de datos.
    /// </summary>
    /// <returns>Lista de todos los países.</returns>
    public async Task<List<Pais>> GetPaisesAsync()
    {
        try
        {
            return await _contextoBBDD.Paises.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los países.");
            throw;
        }
    }

    /// <summary>
    /// Obtiene un país por su identificador.
    /// </summary>
    /// <param name="id">El identificador del país.</param>
    /// <returns>El país con el identificador especificado.</returns>
    public async Task<Pais> GetPaisByIdAsync(int id)
    {
        try
        {
            return await _contextoBBDD.Paises
                .Include(p => p.Clientes)
                .FirstOrDefaultAsync(p => p.PaisId == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener país por ID.");
            throw;
        }
    }

    #endregion
}
