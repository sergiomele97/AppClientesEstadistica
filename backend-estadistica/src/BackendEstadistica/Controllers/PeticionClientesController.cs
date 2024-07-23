using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendEstadistica.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeticionClientesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clientes = await ClientesRepositorioMemoria.Instancia.ObtenerClientes();
    
        return Ok(clientes);
    }
}