using Microsoft.AspNetCore.Mvc;
using TuProyecto.Biblioteca;    // importa namespace de nuestro CSVReader

namespace BackendEstadistica.Controllers
{
    [ApiController]             // Indica que esta clase es un controlador de API
    [Route("[controller]")]     // Define la ruta base para las acciones en este controlador ("ejemplo")
    public class EjemploController : ControllerBase
    {
        
        private readonly CSVReader _csvReader;  // Declara

        public EjemploController()              
        {
            _csvReader = new CSVReader();       // Instancia
        }

        /* Este bloque de código define un método de acción llamado LeerCSV
         * responde a solicitudes GET en la ruta leer
         * La URL completa será ejemplo/leer 
         */

            /* El método devuelve un objeto IActionResult,
             * lo que permite devolver diferentes tipos de respuestas HTTP.
             * El parámetro filePath se obtiene de la query string de la solicitud HTTP ([FromQuery])
             */

        [HttpGet]
        [Route("leer")]
        public IActionResult LeerCSV([FromQuery] string filePath)
        {
            try
            {
                var datos = _csvReader.LeerArchivoCSV(filePath);    // Llamamos al método LeerArchivoCSV
                return Ok(datos);                                       // Si Todo OK
            }
            catch (FileNotFoundException ex)                    
            {
                return NotFound(new { message = ex.Message });          // Si no se encuentra
            }
            catch (Exception ex)            
            {  
                return BadRequest(new { message = ex.Message });        // Para cualquier otra excepción
            }
        }
    }
}
