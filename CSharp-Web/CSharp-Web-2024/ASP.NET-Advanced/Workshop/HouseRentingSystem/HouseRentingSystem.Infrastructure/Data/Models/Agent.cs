using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Comment("House Agent")]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Agent
    {
        [Key]
        [Comment("Agent identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AgentPhoneNumberMaxLength)]
        [Comment("Agent's phone number")]
        public required string PhoneNumber { get; set; }

        [Required]
        [Comment("User identifier")]
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<House> Houses { get; set; } = new List<House>();
    }
}
