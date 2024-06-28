using SMSApi.Application.Interfaces;
using SMSApi.Infrastructure.Providers.Interfaces;

namespace SMSApi.App.SmsProviders
{
    public class RandomProviderSelector : IProviderSelector
    {
        private readonly List<ISMSProvider> _providers;
        private readonly Random _random;

        public RandomProviderSelector(IEnumerable<ISMSProvider> providers)
        {
            _providers = new List<ISMSProvider>(providers);
            _random = Random.Shared;
        }

        public ISMSProvider SelectProvider()
        {
            int randomIndex = _random.Next(_providers.Count);
            return _providers[randomIndex];
        }
    }
}
