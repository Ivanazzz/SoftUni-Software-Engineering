using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using HouseRentingSystem.Infrastructure.Data.Models;

namespace HouseRentingSystem.Infrastructure.Data.SeedDb
{
    internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            var data = new SeedData();

            builder.HasData(new Agent[] { data.Agent });
        }
    }
}
