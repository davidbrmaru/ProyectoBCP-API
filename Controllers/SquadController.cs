using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trabajo_final_API.Models.Response;
using trabajo_final_API.Service;

namespace trabajo_final_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly ISquadService _squadService;
        public SquadController(ISquadService squadService)
        {
                this._squadService = squadService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            WrapperResponse _response = new WrapperResponse();

            try
            {
                _response.Data = this._squadService.GetAll();
            }
            catch (System.Exception)
            {

                _response = null;
            }
            
            return Ok(_response);

        }
    }
}
