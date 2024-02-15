using Homies.Data;

namespace Homies.Models
{
    public class EventInfoViewModel
    {
        public EventInfoViewModel(
            int id,
            string name,
            DateTime startingTime,
            string type,
            string organizer)
        {
            Id = id;
            Name = name; 
            Type = type;
            Organiser = organizer;
            Start = startingTime.ToString(DataConstants.DateFormat);            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Start { get; set; }

        public string Type { get; set; }

        public string Organiser { get; set; }
    }
}
