using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data
{
    [Comment("Category of the seminar")]
    public class Category
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the category")]
        [Required]
        [MaxLength(CategoryNameMaximumLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}