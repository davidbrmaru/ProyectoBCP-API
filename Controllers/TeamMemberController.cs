using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoBCP_API.Data;
using ProyectoBCP_API.Service;
using ProyectoBCP_API.Service.Impl;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoBCP_API.Models;
using ProyectoBCP_API.Filters;

namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[IsAuthenticated]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;
        private readonly ILog log;
        public TeamMemberController(ITeamMemberService teamMemberService)
        {           
                _teamMemberService = teamMemberService;
                log = LogManager.GetLogger(typeof(TeamMemberController));
        }
           // GET: api/<TeamMemberController>
        [HttpGet]
        public async Task<IEnumerable<TeamMember>> GetTeamMemberLeader()
        {
            log.Info("Inicio Get ChaptersArea");
            return await _teamMemberService.GetTeamMember();
        }

        // GET api/<TeamMemberController>/5
        [HttpGet("{id}")]
        public async Task<TeamMember> GetTeamMemberControllerbyId(int id)
        {
            log.Info("Inicio Get ChaptersArea By Id");
            return await _teamMemberService.GetTeamMemberById(id);
        }

        // POST api/<TeamMemberController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TeamMember teamMember)
        {
            log.Info("Inicio Post ChaptersArea");
            var result = await _teamMemberService.InsertTeamMember(teamMember);
            return Ok(result);
        }

        // PUT api/<TeamMemberController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] TeamMember teamMember)
        {
            log.Info("Inicio Put ChapterArea ById");
            var result = await _teamMemberService.UpdateTeamMember(id, teamMember);
            return Ok(result);
        }

        // DELETE api/<TeamMemberController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] TeamMember chapter)
        {
            log.Info("Inicio Delete ChapterArea ById");
            var result = await _teamMemberService.DeleteAsyncByid(id, chapter);
            return Ok(result);
        }
      
    }
}
