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

      

    }
}
