using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trabajo_final_API.Models.Response;
using trabajo_final_API.Service;

namespace trabajo_final_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TribuController : ControllerBase
    {
        private readonly ITribuService _tribuService;
        public TribuController(ITribuService tribuService)
        {
                this._tribuService = tribuService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            WrapperResponse _response = new WrapperResponse();

            try
            {
                _response.Data = this._tribuService.GetAll();
            }
            catch (System.Exception)
            {

                _response = null;
            }
            
            return Ok(_response);

        }
    }
}
