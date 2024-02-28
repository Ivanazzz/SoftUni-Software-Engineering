using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HouseRentingSystem.Infrastructure.Data.Models;

namespace HouseRentingSystem.Infrastructure.Data.SeedDb
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[] { data.CottageCategory, data.SingleCategory, data.DuplexCategory });
        }
    }
}
