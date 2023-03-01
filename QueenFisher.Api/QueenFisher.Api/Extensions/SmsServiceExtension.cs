using QueenFisher.Core.Utilities;
using Twilio.Http;

namespace QueenFisher.Api.Extensions
{
    public static class SmsServiceExtension
    {
        public static void ConfigureSmsService(this IServiceCollection services, IConfiguration Configuration)
        {
            //EmailService registration
            var smsConfig = Configuration
               .GetSection("SMSConfiguration")
               .Get<SMSConfiguration>();
            services.AddSingleton(smsConfig);

        }

    }
}
