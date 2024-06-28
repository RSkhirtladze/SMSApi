using SMSApi.Application.Interfaces;
using SMSApi.Infrastructure.Providers.Interfaces;

namespace SMSApi.Application.ProviderSelectors
{
    public class ProviderSelectorByPercentage : IProviderSelector
    {
        public ISMSProvider SelectProvider()
        {
            throw new NotImplementedException();
        }
    }
}
