using Microsoft.Extensions.Options;
using SMSApi.Application.Interfaces;
using SMSApi.Infrastructure.Providers.Interfaces;
using SMSApi.Infrastructure.Providers;
using Twilio.TwiML.Voice;

namespace SMSApi.Application.ProviderSelectors
{
    public class ProviderSelectorByPercentage : IProviderSelector
    {
        private readonly List<(ISMSProvider Provider, int Weight)> _providersWithWeights;
        private readonly Random _random;

        public ProviderSelectorByPercentage(IEnumerable<ISMSProvider> providers, IOptions<SMSProviderConfigs> smsProvidersConfigs)
        {
            var providerWeights = new Dictionary<Type, int>
            {
                { typeof(TwilioProvider), smsProvidersConfigs.Value.ProviderWeights.TwilioWeight },
                { typeof(MagtiProvider), smsProvidersConfigs.Value.ProviderWeights.MagtiWeight },
                { typeof(GeocellProvider), smsProvidersConfigs.Value.ProviderWeights.GeocellWeight }
            };

            _providersWithWeights = providers
                .Select(provider => (provider, providerWeights[provider.GetType()]))
                .ToList();

            _random = Random.Shared;
        }

        public ISMSProvider SelectProvider()
        {
            int totalWeight = _providersWithWeights.Sum(provider => provider.Weight);

            int randomValue = _random.Next(0, totalWeight);

            int cumulativeWeight = 0;

            foreach (var providerWithWeight in _providersWithWeights)
            {
                cumulativeWeight += providerWithWeight.Weight;
                if (randomValue < cumulativeWeight)
                {
                    return providerWithWeight.Provider;
                }
            }

            // Code should never reach here
            throw new InvalidOperationException("ProviderSelectorByPercentage is broken! Something went wrong");
        }
    }
}
