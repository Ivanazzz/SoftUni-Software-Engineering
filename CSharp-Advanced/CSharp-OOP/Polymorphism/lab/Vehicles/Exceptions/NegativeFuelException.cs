namespace Vehicles.Exceptions
{
    using System;

    public class NegativeFuelException : Exception
    {
        private const string DefaultMessage = "Fuel must be a positive number";

        public NegativeFuelException()
            : base(DefaultMessage)
        {

        }

        public NegativeFuelException(string message)
            : base(message)
        {

        }
    }
}
