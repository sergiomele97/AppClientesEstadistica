
using BackendEstadistica.Servicios;
using Microsoft.AspNetCore.Mvc;

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
        var clienteFaker = new ClienteFaker();
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
        var transaccionFaker = new TransaccionFaker();
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



    //Conversiones
    [HttpPost("crearConversion")]
    public IActionResult CrearConversion()
    {
        var conversionFaker = new ConversionFaker();
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


    //Paises
    [HttpPost("crearPais")]
    public IActionResult CrearPais()
    {
        var paisFaker = new PaisFaker();
        var paisDto = paisFaker.Generate();

        var nuevoPais = this.mapper.Map<Pais>(paisDto);
        this.estadisticasRepositorio.CrearPais(nuevoPais);

        return Ok("País creado correctamente");
    }

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
