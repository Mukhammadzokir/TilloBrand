using TilloBrand.Api.Responses;
using TilloBrand.Service.Exceptions;

namespace TilloBrand.Api.MiddleWares;

public class ExceptionHandlerMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlerMiddleWare(RequestDelegate next, ILogger<ExceptionHandlerMiddleWare> logger)
    {
        this._next = next;
        this._logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this._next(context);
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.statusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = ex.statusCode,
                Message = ex.Message,
            });
        }
        catch(Exception ex)
        {
            this._logger.LogError($"{ex}\n\n");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = 500,
                Message = ex.Message,
            });
        }
    }
}

