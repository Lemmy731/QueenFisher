using Twilio.Clients;
using Twilio.Http;

namespace QueenFisher.Api
{
    public class TwilioRest : ITwilioRestClient
    {

        private readonly ITwilioRestClient _innerClient;

        private readonly System.Net.Http.HttpClient _httpclient;


        //use mail service extention
        public TwilioRest(IConfiguration config, System.Net.Http.HttpClient httpClient)
        {

            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "CustomTwilioRestClient-Demo");
            _innerClient = new TwilioRestClient(
                config["Twilio: Account SID"],
                config["Twilio: Auth Token"],
                httpClient: new SystemNetHttpClient()
               ) ;
        }
        public Response Request(Request request) => _innerClient.Request(request);

        public Task<Response> RequestAsync(Request request) => _innerClient.RequestAsync(request);
        public string AccountSid => _innerClient.AccountSid;

        public string Region => _innerClient.Region;
        public Twilio.Http.HttpClient HttpClient => _innerClient.HttpClient;
    }
}
