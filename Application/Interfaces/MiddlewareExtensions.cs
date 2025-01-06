using Microsoft.AspNetCore.Builder;

namespace API.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app, IRequestMiddleware middleware)
        {
            return app.Use(async (context, next) =>
            {
                await middleware.InvokeAsync(context, next);
            });
        }
    }
}