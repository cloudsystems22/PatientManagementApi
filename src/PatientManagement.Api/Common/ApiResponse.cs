namespace PatientManagement.Api.Common;

public class ApiResponse<T>
{
    public bool Success { get; private set; }
    public string? Message { get; private set; }
    public T? Data { get; private set; }

    private ApiResponse(bool success, T? data, string? message)
    {
        Success = success;
        Data = data;
        Message = message;
    }

    public static ApiResponse<T> Ok(T data, string? message = null)
        => new(true, data, message);

    public static ApiResponse<T> Fail(string message)
        => new(false, default, message);
}
