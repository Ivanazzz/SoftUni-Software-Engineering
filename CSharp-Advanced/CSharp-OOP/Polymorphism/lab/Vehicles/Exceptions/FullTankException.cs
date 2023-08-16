namespace Vehicles.Exceptions
{
    using System;

    public class FullTankException : Exception
    {
        public FullTankException(string message)
            : base(message)
        {

        }
    }
}
