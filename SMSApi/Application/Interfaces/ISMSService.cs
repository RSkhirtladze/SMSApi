namespace SMSApi.Application.Interfaces
{
    public interface ISMSService
    {
        Task SendSMSAsync(string phoneNumber, string text);
    }
}
