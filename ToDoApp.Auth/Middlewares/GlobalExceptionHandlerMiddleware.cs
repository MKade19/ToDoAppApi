using Microsoft.AspNetCore.Mvc;
using ToDoApp.Common.Exceptions;

namespace ToDoApp.Auth.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException e)
            {
                var traceId = Guid.NewGuid();
                var StatusCode = StatusCodes.Status404NotFound;

                context.Response.StatusCode = StatusCode;

                var problemDetails = new ProblemDetails
                {
                    Type = "http://api/bus-station/",
                    Title = "Not found Error",
                    Status = StatusCode,
                    Instance = context.Request.Path,
                    Detail = $"Not found error occured, traceId: {traceId}, message: {e.Message}",
                };

                await context.Response.WriteAsync(e.Message);
            }
            catch (UnauthorizedException e)
            {
                var traceId = Guid.NewGuid();
                var StatusCode = StatusCodes.Status401Unauthorized;

                context.Response.StatusCode = StatusCode;

                var problemDetails = new ProblemDetails
                {
                    Type = "http://api/bus-station/",
                    Title = "Unauthorized Error",
                    Status = StatusCode,
                    Instance = context.Request.Path,
                    Detail = $"Unauthorized error occured, traceId: {traceId}, message: {e.Message}",
                };

                await context.Response.WriteAsync(e.Message);
            }
            catch (BadRequestException e)
            {
                var traceId = Guid.NewGuid();
                var StatusCode = StatusCodes.Status400BadRequest;

                context.Response.StatusCode = StatusCode;

                var problemDetails = new ProblemDetails
                {
                    Type = "http://api/bus-station/",
                    Title = "Bad request Error",
                    Status = StatusCode,
                    Instance = context.Request.Path,
                    Detail = $"Bad request error occured, traceId: {traceId}, message: {e.Message}",
                };

                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                var traceId = Guid.NewGuid();
                var StatusCode = StatusCodes.Status500InternalServerError;

                context.Response.StatusCode = StatusCode;

                var problemDetails = new ProblemDetails
                {
                    Type = "http://api/bus-station/",
                    Title = "Internal Server Error",
                    Status = StatusCode,
                    Instance = context.Request.Path,
                    Detail = $"Internal server error occured, traceId: {traceId}, message: {e.Message}",
                };

                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
