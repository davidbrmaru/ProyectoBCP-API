using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;

namespace trabajo_final_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _aplicacionService;
        private readonly ILog log;

        public ApplicationController(IApplicationService aplicacionService)
        {
            this._aplicacionService = aplicacionService;
            log = LogManager.GetLogger(typeof(ApplicationController));
        }

    [HttpGet]
    public async Task<IEnumerable<Application>> GetApplication()
        {
            log.Info("Inicio Get Application");
            return await _aplicacionService.GetApplication();
        }

    }
}
