namespace BackendEstadistica.Controllers;

[Route("api/estadisticas")]
[ApiController]
public class EstadisticasController : Controller
{
    private readonly ContextoBBDD contextoBBDD;
    private readonly IEstadisticasRepositorio estadisticasRepositorio;
    private readonly IMapper mapper;

    public EstadisticasController(IEstadisticasRepositorio estadisticasRepositorio, IMapper mapper)
    {
        this.estadisticasRepositorio = estadisticasRepositorio;
        this.mapper = mapper;
    }

    //Clientes
    [HttpPost("crearCliente")]
    public IActionResult CrearCliente()
    {
        var paises = estadisticasRepositorio.GetPaises(); // Obtener todos los países existentes
        var clienteFaker = new ClienteFaker(paises);
        var clienteDto = clienteFaker.Generate();

        var nuevoCliente = this.mapper.Map<Cliente>(clienteDto);
        this.estadisticasRepositorio.CrearCliente(nuevoCliente);

        return Ok("Cliente creado correctamente");
    }

    [HttpGet("getClientes")]
    public IActionResult GetClientes()
    {
        // Obtén los clientes con detalles completos
        List<Cliente> clientes = estadisticasRepositorio.GetClientes();

        // Mapea a DTOs si es necesario, o devuelve las entidades directamente
        return Ok(mapper.Map<List<Cliente>>(clientes));
    }

    [HttpGet("getCliente/{id}")]
    public IActionResult GetClienteById(int id)
    {
        // Obtén el cliente por ID con detalles completos
        var cliente = estadisticasRepositorio.GetClienteById(id);

        // Verifica si el cliente existe
        if (cliente == null)
        {
            return NotFound("Cliente no encontrado.");
        }

        // Mapea a DTOs si es necesario, o devuelve la entidad directamente
        return Ok(mapper.Map<Cliente>(cliente));
    }

    //Transacciones
    [HttpPost("crearTransaccion")]
    public IActionResult CrearTransaccion()
    {
        var clientes = estadisticasRepositorio.GetClientes();
        var transaccionFaker = new TransaccionFaker(clientes);
        var transaccionDto = transaccionFaker.Generate();

        var nuevaTransaccion = this.mapper.Map<Transaccion>(transaccionDto);
        this.estadisticasRepositorio.CrearTransaccion(nuevaTransaccion);

        return Ok("Transacción creada correctamente");
    }

    [HttpGet("getTransacciones")]
    public IActionResult GetTransacciones()
    {

        List<Transaccion> transacciones = estadisticasRepositorio.GetTransacciones();

        return Ok(mapper.Map<List<Transaccion>>(transacciones));

    }

    [HttpGet("getTransacciones/{id}")]
    public IActionResult GetTransaccionesById(int id)
    {

        Transaccion transaccionId = estadisticasRepositorio.GetTransaccionById(id);

        return Ok(mapper.Map<Transaccion>(transaccionId));

    }

    //Divisas
    [HttpPost("crearDivisas")]
    public IActionResult CrearDivisas()
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
        foreach (var divisa in divisas) {
            var divisaFaker = new DivisaFaker(divisa, DateTime.Now);
            var divisaDto = divisaFaker.Generate();
            var nuevaDivisa = this.mapper.Map<Divisa>(divisaDto);
            this.estadisticasRepositorio.CrearDivisa(nuevaDivisa); }

        return Ok("Divisa creada correctamente");
    }
    [HttpGet("getDivisa/{id}")]
    public IActionResult GetDivisaById(int id)
    {

        Divisa divisaId = estadisticasRepositorio.GetDivisaById(id);

        return Ok(mapper.Map<Cliente>(divisaId));

    }

    [HttpGet("getDivisas")]
    public IActionResult GetDivisas()
    {
        List<Divisa> divisas = estadisticasRepositorio.GetDivisa();

        return Ok(mapper.Map<List<Divisa>>(divisas));

    }


    //Conversiones
    [HttpPost("crearConversion")]
    public IActionResult CrearConversion()
    {
        var clientes = estadisticasRepositorio.GetClientes();
        var conversionFaker = new ConversionFaker(clientes);
        var conversionDto = conversionFaker.Generate();

        var nuevaConversion = this.mapper.Map<Conversion>(conversionDto);
        this.estadisticasRepositorio.CrearConversion(nuevaConversion);

        return Ok("Conversión creada correctamente");
    }

    [HttpGet("getConversion")]
    public IActionResult GetConversiones()
    {

        List<Conversion> conversiones = estadisticasRepositorio.GetConversiones();

        return Ok(mapper.Map<List<Conversion>>(conversiones));

    }

    [HttpGet("getConversion/{id}")]
    public IActionResult GetConversionById(int id)
    {

        Conversion conversionId = estadisticasRepositorio.GetConversionById(id);

        return Ok(mapper.Map<Cliente>(conversionId));

    }

    ////Paises
    //[HttpPost("crearPais")]
    //public IActionResult CrearPais()
    //{
    //    var paisFaker = new PaisFaker();
    //    var paisDto = paisFaker.Generate();

    //    var nuevoPais = this.mapper.Map<Pais>(paisDto);
    //    this.estadisticasRepositorio.CrearPais(nuevoPais);

    //    return Ok("País creado correctamente");
    //}

    [HttpGet("getPaises")]
    public IActionResult GetPaises()
    {
        List<Pais> paises = estadisticasRepositorio.GetPaises();
        return Ok(mapper.Map<List<Pais>>(paises));
    }

    [HttpGet("getPaises/{id}")]
    public IActionResult GetPaisById(int id)
    {
        Pais paisId = estadisticasRepositorio.GetPaisById(id);

        return Ok(mapper.Map<Pais>(paisId));
    }
}
