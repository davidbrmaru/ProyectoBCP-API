namespace ProyectoBCP_API.Jwt
{
    public sealed class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireHours { get; set; }
        public int ExpireMinutes { get; set; }
        public int ExpireDays { get; set; }
    }
}