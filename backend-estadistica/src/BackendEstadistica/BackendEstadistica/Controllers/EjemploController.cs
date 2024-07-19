using Microsoft.AspNetCore.Mvc;
using TuProyecto.Biblioteca;

namespace BackendEstadistica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EjemploController : ControllerBase
    {
        private readonly CSVReader _csvReader;

        public EjemploController()
        {
            _csvReader = new CSVReader();
        }

        [HttpGet]
        [Route("leer")]
        public IActionResult LeerCSV([FromQuery] string filePath)
        {
            try
            {
                var datos = _csvReader.LeerArchivoCSV(filePath);
                return Ok(datos);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                //  return StatusCode(500, new { message = ex.Message });   
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
