namespace SMSApi.Application.Interfaces
{
    public interface ISMSService
    {
        Task<Boolean> SendSMSAsync(string phoneNumber, string text);
    }
}
