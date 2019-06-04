using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TimeFlyApi.Data;

namespace TimeFlyApi.Helpers
{
    public static class CustomException
    {

    }

    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerRepository _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerRepository logger)
        {
            _logger = logger;
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
                StringBuilder logText = new StringBuilder();
                var controller = httpContext.GetRouteValue("controller");
                var action = httpContext.GetRouteValue("action");
                logText.Append("Message: " + ex.Message + "\n");
                logText.Append("Controller: " + controller + "\n");
                logText.Append("Action: " + action + "\n");
                logText.Append("Source: " + ex.Source + "\n");
                logText.Append("TargetSite: " + ex.TargetSite + "\n");
                logText.Append("StackTrace: " + ex.StackTrace);
                await _logger.LogError(logText.ToString());
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(exception.Message);
        }
    }
}
