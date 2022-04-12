using Microsoft.AspNetCore.Mvc;
using Remi.Api.Filters;

namespace ProyectoBCP_API.Filters
{
    public class IsAuthenticatedAttribute : TypeFilterAttribute
    {
        public IsAuthenticatedAttribute() : base(typeof(TokenAuthenticationFilter))
        {
            Arguments = new object[] { new string[] { } };
        }

        public IsAuthenticatedAttribute(string[] roles) : base(typeof(TokenAuthenticationFilter))
        {
            Arguments = new object[] { roles };
        }
    }
}