using System;
using System.Collections.Generic;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;

namespace ProyectoBCP_API.Jwt.Provider.Impl
{
    public class JwTokenProvider : ITokenProvider
    {
        private readonly JwtSettings _jwtSettings;

        public JwTokenProvider(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateToken(IDictionary<string, string> claims, bool extendTime = false)
        {
            var builder = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_jwtSettings.SecretKey)
                .Issuer(_jwtSettings.Issuer)
                .Audience(_jwtSettings.Audience)
                .ExpirationTime(
                    extendTime ? DateTime.Now.AddDays(_jwtSettings.ExpireDays) :
                    DateTime.Now.AddHours(_jwtSettings.ExpireHours)
                );

            foreach (var claim in claims)
            {
                builder.AddClaim(claim.Key, claim.Value);
            }

            return builder.Encode();
        }

        public IDictionary<string, string> ValidateToken(string token)
        {
            try
            {
                return new JwtBuilder()
                    .WithSecret(_jwtSettings.SecretKey)
                    .Decode<Dictionary<string, string>>(token);
            }
            catch (TokenExpiredException e)
            {
                throw e;
            }
            catch (SignatureVerificationException e)
            {
                throw e;
            }
        }
    }
}