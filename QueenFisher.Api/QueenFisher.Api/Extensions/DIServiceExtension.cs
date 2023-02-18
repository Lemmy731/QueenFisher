
using QueenFisher.Core.Interfaces;
using QueenFisher.Core.Services;
using QueenFisher.Core.Utilities;
using QueenFisher.Data.UnitOfWork;

namespace QueenFisher.Api.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            // Add Service Injections Here
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));


            // Add Repository Injections Here
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Add Model Services Injection Here
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMealService, MealService>();
            // Add Fluent Validator Injections Here


        }
    }
}

