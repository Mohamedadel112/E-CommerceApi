using Servicies;
using ServiciesApstraction;

namespace E_CommerceProjectApi.Extentions
{
    public static class CoreServicesExtensions
    {

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IServicesManager, ServicesManager>();
            services.AddAutoMapper(typeof(Servicies.AssemplyReference).Assembly);
            return services;
        }
    }
}
