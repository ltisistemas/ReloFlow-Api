using System.Net;
using System.Text.Json;
using RelowFlow_api.Application.Exceptions;
using RelowFlow_api.Application.Helper;

namespace RelowFlow_api.Application.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IWebHostEnvironment _environment;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IWebHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        var response = exception switch
        {
            UserException userEx => ApiResponse<object>.ErrorResponse(
                userEx.Message,
                (int)HttpStatusCode.BadRequest,
                _environment.IsDevelopment() ? exception.StackTrace : null
            ),
            CompanyException companyEx => ApiResponse<object>.ErrorResponse(
                companyEx.Message,
                (int)HttpStatusCode.BadRequest,
                _environment.IsDevelopment() ? exception.StackTrace : null
            ),
            UnauthorizedAccessException => ApiResponse<object>.ErrorResponse(
                "Não autorizado",
                (int)HttpStatusCode.Unauthorized
            ),
            _ => ApiResponse<object>.ErrorResponse(
                "Ocorreu um erro interno. Tente novamente mais tarde.",
                (int)HttpStatusCode.InternalServerError,
                _environment.IsDevelopment() ? exception.StackTrace : null
            )
        };

        _logger.LogError(exception, 
            "Erro ao processar requisição: {Message}", 
            exception.Message);

        context.Response.StatusCode = response.StatusCode;
        
        var jsonOptions = new JsonSerializerOptions 
        { 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
        };
        
        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response, jsonOptions));
    }
}