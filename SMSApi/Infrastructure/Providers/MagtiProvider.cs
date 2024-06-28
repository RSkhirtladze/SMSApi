using Serilog;
using SMSApi.Domain.Models;
using SMSApi.Infrastructure.Providers.Interfaces;
using static SMSApi.Domain.Exceptions.Exceptions;

namespace SMSApi.Infrastructure.Providers
{
    public class MagtiProvider : ISMSProvider
    {
        //Could not find anything like Twilio service (tried connecting to MagtiFun, turned out the project itself died)

        private readonly MagtiConfig _config;
        public MagtiProvider(Microsoft.Extensions.Options.IOptions<SMSProviderConfigs> config)
        {
            _config = config.Value.Magti;

        }
        public async Task SendSMSAsync(SMSMessage message)
        {
            try
            {
                ///...
                await Task.Delay(1000);
                ///...
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Magti message send error.");
                throw new SMSProviderException("Magti  SMS sender error");
            }

        }
    }
}
