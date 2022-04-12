using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProyectoBCP_API.Exceptions;
using ProyectoBCP_API.Jwt.Provider;
using ProyectoBCP_API.Jwt.Session;

namespace Remi.Api.Filters
{
    public class TokenAuthenticationFilter : ActionFilterAttribute
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly List<string> _roles;

        public TokenAuthenticationFilter(ITokenProvider tokenProvider, string[] roles)
        {
            _tokenProvider = tokenProvider;
            _roles = roles.ToList();
        }

        public override void OnActionExecuted(ActionExecutedContext context) { }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var hasAuthHeader = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationToken);
            if (!hasAuthHeader)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var token = authorizationToken[0];

            if (!token.Contains("Bearer "))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                token = token.Replace("Bearer ", "");
                var claims = _tokenProvider.ValidateToken(token);

                var c1 = claims.Select(
                    claim => new Claim(claim.Key, claim.Value)).ToList();

                if (_roles != null && _roles.Count > 0)
                {
                    var role = c1.Where(c => c.Type == ClaimsConstants.RoleKey).Select(c => c.Value).FirstOrDefault();
                    if (!_roles.Contains(role)) throw new ForbiddenException();
                }
                
                context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(c1, "Bearer"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                context.Result = new UnauthorizedResult();
            }
        }
    }
}