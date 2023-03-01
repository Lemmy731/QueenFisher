using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using Twilio.TwiML.Voice;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace QueenFisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ITwilioRestClient _client;

        public SmsController(ITwilioRestClient client)
        {
            const string accountSid = "AC661e3138d385e15dae1f4bbfcd1e642e";
            const string authToken = "59697356e86155c1a764df33487bac6c";


            TwilioClient.Init(accountSid, authToken);
            _client = client;
        }

        [HttpPost("api/send-sms")]

        public IActionResult SendSms()
        {

            var message = MessageResource.Create(
            body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
            from: new Twilio.Types.PhoneNumber("++19148731122"),
            to: new Twilio.Types.PhoneNumber("+2348157575498"));

            return Ok("Success" + message.Sid);
           

        }
    }
}
