using Domain.Contracts;
using Presistance.Data.DataSeed;
using Presistance.Data.Repositories;
using Presistance.Data;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace E_CommerceProjectApi.Extentions
{
    public static class InfrastructureServicesExtensions
    {

        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDbInitializer, DbInitialize>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IConnectionMultiplexer>(option => 
            
               ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!)
            );
            services.AddScoped<IBasketRepo, BasketRepo>();
            return services;
        }
    }
}
