using Domain.Exceptions;
using Shared.ErrorsModel;
using System.Net;
using System.Threading.Tasks;

namespace E_CommerceProjectApi.MiddleWares
{
    public class GlobalErrorHandlingMiddleware
    {

        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;
        private readonly RequestDelegate? _next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next,ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            this._next = next;  
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if (httpContext.Response.StatusCode ==(int) HttpStatusCode.NotFound)
                {
                    await HandleNotFoundApiAsync(httpContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went Wrong: {ex}");

                await HandleException(httpContext, ex);
            }
        }

        private async Task HandleNotFoundApiAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";

            var response = new ErrorsDetails()
            {
                StatusCode =  (int)HttpStatusCode.NotFound,
                MsgError = $"The End Point {httpContext.Request.Path} Not Found",

            }.ToString();

            await httpContext.Response.WriteAsync(response);

        }



        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var response = new ErrorsDetails() 
            { 
                StatusCode  =httpContext.Response.StatusCode,   
                MsgError = ex.Message,
            
            }.ToString();
            
            await httpContext.Response.WriteAsync(response);

        }
    }
}
