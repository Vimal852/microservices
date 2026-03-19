using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore; // <-- add this
namespace Api.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        try { await next(ctx); }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await WriteErrorAsync(ctx, ex);
        }
    }

    private static Task WriteErrorAsync(HttpContext ctx, Exception ex)
    {
        ctx.Response.ContentType = "application/json";
        ctx.Response.StatusCode = ex switch
        {
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            InvalidOperationException => (int)HttpStatusCode.BadRequest,
            DbUpdateConcurrencyException => (int)HttpStatusCode.Conflict,   
            DbUpdateException => (int)HttpStatusCode.BadRequest, 
            _ => (int)HttpStatusCode.InternalServerError
        };

        var message = ex switch
        {
            DbUpdateConcurrencyException => "Record was modified or deleted by another user. Please refresh and try again.",
            _ => ex.Message
        };

        var body = JsonSerializer.Serialize(new { error = message });
        return ctx.Response.WriteAsync(body);
    }
}