namespace Raiding.Exceptions
{
    using System;

    public class InvalidHeroTypeException : Exception
    {
        private const string DefaultMessage = "Invalid hero!";

        public InvalidHeroTypeException()
            : base(DefaultMessage)
        {

        }

        public InvalidHeroTypeException(string message)
            : base(message) 
        {

        }
    }
}
