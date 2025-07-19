using System.Security.Claims;

namespace MovieManage.Service.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string name, string email, int UserID);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
