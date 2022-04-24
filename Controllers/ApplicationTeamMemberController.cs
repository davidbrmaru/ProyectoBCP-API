using Microsoft.AspNetCore.Mvc;
using ProyectoBCP_API.Dto;
using ProyectoBCP_API.Exceptions;
using ProyectoBCP_API.Jwt.Provider;
using ProyectoBCP_API.Jwt.Session;
using ProyectoBCP_API.Models;
using ProyectoBCP_API.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoBCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationTeamMemberController
    {
        private readonly IApplicationTeamMemberService _applicationTeamMemberService;

        public ApplicationTeamMemberController(IApplicationTeamMemberService applicationTeamMemberService)
        {
            this._applicationTeamMemberService = applicationTeamMemberService;
        }


        [HttpPost]
        public async Task<ActionResult<AllocationDto>> LoginUser(AllocationDto allocationDto)
        {
            return await _applicationTeamMemberService.InsertApplicationTeamMember(allocationDto);
        }
    }
}
