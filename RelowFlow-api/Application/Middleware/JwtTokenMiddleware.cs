namespace RelowFlow_api.Application.Middleware;

public class JwtTokenMiddleware
{
    private readonly RequestDelegate _next;

    public JwtTokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Se o header Authorization existir mas não começar com "Bearer ", adiciona o prefixo
        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var authHeader = context.Request.Headers["Authorization"].ToString();

            // Se o header não começar com "Bearer " e não estiver vazio, adiciona o prefixo
            if (!string.IsNullOrEmpty(authHeader) &&
                !authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                context.Request.Headers["Authorization"] = $"Bearer {authHeader}";
            }
        }

        await _next(context);
    }
}

