using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Models;
using System.Threading.Tasks;
using log4net;
using ProyectoBCP_API.Models.Request;

namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly ISquadService _squadService;
        private readonly ILog log;

        public SquadController(ISquadService squadService)
        {
            this._squadService = squadService;
            log = LogManager.GetLogger(typeof(SquadController));
        }

        [HttpGet]
        public async Task<SquadRequest> GetSquad([FromQuery] PaginadoRequest PaginadoResponse)
        {
            log.Info("Inicio Get Tribe");
            return await _squadService.GetSquad(PaginadoResponse);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<Squad>> GetAllSquad()
        {
            log.Info("Inicio Get Squad");
            return await _squadService.GetAllSquad();
        }

        [HttpGet("{id}")]
        public async Task<Squad> GetSquadById(int id)
        {
            log.Info("Inicio Get Squad By Id");
            return await _squadService.GetSquadById(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Squad squad)
        {
            log.Info("Inicio Post Squad");
            var result = await _squadService.InsertSquad(squad);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Squad squad)
        {
            log.Info("Inicio Put squad ById");
            var result = await _squadService.UpdateSquad(id, squad);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] Squad squad)
        {
            log.Info("Inicio Delete squad ById");
            var result = await _squadService.DeleteAsyncByid(id, squad);
            return Ok(result);
        }
    }
}