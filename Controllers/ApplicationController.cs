using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;

namespace ProyectoBCP_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationServices _applicationServices;
        private readonly ILog log;
        public ApplicationController(IApplicationServices applicationServices)
        {
            this._applicationServices = applicationServices;
            log = LogManager.GetLogger(typeof(ApplicationController));
        }

        // GET: api/<ApplicationController>
        [HttpGet]
        public async Task<IEnumerable<Application>> GetApplication()
        {
            log.Info("Inicio Get Application");
            return await _applicationServices.GetApplication();
        }

        // GET api/<ApplicationController>
        [HttpGet("{id}")]
        public async Task<Application> GetApplicationById(int id)
        {
            log.Info("Inicio Get Application By Id");
            return await _applicationServices.GetApplicationById(id);
        }

       /*
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] Application application)
        {
            log.Info("Inicio Delete Application ById");
            var result = await _chapterAreaLeaderServices.DeleteAsyncByid(id, application);
            return Ok(result);
        }*/
    }
}

