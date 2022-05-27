using Microsoft.AspNetCore.Mvc;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Service;
using System.Collections.Generic;
using ProyectoBCP_API.Models.Request;

namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseActivoController : ControllerBase
    {
        private readonly IBaseActivoService _activoService;
        private readonly ILog log;

        public BaseActivoController(IBaseActivoService activoService)
        {
            this._activoService = activoService;
            log = LogManager.GetLogger(typeof(BaseActivoController));
        }     

        [HttpPost]
        public async Task<BaseActivoRequest> PostAsync([FromBody] User user, [FromQuery] PaginadoRequest PaginadoResponse)
        {
            log.Info("Inicio Base de activos");
           return await _activoService.GetBaseActivos(user.CodMatricula, PaginadoResponse);
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
