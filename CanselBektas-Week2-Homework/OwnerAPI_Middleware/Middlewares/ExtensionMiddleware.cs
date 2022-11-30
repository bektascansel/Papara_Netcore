using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System;
using System.Threading.Tasks;

namespace OwnerAPI_Middleware.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExtensionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExtensionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(new { error = ex.Message }));

        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExtensionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExtensionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExtensionMiddleware>();
        }
    }
}
