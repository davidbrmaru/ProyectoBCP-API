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

    [HttpGet("{id}")]
        public async Task<Application> GetApplicationById(int id)
        {
            log.Info("Inicio Get Application By Id");
            return await _aplicacionService.GetApplicationById(id);
        }
   
    [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Application application)
        {
            log.Info("Inicio Post Application");
            var result = await _aplicacionService.InsertApplication(application);
            return Ok(result);
        }
    [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Application application)
        {
            log.Info("Inicio Put application ById");
            var result = await _aplicacionService.UpdateApplication(id, application);
            return Ok(result);
        }
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] Application application)
        {
            log.Info("Inicio Delete application ById");
            var result = await _aplicacionService.DeleteAsyncByid(id, application);
            return Ok(result);
        }
    }
}
