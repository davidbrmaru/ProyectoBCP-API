using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ProyectoBCP_API.Jwt.Session
{
    public class DefaultPrincipal : IPrincipal
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public DefaultPrincipal(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal Principal => _httpContextAccessor.HttpContext.User;
        public IDictionary<object, object> Items => _httpContextAccessor.HttpContext.Items;
    }
}