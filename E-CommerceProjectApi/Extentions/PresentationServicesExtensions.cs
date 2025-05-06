using E_CommerceProjectApi.Factories;
using Microsoft.AspNetCore.Mvc;
using Servicies;
using ServiciesApstraction;

namespace E_CommerceProjectApi.Extentions
{
    public static class PresentationServicesExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolisy", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.GetValidateErrors;
            });
            return services;
        }

    }
}
