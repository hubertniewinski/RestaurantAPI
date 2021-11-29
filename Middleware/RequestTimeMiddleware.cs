using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RestaurantAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;

        private Stopwatch _stopWatch;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopWatch = new();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            var elapsedMililiseconds = _stopWatch.ElapsedMilliseconds;

            if(elapsedMililiseconds / 1000 > 4)
            {
                var message = $"Request [{ context.Request.Method}] at {context.Request.Path} took {elapsedMililiseconds}";

                _logger.LogInformation(message);
            }
        }
    }
}
