
using QueenFisher.Core.Utilities;

namespace QueenFisher.Api.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            // Add Service Injections Here
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));


            // Add Repository Injections Here

            // Add Model Services Injection Here

            // Add Fluent Validator Injections Here

        }
    }
}

