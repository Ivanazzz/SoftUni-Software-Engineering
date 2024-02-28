using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Comment("House to rent")]
    public class House
    {
        [Key]
        [Comment("House identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(HouseTitleMaxLength)]
        [Comment("House title")]
        public required string Title { get; set; }

        [Required]
        [MaxLength(HouseAddressMaxLength)]
        [Comment("House address")]
        public required string Address { get; set; }

        [Required]
        [MaxLength(HouseDescriptionMaxLength)]
        [Comment("House description")]
        public required string Description { get; set; }

        [Required]
        [Comment("House image url")]
        public required string ImageUrl { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("House monthly price")]
        public required decimal PricePerMonth { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;

        [Comment("User id of the renterer")]
        public string? RenterId { get; set; }
    }
}
