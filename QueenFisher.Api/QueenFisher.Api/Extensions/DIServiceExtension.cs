
using QueenFisher.Core.Services;
using QueenFisher.Core.Interfaces;
using QueenFisher.Core.Interfaces.IServices;
using QueenFisher.Core.Utilities;
using QueenFisher.Data;
using QueenFisher.Data.UnitOfWork;
using IUnitOfWork = QueenFisher.Data.IUnitOfWork;
using QueenFisher.Data.Repositories;
using QueenFisher.Data.IRepositories;

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
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
          
            // Add Model Services Injection Here
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITokenDetails, TokenDetails>();

            services.AddScoped<IUserService, UserService>();
          
            // Add Fluent Validator Injections Here

        }
    }
}

