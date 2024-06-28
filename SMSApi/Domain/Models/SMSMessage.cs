using Microsoft.IdentityModel.Tokens;
using Twilio.Types;

namespace SMSApi.Domain.Models
{
    public class SMSMessage
    {
        public Phone Phone { get; private set; }
        public string Text { get; private set; }

        public SMSMessage(Phone phone, string text)
        {
            Phone = phone;
            Text = text;

            Validate(this);
        }

        public static void Validate(SMSMessage smsMessage)
        {
            if (string.IsNullOrEmpty(smsMessage.Text))
            {
                throw new ArgumentException("Text cannot be empty");
            }
            Phone.Validate(smsMessage.Phone);
        }
    }
}
