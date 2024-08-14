using ApiBasesDeDatosProyecto.Helpers;

namespace ApiBasesDeDatosProyecto.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IPaisRepository _paisRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ClienteController> _logger;
    private readonly ClienteService _clienteService;
    private readonly Contexto _contexto;

    public ClienteController(
        IClienteRepository clienteRepository,
        IMapper mapper,
        IPaisRepository paisRepository,
        ILogger<ClienteController> logger,
        ClienteService clienteService,
        Contexto contexto)
    {
        _clienteRepository = clienteRepository;
        _paisRepository = paisRepository;
        _mapper = mapper;
        _logger = logger;
        _clienteService = clienteService;
        _contexto = contexto;
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

    [HttpGet("generados")]
    public ActionResult<List<Cliente>> GetClientesGenerados(int count = 10)
    {
        var clientes = _clienteService.GetClientes(count);
        return Ok(clientes);
    }

    [HttpGet("ClientesFake")]
    public ActionResult<List<Cliente>> GetClientesFake(int count)
    {
        var clienteFaker = new ClienteFaker();
        var clientes = clienteFaker.Generate(50);

        return clientes;
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
    // PUT api/cliente/{email}
    [HttpPut("{email}")]
    public async Task<ActionResult> Put(string email, [FromBody] EditViewModel clienteDto)
    {
        _logger.LogInformation($"Actualizando cliente con email {email}.");

        if (email != clienteDto.Email)
        {
            _logger.LogWarning($"Email del cliente en la solicitud ({clienteDto.Email}) no coincide con el email de la URL ({email}).");
            return BadRequest("El email del cliente no coincide.");
        }

        if (!ModelState.IsValid)
        {
            _logger.LogWarning($"El modelo ClienteDto no es válido. Errores: {ModelState}");
            return BadRequest(ModelState);
        }

        // Buscar el cliente existente en la base de datos
        var clienteExistente = await _clienteRepository.ObtenerPorEmail(email);
        if (clienteExistente == null)
        {
            _logger.LogWarning($"Cliente con email {email} no encontrado.");
            return NotFound("Cliente no encontrado.");
        }

        // Mapear las propiedades del DTO al cliente existente
        DateTime FechaNac = DateTimeOffset.FromUnixTimeMilliseconds(clienteDto.FechaNacimiento).UtcDateTime;
        //_mapper.Map(clienteDto, clienteExistente);

        clienteExistente.Nombre = clienteDto.Nombre;
        clienteExistente.Apellido = clienteDto.Apellido;
        clienteExistente.FechaNacimiento = FechaNac;
        clienteExistente.PaisId = clienteDto.PaisId;
        clienteExistente.Empleo = clienteDto.Empleo;

        await _clienteRepository.EditClienteAsync(clienteExistente);

        // Intentar guardar los cambios en la base de datos
        if (await _clienteRepository.GuardarCambios())
        {
            _logger.LogInformation($"Cliente con email {email} actualizado correctamente.");
            return NoContent();
        }

        return Ok(new { message = "Client edited successfully." });
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

    [HttpGet("GetPaisPorEmail")]
    public IActionResult GetPaisPorEmail(string email)
    {
        
        var cliente = _contexto.Clientes
            .Include(c => c.Pais)  
            .FirstOrDefault(c => c.Email == email);

    
        if (cliente == null)
        {
            return NotFound("Cliente no encontrado.");
        }

        // Si el cliente se encuentra, retorna el nombre del país en un OK
        return Ok(cliente.Pais.Nombre);
    }

    [HttpGet("GetClientePorEmail")]
    public IActionResult GetClientePorEmail(string email)
    {

        var cliente = _contexto.Clientes
            .FirstOrDefault(c => c.Email == email);


        if (cliente == null)
        {
            return NotFound("Cliente no encontrado.");
        }

        // Si el cliente se encuentra, retorna el nombre del país en un OK
        return Ok(cliente);
    }

}
