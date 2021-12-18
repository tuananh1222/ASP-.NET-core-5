using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WebApi
{
    public class MyCostomMidelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware Incoming Request \n");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware Outgoing Response \n");
        }
    }
}
