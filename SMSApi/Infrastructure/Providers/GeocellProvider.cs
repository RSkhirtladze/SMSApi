using SMSApi.Domain.Models;
using SMSApi.Infrastructure.Providers.Interfaces;

namespace SMSApi.Infrastructure.Providers
{
    public class GeocellProvider : ISMSProvider
    {
        public async Task<bool> SendSMSAsync(SMSMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
