
using Microsoft.AspNetCore.Authorization;

namespace ApiBasesDeDatosProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisRepository _paisRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PaisesController> _logger;

        public PaisesController(IPaisRepository paisRepository, IMapper mapper, ILogger<PaisesController> logger)
        {
            _paisRepository = paisRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/paises
        [HttpGet]
        public async Task<ActionResult<List<PaisDto>>> Get()
        {
            _logger.LogInformation("Obteniendo todos los países.");
            List<Pais> lista = await _paisRepository.ObtenerTodos();
            _logger.LogInformation($"Se obtuvieron {lista.Count} países.");
            return Ok(_mapper.Map<List<PaisDto>>(lista));
        }

        // GET api/paises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            _logger.LogInformation($"Obteniendo país con id {id}.");
            var pais = await _paisRepository.ObtenerPorId(id);
            if (pais == null)
            {
                _logger.LogWarning($"No se ha encontrado el país con id {id}.");
                return NotFound();
            }

            _logger.LogInformation($"Obtenido país con id {id}.");
            return Ok(_mapper.Map<PaisDto>(pais));
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> ObtenerPorNombre(string nombre)
        {
            var pais = await _paisRepository.ObtenerPorNombre(nombre);
            if (pais == null)
            {
                return NotFound();
            }
            return Ok(new { Id = pais.Id });
        }


        // POST api/paises
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PaisDto paisDto)
        {
            _logger.LogInformation("Creando un nuevo país.");
            //string cadena = new string('A', 5000);
            //paisDto.Nombre += cadena;
            if (paisDto == null)
            {
                _logger.LogWarning("El objeto PaisDto recibido es nulo.");
                return BadRequest("El objeto PaisDto no puede ser nulo.");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("El modelo PaisDto no es válido.");
                return BadRequest(ModelState);
            }

            var pais = _mapper.Map<Pais>(paisDto);
            _paisRepository.Agregar(pais);

            if (await _paisRepository.GuardarCambios())
            {
                _logger.LogInformation($"País con ID {pais.Id} creado correctamente.");
                return CreatedAtAction(nameof(Get), new { id = pais.Id }, paisDto);
            }

            _logger.LogError("No se pudo agregar el país.");
            return BadRequest("No se pudo agregar el país.");
        }

        // PUT api/paises/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PaisDto paisDto)
        {
            _logger.LogInformation($"Actualizando país con ID {id}.");
            if (id != paisDto.PaisId)
            {
                _logger.LogWarning($"ID del país en la solicitud ({paisDto.PaisId}) no coincide con el ID de la URL ({id}).");
                return BadRequest("ID del país no coincide.");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("El modelo PaisDto no es válido.");
                return BadRequest(ModelState);
            }

            var pais = _mapper.Map<Pais>(paisDto);
            _paisRepository.Actualizar(pais);

            if (await _paisRepository.GuardarCambios())
            {
                _logger.LogInformation($"País con ID {id} actualizado correctamente.");
                return NoContent();
            }

            _logger.LogError("No se pudo actualizar el país.");
            return BadRequest("No se pudo actualizar el país.");
        }

        // DELETE api/paises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation($"Eliminando país con ID {id}.");
            var pais = await _paisRepository.ObtenerPorId(id);
            if (pais == null)
            {
                _logger.LogWarning($"País con ID {id} no encontrado.");
                return NotFound();
            }

            _paisRepository.Eliminar(pais);

            if (await _paisRepository.GuardarCambios())
            {
                _logger.LogInformation($"País con ID {id} eliminado correctamente.");
                return NoContent();
            }

            _logger.LogError($"Error al eliminar el país con ID {id}.");
            return BadRequest("No se pudo eliminar el país.");
        }
    }
}
