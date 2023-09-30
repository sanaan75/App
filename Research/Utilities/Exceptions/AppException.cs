namespace Entities.Utilities.Exceptions;

public class AppException : Exception
{
    public int StatusCode { get; set; }
    public string? Message { get; set; } 
    public object? ExceptionData { get; set; }

    public AppException(int statusCode, string message, object exceptionData)
    {
        StatusCode = statusCode;
        this.Message = message;
        ExceptionData = exceptionData;
    }

    public AppException(int statusCode, object exceptionData)
    {
        StatusCode = statusCode;
        ExceptionData = exceptionData;
    }

    public AppException(int statusCode, string message)
    {
        StatusCode = statusCode;
        this.Message = message;
    }

    public AppException(int statusCode)
    {
        StatusCode = statusCode;
    }
}