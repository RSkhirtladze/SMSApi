using SMSApi.Application.Interfaces;
using SMSApi.Domain.Interfaces;
using SMSApi.Domain.Models;
using Twilio.Types;

namespace SMSApi.Application.Services
{
    public class SMSService : ISMSService
    {
        private readonly IProviderSelector _providerSelector;
        private readonly ISMSDomainService _smsDomainService;

        public SMSService(IProviderSelector providerSelector, ISMSDomainService smsDomainService)
        {
            _providerSelector = providerSelector;
            _smsDomainService = smsDomainService;
        }

        public async Task<bool> SendSMSAsync(string phoneNumber, string text)
        {
            var message = new SMSMessage(new Phone(phoneNumber), text);
            _smsDomainService.ProcessMessage(message);

            var provider = _providerSelector.SelectProvider();
            return await provider.SendSMSAsync(message);
        }
    }
}
