using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;
using ProyectoBCP_API.Models.Request;

namespace trabajo_final_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TribeController : ControllerBase
    {
        private readonly ITribeService _tribeService;
        private readonly ILog log;

        public TribeController(ITribeService tribeService)
        {
            this._tribeService = tribeService;
            log = LogManager.GetLogger(typeof(TribeController));
        }

        [HttpGet]
        public async Task<TribeRequest> GetTribe([FromQuery] PaginadoRequest PaginadoResponse)
        {
            log.Info("Inicio Get Tribe");
            return await _tribeService.GetTribe(PaginadoResponse);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<Tribe>> GetAllTribe()
            {
                log.Info("Inicio Get Tribe");
                return await _tribeService.GetAllTribe();
            }

        [HttpGet("{id}")]
            public async Task<Tribe> GetApplicationById(int id)
            {
                log.Info("Inicio Get Tribe By Id");
                return await _tribeService.GetTribeById(id);
            }
    
        [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] Tribe tribe)
            {
                log.Info("Inicio Post Tribe");
                var result = await _tribeService.InsertTribe(tribe);
                return Ok(result);
            }

        [HttpPut("{id}")]
            public async Task<IActionResult> PutAsync(int id, [FromBody] Tribe tribe)
            {
                log.Info("Inicio Put tribe ById");
                var result = await _tribeService.UpdateTribe(id, tribe);
                return Ok(result);
            }
        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAsync(int id, [FromBody] Tribe tribe)
            {
                log.Info("Inicio Delete tribe ById");
                var result = await _tribeService.DeleteAsyncByid(id, tribe);
                return Ok(result);
            }
    }
}