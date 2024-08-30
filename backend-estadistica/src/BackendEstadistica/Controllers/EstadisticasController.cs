using BackendEstadistica.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        var resultado = await _estadisticasRepositorio.EliminarOutlierAsync(idTransaccion);

        if (!resultado)
        {
            return NotFound("Transacción no encontrada o no es un outlier.");
        }

        return Ok("El outlier se eliminó con éxito.");
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
