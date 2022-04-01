using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Models.Request;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Service.Impl;
using trabajo_final_API.Models.Response;

namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMemberController(ITeamMemberService teamMemberService)
        {           
                _teamMemberService = teamMemberService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            WrapperResponse _response = new WrapperResponse();

            try
            {
                _response.Data = this._teamMemberService.GetAll();
            }
            catch (System.Exception)
            {

                _response = null;
            }

            return Ok(_response);

        }

        [HttpPost]
        public IActionResult Add(TeamMemberRequest request)
        {
            WrapperResponse _respuesta = new WrapperResponse();
            try
            {
                _teamMemberService.Add(request);
                _respuesta.Data = request;
            }
            catch (System.Exception ex)
            {
                _respuesta.Data = null;
            }
            return Ok(_respuesta);
        }

        [HttpPut]
        public IActionResult Edit(TeamMemberRequest request)
        {
            WrapperResponse _respuesta = new WrapperResponse();
            try
            {
                _teamMemberService.Edit(request);
                _respuesta.Data = request;
            }
            catch (System.Exception ex)
            {
                _respuesta.Data = null;
            }
            return Ok(_respuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            WrapperResponse _respuesta = new WrapperResponse();
            try
            {
                TeamMemberRequest request = new TeamMemberRequest();
                request.Id = Id;
                _teamMemberService.Delete(request);
                _respuesta.Data = request;
            }
            catch (System.Exception)
            {
                _respuesta.Data = null;
            }
            return Ok(_respuesta);
        }
    }
}
