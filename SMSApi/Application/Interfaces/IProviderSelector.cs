using SMSApi.Infrastructure.Providers.Interfaces;

namespace SMSApi.Application.Interfaces
{
    public interface IProviderSelector
    {
        ISMSProvider SelectProvider();
    }
}
