using Microsoft.IdentityModel.Tokens;
using Twilio.Types;
using static SMSApi.Domain.Exceptions.Exceptions;

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
                throw new EmptyMessageException("Text cannot be empty");
            }
            Phone.Validate(smsMessage.Phone);
        }
    }
}
