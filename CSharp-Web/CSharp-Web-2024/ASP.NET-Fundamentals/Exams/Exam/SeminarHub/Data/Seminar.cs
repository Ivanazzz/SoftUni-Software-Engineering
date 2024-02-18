using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data
{
    [Comment("Seminars of the SeminarHub")]
    public class Seminar
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Topic of the seminar")]
        [Required]
        [MaxLength(SeminarTopicMaximumLength)]
        public string Topic { get; set; } = string.Empty;

        [Comment("Lecturer of the seminar")]
        [Required]
        [MaxLength(SeminarLecturerMaximumLength)]
        public string Lecturer { get; set; } = string.Empty;

        [Comment("Details of the seminar")]
        [Required]
        [MaxLength(SeminarDetailsMaximumLength)]
        public string Details { get; set; } = string.Empty;

        [Comment("Organizer ID of the seminar")]
        [Required]
        public string OrganizerId { get; set; } = string.Empty;

        [Comment("Organizer of the seminar")]
        [Required]
        [ForeignKey(nameof(OrganizerId))]
        public IdentityUser Organizer { get; set; } = null!;

        [Comment("Date and time of the seminar")]
        [Required]
        public DateTime DateAndTime { get; set; }

        [Comment("Duration of the seminar")]
        [Required]
        [Range(SeminarDurationMinimumValue, SeminarDurationMaximumValue)]
        public int Duration { get; set; }

        [Comment("Category ID of the seminar")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Category of the seminar")]
        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public IList<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }
}