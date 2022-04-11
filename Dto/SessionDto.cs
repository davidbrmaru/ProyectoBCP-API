using ProyectoBCP_API.Models;

namespace ProyectoBCP_API.Dto
{
    public class SessionDto
    {

        public SessionDto(UserDto userDto, string token)
        {
            this.UserDto = userDto;
            this.Token = token;
        }

        public UserDto UserDto { get; set; }
        public string Token { get; set; }
    }
}