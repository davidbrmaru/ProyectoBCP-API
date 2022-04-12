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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly ILog log;

        public MenuController(IMenuService menuService)
        {
            this._menuService = menuService;
            log = LogManager.GetLogger(typeof(UserController));
        }

        [HttpGet]
        public async Task<IEnumerable<Menu>> GetMenu()
        {
            log.Info("Inicio Get menu");
            return await _menuService.GetMenu();
        }
        [HttpGet("{id}")]
        public async Task<Menu> GetMenuById(int id)
        {
            log.Info("Inicio Get menu By Id");
            return await _menuService.GetMenuById(id);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Menu menu)
        {
            log.Info("Inicio Post Menu");
            var result = await _menuService.InsertMenu(menu);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Menu menu)
        {
            log.Info("Inicio Put menu ById");
            var result = await _menuService.UpdateMenu(id, menu);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] Menu menu)
        {
            log.Info("Inicio Delete menu ById");
            var result = await _menuService.DeleteAsyncByid(id, menu);
            return Ok(result);
        }


    }
}
