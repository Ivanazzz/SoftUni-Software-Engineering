using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AdBuyer> AdBuyers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdBuyer>()
                .HasKey(ad => new { ad.AdId, ad.BuyerId });

            modelBuilder.Entity<AdBuyer>()
                .HasOne(ad => ad.Ad)
                .WithMany(ad => ad.AdBuyers)
                .HasForeignKey(ad => ad.AdId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdBuyer>()
                .HasOne(ad => ad.Buyer)
                .WithMany()
                .HasForeignKey(ad => ad.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });
            
             base.OnModelCreating(modelBuilder);
        }
    }
}