using Microsoft.AspNetCore.Mvc;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Service;
using System.Collections.Generic;

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
        public async Task<IEnumerable<BaseActivo>> PostAsync([FromBody] User user)
        {
            log.Info("Inicio Base de activos");
           return await _activoService.GetBaseActivos(user.CodMatricula);
        }

    }
}
