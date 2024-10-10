using App.Services.Logs;

namespace App.Api.Middlewares;

public class LogMiddleware
{
  private readonly RequestDelegate _next;

  public LogMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    await LogService.WriteAsync(context.Request.Path, context.Request.Method, context.Response.StatusCode, context.Connection.Id);
    await _next(context);
  }
}
