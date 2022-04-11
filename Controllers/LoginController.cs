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
    public class LoginController
    {
        private readonly ITeamMemberService _teamMemberService;
        private readonly ITokenProvider _tokenProvider;

        public LoginController(ITeamMemberService teamMemberService, ITokenProvider tokenProvider)
        {
            this._teamMemberService = teamMemberService;
            this._tokenProvider = tokenProvider;
        }


        [HttpPost("login")]
        public async Task<ActionResult<SessionDto>> LoginUser(LoginDto loginDto)
        {
            TeamMember teamMember = await _teamMemberService.GetTeamMemberByMatricula(loginDto.Matricula);
            if (teamMember != null)
            {
                var token = GenerateToken(teamMember.Id, teamMember.CodMatricula, "USER", true);
                UserDto userDto = new UserDto();
                userDto._matricula = teamMember.CodMatricula;
                userDto._nombre = teamMember.Nombre + "" + teamMember.ApellidoPaterno + "" + teamMember.ApellidoMaterno;
                return new SessionDto(userDto, token);
            }
            else throw new UnauthorizedException();            
        }

        private string GenerateToken(int identifier, string username, string role, bool extendTime = false)
        {
            var claims = new Dictionary<string, string>
            {
                { ClaimsConstants.IdentifierKey, identifier.ToString() },
                { ClaimsConstants.UsernameKey, username },
                { ClaimsConstants.RoleKey, role }
            };

            return _tokenProvider.GenerateToken(claims, extendTime);
        }
    }
}
