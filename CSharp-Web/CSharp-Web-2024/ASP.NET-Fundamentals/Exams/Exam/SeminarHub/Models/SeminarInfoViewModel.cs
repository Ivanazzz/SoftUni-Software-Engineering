using SeminarHub.Data;
using System.Globalization;

namespace SeminarHub.Models
{
    public class SeminarInfoViewModel
    {
        public SeminarInfoViewModel(
            int id,
            string topic,
            string lecturer,
            string details,
            string organizer,
            DateTime dateAndTime,
            int duration,
            string category)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Details = details;
            Organizer = organizer;
            DateAndTime = dateAndTime.ToString(DataConstants.DateFormat, CultureInfo.InvariantCulture);
            Duration = duration;
            Category = category;
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string Details { get; set; }

        public string Organizer { get; set; }

        public string DateAndTime { get; set; }

        public int Duration { get; set; }

        public string Category { get; set; }
    }
}
