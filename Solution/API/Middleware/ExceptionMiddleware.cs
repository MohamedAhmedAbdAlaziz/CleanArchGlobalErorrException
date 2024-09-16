using API.Error;
using System.Net;
using System.Text.Json;

namespace API.Middleware;

public class ExceptionMiddleware
{
private readonly RequestDelegate _next;
private readonly ILogger<ExceptionMiddleware> _logger;
private readonly IHostEnvironment _env;


public ExceptionMiddleware(
RequestDelegate next,
ILogger<ExceptionMiddleware> logger,
IHostEnvironment env
)
{
    _next = next;
    _logger = logger;
    _env = env;
}

public async Task InvokeAsync(HttpContext context)
{
    try
    {
        await _next(context);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, ex.Message);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.StatusCode = ex switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            var response = //_env.IsDevelopment()
                           // ?
           new FailResponse(context.Response.StatusCode, ex.Message, new string[] { ex.StackTrace?.ToString() });
        // new FailResponse(context.Response.StatusCode, "Internal Server Error");
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var json = JsonSerializer.Serialize(response, options);
        await context.Response.WriteAsync(json);
    }
}

}