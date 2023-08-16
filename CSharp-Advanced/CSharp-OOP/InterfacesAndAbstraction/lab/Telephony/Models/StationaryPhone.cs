namespace Telephony.Models
{
    using System.Linq;

    using Contracts;
    using Telephony.Exceptions;

    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone()
        {

        }

        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
            => phoneNumber.All(ch => char.IsDigit(ch));
    }
}
