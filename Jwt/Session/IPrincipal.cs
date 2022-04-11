using System.Collections.Generic;
using System.Security.Claims;

namespace ProyectoBCP_API.Jwt.Session
{
    public interface IPrincipal
    {
        ClaimsPrincipal Principal { get; }
        IDictionary<object, object> Items { get; }
    }
}