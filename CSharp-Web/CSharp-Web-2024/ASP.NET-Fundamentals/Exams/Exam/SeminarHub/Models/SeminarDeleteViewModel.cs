using SeminarHub.Data;
using System.Globalization;

namespace SeminarHub.Models
{
    public class SeminarDeleteViewModel
    {
        public SeminarDeleteViewModel(
            int id,
            string topic,
            DateTime dateAndTime)
        {
            Id = id;
            Topic = topic;
            DateAndTime = dateAndTime.ToString(DataConstants.DateFormat, CultureInfo.InvariantCulture);
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string DateAndTime { get; set; }
    }
}
