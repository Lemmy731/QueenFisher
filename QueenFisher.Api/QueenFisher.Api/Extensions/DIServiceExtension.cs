
using QueenFisher.Core.Interfaces;
using QueenFisher.Core.Services;
using QueenFisher.Core.Utilities;
using QueenFisher.Data;
using QueenFisher.Data.UnitOfWork;
using IUnitOfWork = QueenFisher.Data.IUnitOfWork;

namespace QueenFisher.Api.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            // Add Service Injections Here
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));


            // Add Repository Injections Here
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            // Add Model Services Injection Here
            services.AddScoped<IUserService, UserService>();
            // Add Fluent Validator Injections Here

        }
    }
}

