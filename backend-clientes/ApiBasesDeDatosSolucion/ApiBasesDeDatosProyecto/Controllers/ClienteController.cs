using ApiBasesDeDatosProyecto.Models;
using Microsoft.Extensions.Logging;

namespace ApiBasesDeDatosProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPaisRepository _paisRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(
            IClienteRepository clienteRepository,
            IMapper mapper,
            IPaisRepository paisRepository,
            ILogger<ClienteController> logger)
        {
            _clienteRepository = clienteRepository;
            _paisRepository = paisRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> Get()
        {
            _logger.LogInformation($"Obteniendo todos los clientes.");
            List<Cliente> lista = await _clienteRepository.ObtenerTodos();
            _logger.LogInformation($"Se obtuvieron {lista.Count} clientes.");
            return Ok(_mapper.Map<List<ClienteDto>>(lista));
        }

        // GET api/cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            _logger.LogInformation($"Obteniendo cliente con ID {id}.");
            var cliente = await _clienteRepository.ObtenerPorId(id);
            if (cliente == null)
            {
                _logger.LogWarning($"Cliente con ID {id} no encontrado.");
                return NotFound();
            }
            return Ok(_mapper.Map<ClienteDto>(cliente));
        }

        // GET api/cliente/paisNombre/{nombre}
        [HttpGet("paisNombre/{nombre}")]
        public async Task<ActionResult<List<ClienteDto>>> GetClientesPorNombrePais(string nombre)
        {
            _logger.LogInformation($"Obteniendo clientes para el país con nombre {nombre}.");
            var pais = await _paisRepository.ObtenerPorNombre(nombre);
            if (pais == null)
            {
                _logger.LogWarning($"País con nombre {nombre} no encontrado.");
                return NotFound();
            }

            var clientes = await _clienteRepository.ObtenerClientesPorPaisId(pais.Id);
            if (clientes == null || clientes.Count == 0)
            {
                _logger.LogWarning($"No se encontraron clientes para el país con nombre {nombre}.");
                return NotFound();
            }

            return Ok(_mapper.Map<List<ClienteDto>>(clientes));
        }

        // POST api/cliente
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDto clienteDto)
        {
            _logger.LogInformation($"Creando un nuevo cliente.");
            if (clienteDto == null)
            {
                _logger.LogWarning($"El objeto ClienteDto recibido es nulo.");
                return BadRequest($"El objeto ClienteDto no puede ser nulo.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"El modelo ClienteDto no es válido. Errores: {ModelState}");
                return BadRequest(ModelState);
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);
            _clienteRepository.Agregar(cliente);

            if (await _clienteRepository.GuardarCambios())
            {
                _logger.LogInformation($"Cliente con ID {cliente.Id} creado correctamente.");
                return CreatedAtAction(nameof(Get), new { id = cliente.Id }, clienteDto);
            }

            _logger.LogError($"No se pudo agregar el cliente.");
            return BadRequest($"No se pudo agregar el cliente.");
        }

        // PUT api/cliente/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDto clienteDto)
        {
            _logger.LogInformation($"Actualizando cliente con ID {id}.");
            if (id != clienteDto.ClienteId)
            {
                _logger.LogWarning($"ID del cliente en la solicitud ({clienteDto.ClienteId}) no coincide con el ID de la URL ({id}).");
                return BadRequest("ID del cliente no coincide.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"El modelo ClienteDto no es válido. Errores: {ModelState}");
                return BadRequest(ModelState);
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);
            _clienteRepository.Actualizar(cliente);

            if (await _clienteRepository.GuardarCambios())
            {
                _logger.LogInformation($"Cliente con ID {id} actualizado correctamente.");
                return NoContent();
            }

            _logger.LogError($"No se pudo actualizar el cliente con ID {id}.");
            return BadRequest($"No se pudo actualizar el cliente.");
        }

        // DELETE api/cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation($"Eliminando cliente con ID {id}.");
            var cliente = await _clienteRepository.ObtenerPorId(id);
            if (cliente == null)
            {
                _logger.LogWarning($"Cliente con ID {id} no encontrado para eliminar.");
                return NotFound();
            }

            _clienteRepository.Eliminar(cliente);

            if (await _clienteRepository.GuardarCambios())
            {
                _logger.LogInformation($"Cliente con ID {id} eliminado correctamente.");
                return NoContent();
            }

            _logger.LogError($"No se pudo eliminar el cliente con ID {id}.");
            return BadRequest($"No se pudo eliminar el cliente.");
        }
    }
}
