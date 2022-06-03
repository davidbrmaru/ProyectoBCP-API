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
        private readonly IUserService _userService;
        private readonly ITokenProvider _tokenProvider;

        public LoginController(IUserService userService, ITokenProvider tokenProvider)
        {
            this._userService = userService;
            this._tokenProvider = tokenProvider;
        }


        [HttpPost]
        public async Task<ActionResult<SessionDto>> LoginUser(LoginDto loginDto)
        {
            User user = await _userService.GetUserByCodMatriculaPassword(loginDto.Matricula, loginDto.Password);
            if (user != null)
            {
                var token = GenerateToken(user.Id, user.CodMatricula, "USER", true);
                UserDto userDto = new UserDto();
                userDto._matricula = user.CodMatricula;
                userDto._nombre = user.Correo;
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
