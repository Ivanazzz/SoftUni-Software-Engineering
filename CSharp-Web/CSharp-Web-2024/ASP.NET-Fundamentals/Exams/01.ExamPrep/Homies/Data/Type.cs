using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;

namespace Homies.Data
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaximumLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
