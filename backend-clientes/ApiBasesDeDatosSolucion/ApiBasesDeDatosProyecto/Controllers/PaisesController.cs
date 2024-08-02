
namespace ApiBasesDeDatosProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisRepository _paisRepository;
        private readonly IMapper _mapper;

        public PaisesController(IPaisRepository paisRepository, IMapper mapper)
        {
            _paisRepository = paisRepository;
            _mapper = mapper;
        }

        // GET: api/paises
        [HttpGet]
        public async Task<ActionResult<List<PaisDto>>> Get()
        {
            List<Pais> lista = await _paisRepository.ObtenerTodos();
            return Ok(_mapper.Map<List<PaisDto>>(lista));
        }

        // GET api/paises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var pais = await _paisRepository.ObtenerPorId(id);
            if (pais == null)
            {
                return NotFound();
            }
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
            return Ok(pais.Id);
        }


        // POST api/paises
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PaisDto paisDto)
        {
            //string cadena = new string('A', 5000);
            //paisDto.Nombre += cadena;
            if (paisDto == null)
            {
                return BadRequest("El objeto PaisDto no puede ser nulo.");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pais = _mapper.Map<Pais>(paisDto);
            _paisRepository.Agregar(pais);

            if (await _paisRepository.GuardarCambios())
            {
                return CreatedAtAction(nameof(Get), new { id = pais.Id }, paisDto);
            }

            return BadRequest("No se pudo agregar el país.");
        }

        // PUT api/paises/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PaisDto paisDto)
        {
            if (id != paisDto.PaisId)
            {
                return BadRequest("ID del país no coincide.");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pais = _mapper.Map<Pais>(paisDto);
            _paisRepository.Actualizar(pais);

            if (await _paisRepository.GuardarCambios())
            {
                return NoContent();
            }

            return BadRequest("No se pudo actualizar el país.");
        }

        // DELETE api/paises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pais = await _paisRepository.ObtenerPorId(id);
            if (pais == null)
            {
                return NotFound();
            }

            _paisRepository.Eliminar(pais);

            if (await _paisRepository.GuardarCambios())
            {
                return NoContent();
            }

            return BadRequest("No se pudo eliminar el país.");
        }
    }
}
