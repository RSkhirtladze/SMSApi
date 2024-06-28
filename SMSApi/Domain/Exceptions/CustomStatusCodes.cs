namespace SMSApi.Domain.Exceptions
{
    public static class CustomStatusCodes
    {
        public const int INVALID_PHONE_NUMBER = 460;

        public const int MESSAGE_TOO_LONG = 461;

        public const int EMPTY_MESSAGE = 462;

        public const int MESSAGE_CONTAINS_PROHIBITED_WORDS = 463;

        public const int SMS_PROVIDER_EXCPETION = 464;
    }
}
