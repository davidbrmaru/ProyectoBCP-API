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
    public class SubMenuController : ControllerBase
    {
        private readonly ISubMenuService _subMenuService;
        private readonly ILog log;

        public SubMenuController(ISubMenuService subMenuService)
        {
            this._subMenuService = subMenuService;
            log = LogManager.GetLogger(typeof(UserController));
        }
        [HttpGet]
        public async Task<IEnumerable<SubMenu>> GetSubMenu()
        {
            log.Info("Inicio Get submenu");
            return await _subMenuService.GetSubMenu();
        }
        [HttpGet("{id}")]
        public async Task<SubMenu> GetSubMenuById(int id)
        {
            log.Info("Inicio Get submenu By Id");
            return await _subMenuService.GetSubMenuById(id);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SubMenu subMenu)
        {
            log.Info("Inicio Post subMenu");
            var result = await _subMenuService.InsertSubMenu(subMenu);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SubMenu subMenu)
        {
            log.Info("Inicio Put submenu ById");
            var result = await _subMenuService.UpdateSubMenu(id, subMenu);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] SubMenu subMenu)
        {
            log.Info("Inicio Delete submenu ById");
            var result = await _subMenuService.DeleteAsyncByid(id, subMenu);
            return Ok(result);
        }

    }
}
