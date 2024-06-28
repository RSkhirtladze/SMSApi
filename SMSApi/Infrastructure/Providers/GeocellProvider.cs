using Serilog;
using SMSApi.Domain.Models;
using SMSApi.Infrastructure.Providers.Interfaces;
using static SMSApi.Domain.Exceptions.Exceptions;

namespace SMSApi.Infrastructure.Providers
{
    public class GeocellProvider : ISMSProvider
    {
        //Same as magti
        private readonly GeocellConfig _config;
        public GeocellProvider(Microsoft.Extensions.Options.IOptions<SMSProviderConfigs> config)
        {
            _config = config.Value.Geocell;

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
                Log.Fatal(ex, "Geocell message send error.");
                throw new SMSProviderException("Geocell  SMS sender error");
            }

        }
    }
}
