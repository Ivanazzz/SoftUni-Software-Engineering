namespace Telephony.Models.Contracts
{
    public interface ISmartphone : IStationaryPhone
    {
        public string BrowseURL(string url);
    }
}
