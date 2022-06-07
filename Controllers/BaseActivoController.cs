using Microsoft.AspNetCore.Mvc;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Service;
using System.Collections.Generic;
using ProyectoBCP_API.Models.Request;
using ProyectoBCP_API.Filters;
namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [IsAuthenticated]
    public class BaseActivoController : ControllerBase
    {
        private readonly IBaseActivoService _activoService;
        private readonly ILog log;

        public BaseActivoController(IBaseActivoService activoService)
        {
            this._activoService = activoService;
            log = LogManager.GetLogger(typeof(BaseActivoController));
        }     

        [HttpGet]
        public async Task<BaseActivoRequest> GetBaseActivo([FromQuery] PaginadoRequest PaginadoResponse)
        {
            log.Info("Inicio Base de activos");
           return await _activoService.GetBaseActivos(PaginadoResponse);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<BaseActivo>> GetAllBaseActivo()
        {
            log.Info("Inicio Get All Chapters");
            return await _activoService.GetAllBaseActivos();
        }

    }
}
