
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistance.Data;
using Presistance.Data.DataSeed;
using Presistance.Data.Repositories;
using Servicies;
using Servicies.Mapping_Profile;
using ServiciesApstraction;

namespace E_CommerceprojectApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDbInitializer, DbInitialize>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServicesManager, ServicesManager>();    
            builder.Services.AddAutoMapper(typeof(Servicies.AssemplyReference).Assembly);
            var app = builder.Build();
            await InitializeDbAsync(app);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            async Task InitializeDbAsync(WebApplication web)
            {
                using var scope = web.Services.CreateScope();
                try
                {
                    var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                    await initializer.InitializeAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("🔥 Error in DB Initialization: " + ex.Message);
                    Console.WriteLine("🧠 StackTrace: " + ex.StackTrace);
                    // يمكنك أيضًا عمل Log هنا أو إعادة رمي الاستثناء
                }
            }
        }
    }
}
