namespace Telephony.Exceptions
{
    using System;

    public class InvalidURLException : Exception
    {
        private const string DefaultExceptionMessage =
            "Invalid URL!";

        public InvalidURLException()
            : base(DefaultExceptionMessage)
        {

        }

        public InvalidURLException(string message)
            : base(message)
        {

        }
    }
}
