
using Domain.Contracts;
using E_CommerceProjectApi.Extentions;
using E_CommerceProjectApi.Factories;
using E_CommerceProjectApi.MiddleWares;
using Microsoft.AspNetCore.Mvc;
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

            #region Services
            builder.Services.AddLogging();
            // Presentation services .      
            builder.Services.AddPresentationServices();

            // Infrastructure services
            builder.Services.AddInfraStructureServices(builder.Configuration);

            // Core Services
            builder.Services.AddCoreServices(builder.Configuration);

            var app = builder.Build();

            #endregion

            #region Pipeline/Middlewares
            app.UseMiddleware();
            await app.UseInitializeSeedDbAsync();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
              app.UseSwaggerMiddleware();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

            #endregion
        }
    }
}
