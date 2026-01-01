namespace RelowFlow_api.Application.Helper;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Trace { get; set; }
    public object? Error { get; set; }
    
    public static ApiResponse<T> SuccessResponse(T data, string message = "Operação realizada com sucesso", int statusCode = 200)
    {
        return new ApiResponse<T>
        {
            Data = data,
            Message = message,
            Success = true,
            StatusCode = statusCode,
            Trace = null,
            Error = null
        };
    }
    
    public static ApiResponse<T> ErrorResponse(string message, int statusCode = 400, string? trace = null, object? error = null)
    {
        return new ApiResponse<T>
        {
            Data = default,
            Message = message,
            Success = false,
            StatusCode = statusCode,
            Trace = trace,
            Error = error
        };
    }
}