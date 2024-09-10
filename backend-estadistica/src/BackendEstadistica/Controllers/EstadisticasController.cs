namespace BackendEstadistica.Controllers;

/// <summary>
/// Controlador para gestionar las operaciones relacionadas con estadísticas, clientes, transacciones, outliers, divisas y conversiones.
/// </summary>
[Route("api/estadisticas")]
[ApiController]
public class EstadisticasController : ControllerBase
{
    private readonly ContextoBBDD _contextoBBDD;
    private readonly IEstadisticasRepositorio _estadisticasRepositorio;
    private readonly IMapper _mapper;
    private readonly IHubContext<NotificationHub> _hubContext;

    /// <summary>
    /// Inicializa una nueva instancia del controlador <see cref="EstadisticasController"/>.
    /// </summary>
    /// <param name="contextoBBDD">El contexto de la base de datos.</param>
    /// <param name="estadisticasRepositorio">El repositorio para operaciones de estadísticas.</param>
    /// <param name="mapper">El servicio de mapeo de objetos.</param>
    /// <param name="hubContext">El contexto del hub de SignalR para notificaciones.</param>
    public EstadisticasController(
        ContextoBBDD contextoBBDD,
        IEstadisticasRepositorio estadisticasRepositorio,
        IMapper mapper,
        IHubContext<NotificationHub> hubContext)
    {
        _contextoBBDD = contextoBBDD;
        _estadisticasRepositorio = estadisticasRepositorio;
        _mapper = mapper;
        _hubContext = hubContext;
    }

    #region CLIENTES

    /// <summary>
    /// Crea un nuevo cliente con datos generados automáticamente.
    /// </summary>
    /// <returns>Una respuesta HTTP indicando el éxito de la operación.</returns>
    [HttpPost("crearCliente")]
    public async Task<IActionResult> CrearCliente()
    {
        var paises = await _estadisticasRepositorio.GetPaisesAsync(); // Obtener todos los países existentes
        var clienteFaker = new ClienteFaker(paises);
        var clienteDto = clienteFaker.Generate();

        var nuevoCliente = _mapper.Map<Cliente>(clienteDto);
        await _estadisticasRepositorio.CrearClienteAsync(nuevoCliente);

        return Ok("Cliente creado correctamente");
    }

    /// <summary>
    /// Obtiene todos los clientes existentes.
    /// </summary>
    /// <returns>Una respuesta HTTP con la lista de clientes.</returns>
    [HttpGet("getClientes")]
    public async Task<IActionResult> GetClientes()
    {
        var clientes = await _estadisticasRepositorio.GetClientesAsync();
        return Ok(_mapper.Map<List<Cliente>>(clientes));
    }

    /// <summary>
    /// Obtiene un cliente por su ID.
    /// </summary>
    /// <param name="id">El ID del cliente a buscar.</param>
    /// <returns>Una respuesta HTTP con el cliente encontrado o un mensaje de no encontrado.</returns>
    [HttpGet("getCliente/{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        var cliente = await _estadisticasRepositorio.GetClienteByIdAsync(id);

        if (cliente == null)
        {
            return NotFound("Cliente no encontrado.");
        }

        return Ok(_mapper.Map<Cliente>(cliente));
    }

    #endregion

    #region TRANSACCIONES

    /// <summary>
    /// Crea una nueva transacción con datos generados automáticamente y notifica si se detecta un outlier.
    /// </summary>
    /// <returns>Una respuesta HTTP indicando el éxito de la operación o la detección de un outlier.</returns>
    [HttpPost("crearTransaccion")]
    public async Task<IActionResult> CrearTransaccion()
    {
        var clienteOrigen = await _estadisticasRepositorio.GetRandomClientAsync();
        var clienteDestino = await _estadisticasRepositorio.GetRandomClientAsync();

        var transaccionFaker = new TransaccionFaker(clienteOrigen, clienteDestino);
        var transaccionDto = transaccionFaker.Generate();

        var nuevaTransaccion = _mapper.Map<Transaccion>(transaccionDto);
        await _estadisticasRepositorio.CrearTransaccionAsync(nuevaTransaccion);

        var transaccion = await _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen)
            .FirstOrDefaultAsync(t => t.TransaccionId == nuevaTransaccion.TransaccionId);

        if (transaccion == null)
        {
            return BadRequest();
        }

        if (transaccion != null && transaccion.IsOutlier == true)
        {
            await _hubContext.Clients.All.SendAsync("OutlierDetected", new
            {
                Message = "Outlier detectado",
                Cliente = transaccion.ClienteOrigen.Nombre,
                ImporteEnviado = transaccion.ImporteEnviado
            });

            return Ok(new
            {
                Message = "Outlier detectado",
                Cliente = transaccion.ClienteOrigen.Nombre,
                ImporteEnviado = transaccion.ImporteEnviado
            });
        }

        return Ok("Transacción creada correctamente");
    }

    /// <summary>
    /// Obtiene todas las transacciones existentes.
    /// </summary>
    /// <returns>Una respuesta HTTP con la lista de transacciones.</returns>
    [HttpGet("getTransacciones")]
    public async Task<IActionResult> GetTransacciones()
    {
        var transacciones = await _estadisticasRepositorio.GetTransaccionesAsync();
        return Ok(_mapper.Map<List<Transaccion>>(transacciones));
    }

    /// <summary>
    /// Obtiene una transacción por su ID.
    /// </summary>
    /// <param name="id">El ID de la transacción a buscar.</param>
    /// <returns>Una respuesta HTTP con la transacción encontrada o un mensaje de no encontrada.</returns>
    [HttpGet("getTransacciones/{id}")]
    public async Task<IActionResult> GetTransaccionesById(int id)
    {
        var transaccion = await _estadisticasRepositorio.GetTransaccionByIdAsync(id);

        if (transaccion == null)
        {
            return NotFound("Transacción no encontrada.");
        }

        return Ok(_mapper.Map<Transaccion>(transaccion));
    }

    #endregion

    #region OUTLIERS

    /// <summary>
    /// Crea una transacción con datos generados automáticamente y detecta si es un outlier.
    /// </summary>
    /// <returns>Una respuesta HTTP indicando el éxito de la operación o la detección de un outlier.</returns>
    [HttpPost("crearOutlier")]
    public async Task<IActionResult> CrearOutliersAsync()
    {
        var clienteOrigen = await _estadisticasRepositorio.GetRandomClientAsync();
        var clienteDestino = await _estadisticasRepositorio.GetRandomClientAsync();

        var outliersFaker = new OutliersFaker(clienteOrigen, clienteDestino);
        var transaccionDto = outliersFaker.Generate();

        var nuevaTransaccion = _mapper.Map<Transaccion>(transaccionDto);
        await _estadisticasRepositorio.CrearTransaccionAsync(nuevaTransaccion);

        await _estadisticasRepositorio.DetectarOutliersAsync();

        var transaccion = await _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen)
            .FirstOrDefaultAsync(t => t.TransaccionId == nuevaTransaccion.TransaccionId);

        if (transaccion != null && transaccion.IsOutlier == true)
        {
            await _hubContext.Clients.All.SendAsync("OutlierDetected", new
            {
                Message = "Outlier detectado",
                Cliente = transaccion.ClienteOrigen.Nombre,
                ImporteEnviado = transaccion.ImporteEnviado
            });

            return Ok(new
            {
                Message = "Outlier detectado",
                Cliente = transaccion.ClienteOrigen.Nombre,
                ImporteEnviado = transaccion.ImporteEnviado
            });
        }

        return Ok("Transacción creada correctamente");
    }

    /// <summary>
    /// Obtiene todas las transacciones que se han marcado como outliers.
    /// </summary>
    /// <returns>Una respuesta HTTP con la lista de transacciones outliers.</returns>
    [HttpGet("getOutliers")]
    public async Task<IActionResult> ObtenerTransaccionesOutliers()
    {
        var transaccionesOutliers = await _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen)
                .ThenInclude(co => co.Pais)
            .Include(t => t.ClienteDestino)
                .ThenInclude(cd => cd.Pais)
            .Where(t => t.IsOutlier == true)
            .ToListAsync();

        return Ok(transaccionesOutliers);
    }

    /// <summary>
    /// Obtiene todas las transacciones que han sido vistas y marcadas como outliers.
    /// </summary>
    /// <returns>Una respuesta HTTP con la lista de outliers vistos.</returns>
    [HttpGet("outliers-vistos")]
    public async Task<IActionResult> ObtenerOutliersVistos()
    {
        var outliersVistos = await _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen)
                .ThenInclude(co => co.Pais)
            .Include(t => t.ClienteDestino)
                .ThenInclude(cd => cd.Pais)
            .Where(t => t.IsOutlierVisto == true)
            .ToListAsync();

        return Ok(outliersVistos);
    }

    /// <summary>
    /// Elimina un outlier por ID y notifica la eliminación a través de SignalR.
    /// </summary>
    /// <param name="idTransaccion">El ID de la transacción a eliminar.</param>
    /// <returns>Una respuesta HTTP indicando el éxito de la operación.</returns>
    [HttpPut("resolucionOutlier/{idTransaccion}")]
    public async Task<IActionResult> EliminarOutlier([FromRoute] int idTransaccion)
    {
        // Eliminar el outlier usando el repositorio
        var resultado = await _estadisticasRepositorio.EliminarOutlierAsync(idTransaccion);

        if (!resultado)
        {
            return BadRequest("No se pudo eliminar el outlier.");
        }

        // Enviar notificación a través de SignalR
        await _hubContext.Clients.All.SendAsync("OutlierRemoved", new
        {
            Message = "Outlier eliminado",
            IDCliente = idTransaccion
        });

        // Responder con un mensaje de éxito
        return Ok(new
        {
            Message = "El outlier se eliminó con éxito.",
            IDCliente = idTransaccion
        });
    }

    /// <summary>
    /// Obtiene las últimas cinco transacciones de un cliente ordenadas por importe enviado de mayor a menor.
    /// </summary>
    /// <param name="clienteId">El ID del cliente cuyas transacciones se desean obtener.</param>
    /// <returns>Una respuesta HTTP con la lista de las últimas transacciones del cliente.</returns>
    [HttpGet("ultimas-transacciones/{clienteId}")]
    public async Task<IActionResult> ObtenerUltimasTransacciones(int clienteId)
    {
        var transaccionesMayores = await _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen)
                .ThenInclude(co => co.Pais)
            .Include(t => t.ClienteDestino)
                .ThenInclude(cd => cd.Pais)
            .Where(t => t.ClienteOrigenId == clienteId)
            .OrderByDescending(t => t.ImporteEnviado)
            .Take(5)
            .ToListAsync();

        return Ok(transaccionesMayores);
    }

    #endregion

    #region DIVISAS

    /// <summary>
    /// Crea nuevas divisas con datos generados automáticamente.
    /// </summary>
    /// <returns>Una respuesta HTTP indicando el éxito de la operación.</returns>
    [HttpPost("crearDivisas")]
    public async Task<IActionResult> CrearDivisas()
    {
        // Lista de nombres de divisas
        var divisas = new List<string>
        {
            "AFN", "ALL", "EUR", "AOA", "XCD", "SAR", "DZD", "ARS", "AMD", "AUD", "AZN", "BSD", "BHD",
            "BDT", "BBD", "BZD", "XOF", "BYN", "MMK", "BOB", "BAM", "BWP", "BRL", "BND", "BGN", "BIF",
            "INR", "CVE", "KHR", "XAF", "CAD", "QAR", "CLP", "CNY", "COP", "KMF", "KPW", "KRW", "CRC",
            "HRK", "CUP", "CZK", "DKK", "EGP", "USD", "AED", "ERN", "GBP", "SZL", "GTQ", "GNF", "GYD",
            "HTG", "HNL", "HUF", "IDR", "IRR", "IQD", "ISK", "JMD", "JPY", "JOD", "KZT", "KES", "KGS",
            "KWD", "LAK", "LVL", "LBP", "LRD", "LYD", "CHF", "MGA", "MYR", "MWK", "MVR", "MDL", "MNT",
            "MAD", "MUR", "MRU", "MXN", "NAD", "NPR", "NIO", "NGN", "NOK", "NZD", "OMR", "PKR", "PAB",
            "PGK", "PYG", "PEN", "PLN", "RON", "RUB", "RSD", "SCR", "SLL", "SGD", "SYP", "SOS", "LKR",
            "SDG", "SEK", "STN", "RWF"
        };

        var fecha = DateTime.Now;

        foreach (var divisa in divisas)
        {
            var divisaFaker = new DivisaFaker(divisa, fecha);
            var divisaDto = divisaFaker.Generate();
            var nuevaDivisa = _mapper.Map<Divisa>(divisaDto);
            await _estadisticasRepositorio.CrearDivisaAsync(nuevaDivisa);
        }

        return Ok("Divisa creada correctamente");
    }

    /// <summary>
    /// Obtiene una divisa por su nombre.
    /// </summary>
    /// <param name="nombre">El nombre de la divisa a buscar.</param>
    /// <returns>Una respuesta HTTP con la divisa encontrada.</returns>
    [HttpGet("getDivisa/{nombre}")]
    public async Task<IActionResult> GetDivisaByName(string nombre)
    {
        var divisaNombre = await _estadisticasRepositorio.GetDivisaByNameAsync(nombre);
        return Ok(_mapper.Map<List<Divisa>>(divisaNombre));
    }

    /// <summary>
    /// Obtiene todas las divisas existentes.
    /// </summary>
    /// <returns>Una respuesta HTTP con la lista de divisas.</returns>
    [HttpGet("getDivisas")]
    public async Task<IActionResult> GetDivisas()
    {
        var divisas = await _estadisticasRepositorio.GetDivisasAsync();
        return Ok(_mapper.Map<List<Divisa>>(divisas));
    }

    #endregion

    #region CONVERSIONES

    /// <summary>
    /// Crea una nueva conversión con datos generados automáticamente.
    /// </summary>
    /// <returns>Una respuesta HTTP indicando el éxito de la operación.</returns>
    [HttpPost("crearConversion")]
    public async Task<IActionResult> CrearConversion()
    {
        var cliente = await _estadisticasRepositorio.GetRandomClientAsync();
        var conversionFaker = new ConversionFaker(cliente);
        var conversionDto = conversionFaker.Generate();

        var nuevaConversion = _mapper.Map<Conversion>(conversionDto);
        await _estadisticasRepositorio.CrearConversionAsync(nuevaConversion);

        return Ok("Conversión creada correctamente");
    }

    /// <summary>
    /// Obtiene todas las conversiones existentes.
    /// </summary>
    /// <returns>Una respuesta HTTP con la lista de conversiones.</returns>
    [HttpGet("getConversiones")]
    public async Task<IActionResult> GetConversiones()
    {
        var conversiones = await _estadisticasRepositorio.GetConversionesAsync();
        return Ok(_mapper.Map<List<Conversion>>(conversiones));
    }

    /// <summary>
    /// Obtiene una conversión por su ID.
    /// </summary>
    /// <param name="id">El ID de la conversión a buscar.</param>
    /// <returns>Una respuesta HTTP con la conversión encontrada o un mensaje de no encontrada.</returns>
    [HttpGet("getConversion/{id}")]
    public async Task<IActionResult> GetConversionById(int id)
    {
        var conversion = await _estadisticasRepositorio.GetConversionByIdAsync(id);

        if (conversion == null)
        {
            return NotFound("Conversión no encontrada.");
        }

        return Ok(_mapper.Map<Conversion>(conversion));
    }

    #endregion

    #region PAISES

    /// <summary>
    /// Obtiene todos los países existentes.
    /// </summary>
    /// <returns>Una respuesta HTTP con la lista de países.</returns>
    [HttpGet("getPaises")]
    public async Task<IActionResult> GetPaises()
    {
        var paises = await _estadisticasRepositorio.GetPaisesAsync();
        return Ok(_mapper.Map<List<Pais>>(paises));
    }

    /// <summary>
    /// Obtiene un país por su ID.
    /// </summary>
    /// <param name="id">El ID del país a buscar.</param>
    /// <returns>Una respuesta HTTP con el país encontrado o un mensaje de no encontrado.</returns>
    [HttpGet("getPaises/{id}")]
    public async Task<IActionResult> GetPaisById(int id)
    {
        var pais = await _estadisticasRepositorio.GetPaisByIdAsync(id);

        if (pais == null)
        {
            return NotFound("País no encontrado.");
        }
        return Ok(_mapper.Map<Pais>(pais));
    }

    #endregion
}
