using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trabajo_final_API.Models.Response;
using trabajo_final_API.Service;

namespace trabajo_final_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IAplicacionService _aplicacionService;
        public ApplicationController(IAplicacionService aplicacionService)
        {
            this._aplicacionService = aplicacionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            WrapperResponse _response = new WrapperResponse();

            try
            {
                _response.Data = this._aplicacionService.GetAll();
            }
            catch (System.Exception)
            {

                _response = null;
            }

            return Ok(_response);

        }
    }
}
