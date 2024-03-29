using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication16.Models;

namespace WebApplication16.Filters
{
    public class FileLoggerFilter : Attribute, IAsyncActionFilter
    {
        private readonly FileLogger logger;

        public FileLoggerFilter()
        {
            this.logger = new FileLogger(@"log.txt");
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            logger.LogInformation($"{context.RouteData.Values["action"] as string} method " +
                $"executing at {DateTime.Now.ToLongTimeString()}");
            await next();
        }
    }
}

