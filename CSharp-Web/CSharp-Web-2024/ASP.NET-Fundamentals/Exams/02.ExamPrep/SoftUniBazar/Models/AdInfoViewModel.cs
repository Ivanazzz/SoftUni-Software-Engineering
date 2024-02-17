using static SoftUniBazar.Data.DataConstants;

namespace SoftUniBazar.Models
{
    public class AdInfoViewModel
    {
        public AdInfoViewModel(
            int id, 
            string name, 
            string description, 
            decimal price, 
            string owner, 
            string imageUrl, 
            DateTime createdOn, 
            string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Owner = owner;
            ImageUrl = imageUrl;
            CreatedOn = createdOn.ToString(DateFormat);
            Category = category;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Owner { get; set; }

        public string ImageUrl { get; set; }

        public string CreatedOn { get; set; }

        public string Category { get; set; }
    }
}
