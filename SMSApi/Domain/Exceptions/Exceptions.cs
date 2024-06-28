namespace SMSApi.Domain.Exceptions
{
    public class Exceptions
    {
        public class InvalidPhoneNumberException : Exception
        {
            public InvalidPhoneNumberException(string message) : base(message) { }
        }

        public class MessageTooLongException : Exception
        {
            public MessageTooLongException(string message) : base(message) { }
        }

        public class EmptyMessageException : Exception
        {
            public EmptyMessageException(string message) : base(message) { }
        }

        public class MessageContainsProhibitedWordsException : Exception
        {
            public MessageContainsProhibitedWordsException(string message) : base(message) { }
        }
    }
}
