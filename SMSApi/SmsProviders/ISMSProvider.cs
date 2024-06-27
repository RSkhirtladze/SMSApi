namespace SMSApi.SmsProviders
{
    public interface ISMSProvider
    {
        Task SendSMSAsync(string toPhoneNumber, string text);
    }
}
