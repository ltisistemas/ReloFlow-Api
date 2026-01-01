using Microsoft.AspNetCore.Mvc;
using RelowFlow_api.Application.Helper;

namespace RelowFlow_api.Application.Helper;

public static class ControllerExtensions
{
    public static IActionResult OkResponse<T>(this ControllerBase controller, T data, string message = "Operação realizada com sucesso")
    {
        var response = ApiResponse<T>.SuccessResponse(data, message, 200);
        return new ObjectResult(response) { StatusCode = 200 };
    }

    public static IActionResult CreatedResponse<T>(this ControllerBase controller, T data, string message = "Recurso criado com sucesso")
    {
        var response = ApiResponse<T>.SuccessResponse(data, message, 201);
        return new ObjectResult(response) { StatusCode = 201 };
    }

    public static IActionResult ErrorResponse<T>(this ControllerBase controller, string message, int statusCode = 400, string? trace = null, object? error = null)
    {
        var response = ApiResponse<T>.ErrorResponse(message, statusCode, trace, error);
        return new ObjectResult(response) { StatusCode = statusCode };
    }

    // Método helper para quando você não quer especificar o tipo (usa object)
    public static IActionResult ErrorResponse(this ControllerBase controller, string message, int statusCode = 400, string? trace = null, object? error = null)
    {
        return controller.ErrorResponse<object>(message, statusCode, trace, error);
    }
}