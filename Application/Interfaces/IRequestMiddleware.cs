using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public interface IRequestMiddleware
    {
        Task InvokeAsync(HttpContext context, RequestDelegate next);
    }
}