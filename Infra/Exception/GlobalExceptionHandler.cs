using Microsoft.AspNetCore.Diagnostics;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
    (
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken
    )
    {
        var methodInfo = exception.TargetSite;
        var declaringType = methodInfo?.DeclaringType;

        if (declaringType != null && declaringType.IsDefined(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true))
        {
            declaringType = declaringType.DeclaringType ?? declaringType;
        }
        
        var originClass = declaringType?.Name ?? "Unknown";
        int statusCode = exception switch
        {
            DomainNotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(new
        {
            Code = statusCode,
            Error = exception.GetType().Name,
            Source = originClass,
            Message = exception.Message
        }, 
        cancellationToken);

        return true;
    }
}