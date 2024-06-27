
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SMSApi.SmsProviders
{
    public class TwilioSMSProvider : ISMSProvider
    {
        public async Task SendSMSAsync(string toPhoneNumber, string text)
        {
            TwilioClient.Init("", "");
            
            var message = await MessageResource.CreateAsync(, );
        }
    }
}
