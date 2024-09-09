using BackendEstadistica.SignalR;


namespace BackendEstadistica.Controllers
{
    [Route("api/estadisticas")]
    [ApiController]
    public class EstadisticasController : ControllerBase
    {
        private readonly ContextoBBDD _contextoBBDD;
        private readonly IEstadisticasRepositorio _estadisticasRepositorio;
        private readonly IMapper _mapper;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly DivisaRepositorio _divisaRepositorio;
        public EstadisticasController(
            ContextoBBDD contextoBBDD,
            IEstadisticasRepositorio estadisticasRepositorio,
            IMapper mapper,
            DivisaRepositorio divisaRepositorio,
            IHubContext<NotificationHub> hubContext)
        {
            _contextoBBDD = contextoBBDD;
            _estadisticasRepositorio = estadisticasRepositorio;
            _mapper = mapper;
            _hubContext = hubContext;
            _divisaRepositorio = divisaRepositorio;
        }

    // CLIENTES
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

    [HttpGet("getClientes")]
    public async Task<IActionResult> GetClientes()
    {
        var clientes = await _estadisticasRepositorio.GetClientesAsync();
        return Ok(_mapper.Map<List<Cliente>>(clientes));
    }

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

    // TRANSACCIONES
    [HttpPost("crearTransaccion")]
    public async Task<IActionResult> CrearTransaccion()
    {
        var clienteOrigen = await _estadisticasRepositorio.GetRandomClientAsync();
        var clienteDestino = await _estadisticasRepositorio.GetRandomClientAsync();

        var transaccionFaker = new TransaccionFaker(clienteOrigen, clienteDestino);
        var transaccionDto = transaccionFaker.Generate();

        var nuevaTransaccion = _mapper.Map<Transaccion>(transaccionDto);
        await _estadisticasRepositorio.CrearTransaccionAsync(nuevaTransaccion);

        //await _estadisticasRepositorio.DetectarOutliersAsync();

        var transaccion = await _contextoBBDD.Transacciones
            .Include(t => t.ClienteOrigen)
            .FirstOrDefaultAsync(t => t.TransaccionId == nuevaTransaccion.TransaccionId);

            if(transaccion == null)
            {
                return BadRequest();
            }

            //if (transaccion != null && transaccion.IsOutlier == true)
            //{

            //    await _hubContext.Clients.All.SendAsync("OutlierDetected", new
            //    {
            //        Message = "Outlier detectado",
            //        Cliente = transaccion.ClienteOrigen.Nombre,
            //        ImporteEnviado = transaccion.ImporteEnviado
            //    });

            //    return Ok(new
            //    {
            //        Message = "Outlier detectado",
            //        Cliente = transaccion.ClienteOrigen.Nombre,
            //        ImporteEnviado = transaccion.ImporteEnviado
            //    });
            //}

            return Ok("Transacción creada correctamente");
        }

    [HttpGet("getTransacciones")]
    public async Task<IActionResult> GetTransacciones()
    {
        var transacciones = await _estadisticasRepositorio.GetTransaccionesAsync();
        return Ok(_mapper.Map<List<Transaccion>>(transacciones));
    }

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

        // OUTLIERS
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

    // DIVISAS
    [HttpPost("crearDivisas")]
    public async Task<IActionResult> CrearDivisas()
        {
            try
            {
                await  _divisaRepositorio.PoblarMonedas();
               
                return Ok("Divisas creadas correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear divisas: {ex.Message}");
            }
        }

        [HttpGet("getDivisa/{nombre}")]
    public async Task<IActionResult> GetDivisaByName(string nombre)
    {
        var divisaNombre = await _estadisticasRepositorio.GetDivisaByNameAsync(nombre);
        return Ok(_mapper.Map<List<Divisa>>(divisaNombre));
    }

    [HttpGet("getDivisas")]
    public async Task<IActionResult> GetDivisas()
    {
        var divisas = await _estadisticasRepositorio.GetDivisasAsync();
        return Ok(_mapper.Map<List<Divisa>>(divisas));
    }

    // CONVERSIONES
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

    [HttpGet("getConversiones")]
    public async Task<IActionResult> GetConversiones()
    {
        var conversiones = await _estadisticasRepositorio.GetConversionesAsync();
        return Ok(_mapper.Map<List<Conversion>>(conversiones));
    }

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

    // PAISES
    [HttpGet("getPaises")]
    public async Task<IActionResult> GetPaises()
    {
        var paises = await _estadisticasRepositorio.GetPaisesAsync();
        return Ok(_mapper.Map<List<Pais>>(paises));
    }

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

     


    }
}
