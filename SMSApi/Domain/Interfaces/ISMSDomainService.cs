using SMSApi.Domain.Models;

namespace SMSApi.Domain.Interfaces
{
    public interface ISMSDomainService
    {
        void ProcessMessage(SMSMessage message);
    }
}
