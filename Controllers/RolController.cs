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
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        private readonly ILog log;


        public RolController(IRolService rolService)
        {
            this._rolService = rolService;
            log = LogManager.GetLogger(typeof(UserController));
        }

        [HttpGet]
        public async Task<IEnumerable<Rol>> GetRol()
        {
            log.Info("Inicio Get rol");
            return await _rolService.GetRol();
        }
        [HttpGet("{id}")]
        public async Task<Rol> GetRolById(int id)
        {
            log.Info("Inicio Get rol By Id");
            return await _rolService.GetRolById(id);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Rol rol)
        {
            log.Info("Inicio Post rol");
            var result = await _rolService.InsertRol(rol);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Rol rol)
        {
            log.Info("Inicio Put rol ById");
            var result = await _rolService.UpdateRol(id, rol);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] Rol rol)
        {
            log.Info("Inicio Delete rol ById");
            var result = await _rolService.DeleteAsyncByid(id, rol);
            return Ok(result);
        }

    }
}
