using SMSApi.Application.Interfaces;
using SMSApi.Domain.Models;
using SMSApi.Infrastructure.Providers.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SMSApi.App.SmsProviders
{
    public class RandomProviderSelector : IProviderSelector
    {
        public ISMSProvider SelectProvider()
        {
            throw new NotImplementedException();
        }
    }
}
