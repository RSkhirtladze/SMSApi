using SMSApi.Domain.Models;

namespace SMSApi.Infrastructure.Providers.Interfaces
{
    public interface ISMSProvider
    {
        Task SendSMSAsync(SMSMessage message);
    }
}
