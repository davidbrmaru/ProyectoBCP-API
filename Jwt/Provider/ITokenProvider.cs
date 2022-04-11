using System.Collections.Generic;

namespace ProyectoBCP_API.Jwt.Provider
{
    public interface ITokenProvider
    {
        string GenerateToken(IDictionary<string, string> claims, bool extendTime = false);
        IDictionary<string, string> ValidateToken(string token);
    }
}