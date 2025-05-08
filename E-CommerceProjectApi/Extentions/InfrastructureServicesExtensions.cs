using Domain.Contracts;
using Presistance.Data.DataSeed;
using Presistance.Data.Repositories;
using Presistance.Data;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Presistance.Data.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

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

            services.AddDbContext<IdentityAppDbcontext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityDefaultConnection"));
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {

                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<IdentityAppDbcontext>();

            services.AddScoped<ICacheReepo, CacheRepo>();
            services.AddScoped<IDbInitializer, DbInitialize>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IConnectionMultiplexer>(option => 
            
               ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!)
            );
            services.ConfigureJwt(configuration);
            services.AddScoped<IBasketRepo, BasketRepo>();
            return services;
        }
    }
}
