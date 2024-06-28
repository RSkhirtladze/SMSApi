using Serilog;
using SMSApi.Domain.Models;
using SMSApi.Infrastructure.Providers.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using static SMSApi.Domain.Exceptions.Exceptions;

namespace SMSApi.Infrastructure.Providers
{
    public class TwilioProvider : ISMSProvider
    {
        //Succeeded sending actual SMS text to phone only using twilio provider
        private readonly TwilioConfig _config;
        public TwilioProvider(Microsoft.Extensions.Options.IOptions<SMSProviderConfigs> config)
        {
            _config = config.Value.Twilio;

            TwilioClient.Init(_config.AccountSid, _config.AuthToken);
        }
        public async Task SendSMSAsync(SMSMessage message)
        {
            try
            {
                var result = await MessageResource.CreateAsync(
                    body: message.Text,
                    from: new Twilio.Types.PhoneNumber(_config.PhoneNumber),
                    to: new Twilio.Types.PhoneNumber(message.Phone.Number));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Twilio message send error.");
                throw new SMSProviderException("Twilio  SMS sender error");
            }

        }
    }
}
