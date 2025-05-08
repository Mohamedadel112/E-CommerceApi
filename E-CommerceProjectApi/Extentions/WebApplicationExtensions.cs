using Domain.Contracts;
using E_CommerceProjectApi.MiddleWares;

namespace E_CommerceProjectApi.Extentions
{
    public static class WebApplicationExtensions
    {
       public static async Task<WebApplication> UseInitializeSeedDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                await initializer.InitializeAsync();
                await initializer.InitializeIdentityAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error in DB Initialization: " + ex.Message);
                Console.WriteLine(" StackTrace: " + ex.StackTrace);
            }
            return app;
        }

        public static WebApplication UseMiddleware(this WebApplication app)
        {
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return app;
        }

        public static WebApplication UseSwaggerMiddleware(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
