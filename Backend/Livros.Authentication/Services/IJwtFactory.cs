using System.Security.Claims;

namespace Livros.Authentication.Services
{
    public interface IJwtFactory
    {
        Task<string> GenerateJwtToken(ClaimsIdentity claimsIdentity);
    }
}
