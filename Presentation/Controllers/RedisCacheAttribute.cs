using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ServiciesApstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    internal class RedisCacheAttribute(int durationInSeconds = 120) : ActionFilterAttribute 
    {
        
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IServicesManager>().CacheServices;

            // Next --> Set values --> Go to end point
            string cacheKey = GenerateKey(context.HttpContext.Request);

            // Data already cached [Return response (not enter the end point)]
            var result = await cacheService.GetCacheAsync(cacheKey);
            if (result != null)
            {
                context.Result = new ContentResult     
                {
                    Content = result,
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.OK
                };
                return;
            }

            var resultContext = await next.Invoke();
            if (resultContext.Result is OkObjectResult objectResult)
            {
                await cacheService.SetCacheAsync(
                    cacheKey,
                    objectResult,
                    TimeSpan.FromSeconds(durationInSeconds) 
                );
            }
        }

        private string GenerateKey(HttpRequest request)
        {
            var key = new StringBuilder();
            //Request path api/Prodcut
            //Request query ==> Query string
            //{{baseUrl}}/api/Products?sort=priceAsc&pageSize=5&pageIndex=2
            //{{baseUrl}}/api/Products?pageSize=5&pageIndex=2&sort=priceAsc
            //api/Products?pageSize=5&pageIndex=2&sort=priceAsc

            key.Append(request.Path);
            foreach (var item in request.Query.OrderBy(x => x.Key))
            {
                key.Append($"{item.Key}-{item.Value}");
            }
            return key.ToString();
        }
    }
}
