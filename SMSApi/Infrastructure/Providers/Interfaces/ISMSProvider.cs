using SMSApi.Domain.Models;

namespace SMSApi.Infrastructure.Providers.Interfaces
{
    public interface ISMSProvider
    {
        Task<Boolean> SendSMSAsync(SMSMessage message);
    }
}
