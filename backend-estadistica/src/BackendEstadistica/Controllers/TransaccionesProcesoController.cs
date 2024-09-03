using BackendEstadistica.Servicios;
namespace BackendEstadistica.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TransaccionesProcesoController : ControllerBase
{
    private readonly TransaccionService _transaccionService;

    public TransaccionesProcesoController(TransaccionService transaccionService)
    {
        _transaccionService = transaccionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetFilteredTransacciones([FromQuery] int? clienteId, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
    {
        var result = await _transaccionService.GetFilteredTransacciones(clienteId, startDate, endDate);
        return Ok(result);
    }
}
