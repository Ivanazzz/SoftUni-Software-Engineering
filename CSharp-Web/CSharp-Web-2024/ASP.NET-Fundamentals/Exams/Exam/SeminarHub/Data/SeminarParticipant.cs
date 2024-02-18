using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data
{
    [Comment("Participants of the seminar")]
    public class SeminarParticipant
    {
        [Comment("ID of the seminar")]
        [Required]
        public int SeminarId { get; set; }

        [Comment("Seminar")]
        [ForeignKey(nameof(SeminarId))]
        public Seminar Seminar { get; set; } = null!;

        [Comment("ID of the participant")]
        [Required]
        public string ParticipantId { get; set; } = string.Empty;

        [Comment("Participant")]
        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; } = null!;
    }
}