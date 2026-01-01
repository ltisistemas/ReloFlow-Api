using System.Security.Claims;

namespace RelowFlow_api.Application.Helper;

public static class JwtHelper
{
    public static Guid GetUserId(HttpContext httpContext)
    {
        var idString = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(idString) || !Guid.TryParse(idString, out var id))
        {
            throw new UnauthorizedAccessException("User ID não encontrado no token JWT");
        }

        return id;
    }
    
    public static string? GetUserEmail(HttpContext httpContext)
    {
        return httpContext.User.FindFirst(ClaimTypes.Email)?.Value;
    }
}