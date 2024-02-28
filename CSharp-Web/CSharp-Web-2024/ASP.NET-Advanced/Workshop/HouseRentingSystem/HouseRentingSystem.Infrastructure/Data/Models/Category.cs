using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Comment("House category")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public required string Name { get; set; }

        public List<House> Houses { get; set; } = new List<House>();
    }
}
