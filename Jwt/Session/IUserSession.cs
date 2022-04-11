namespace ProyectoBCP_API.Jwt.Session
{
    public interface IUserSession
    {
        string UserId { get; }
        string Username { get; }
        string Role { get; }
    }
}