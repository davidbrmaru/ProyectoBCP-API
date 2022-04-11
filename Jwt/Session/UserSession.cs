using ProyectoBCP_API.Jwt.Session;
using System;
using System.Linq;

namespace ProyectoBCP_API.Jwt.Session
{
    public class UserSession : IUserSession
    {
        private IPrincipal Principal { get; }

        public UserSession(IPrincipal principal)
        {
            Principal = principal;
        }

        private string _userId, _username, _role;

        public string UserId => GetUserId();
        public string Username => GetUsername();
        public string Role => GetRole();

        private string GetUserId()
        {
            _userId = Principal.Principal.Claims
                .Where(c => c.Type == ClaimsConstants.IdentifierKey).Select(c => c.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(_userId))
            {
                //throw new NullReferenceException("El usuario no se encuentra");
            }
            return _userId;
        }

        private string GetUsername()
        {
            _username = Principal.Principal.Claims
                .Where(c => c.Type == ClaimsConstants.UsernameKey).Select(c => c.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(_username))
            {
                throw new NullReferenceException("El usuario no se encuentra");
            }
            return _username;
        }
        
        private string GetRole()
        {
            _role = Principal.Principal.Claims
                .Where(c => c.Type == ClaimsConstants.RoleKey).Select(c => c.Value).FirstOrDefault();
            
            if (string.IsNullOrEmpty(_role))
            {
                throw new NullReferenceException("El usuario no se encuentra");
            }
            return _role;
        }
    }
}