
namespace BackendEstadistica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesConBalanceController : ControllerBase
    {
        private readonly ContextoBBDD _contextoBBDD;

        public ClientesConBalanceController(ContextoBBDD context)
        {
            _contextoBBDD = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteConBalance>>> GetClientesConBalance()
        {
            var clientesConBalance = await _contextoBBDD.ClientesConBalance.ToListAsync();
            return Ok(clientesConBalance);
        }
    }
}
