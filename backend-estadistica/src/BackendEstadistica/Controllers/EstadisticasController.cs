using BackendEstadistica.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace BackendEstadistica.Controllers
{

    [Route("api/estadisticas")]
    [ApiController]
    public class EstadisticasController : Controller
    {
        
        private readonly IEstadisticasRepositorio estadisticasRepositorio;
        private readonly IMapper mapper;

        public EstadisticasController(IEstadisticasRepositorio estadisticasRepositorio, IMapper mapper)
        {
            this.estadisticasRepositorio = estadisticasRepositorio;
            this.mapper = mapper;
        }


        //Clientes

        [HttpPost("crearCliente")]
        public string CrearCliente(Cliente nuevoCliente)
        {

            estadisticasRepositorio.CrearCliente(nuevoCliente);

            return "Usuario creado correctamente";

        }

        [HttpGet("getClientes")]
        public IActionResult GetClientes() 
        {
        
            List<Cliente> clientes = estadisticasRepositorio.GetClientes();

            return Ok(mapper.Map<List<Cliente>>(clientes));

        }

        [HttpGet("getCliente/{id}")]
        public IActionResult GetClienteById(int id) 
        {
        
            Cliente clienteId = estadisticasRepositorio.GetClienteById(id);

            return Ok(mapper.Map<Cliente>(clienteId));
        
        }


        //Transacciones

        [HttpPost("crearTransaccion")]
        public string CrearTransaccion(Transaccion nuevaTransaccion)
        {

            estadisticasRepositorio.CrearTransaccion(nuevaTransaccion);

            return "Transaccion creada correctamente";

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
        public string CrearConversion(Conversion nuevaConversion)
        {

            estadisticasRepositorio.CrearConversion(nuevaConversion);

            return "Conversion creada correctamente";

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
        public string CrearConversion(Pais nuevoPais)
        {

            estadisticasRepositorio.CrearPais(nuevoPais);

            return "País creado correctamente";

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
}
