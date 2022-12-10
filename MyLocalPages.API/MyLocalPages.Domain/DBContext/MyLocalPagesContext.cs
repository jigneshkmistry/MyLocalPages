using Microsoft.EntityFrameworkCore;
using MyLocalPages.Domain;

namespace MyLocalPages.Domain
{
    public class MyLocalPagesContext : DbContext
    {
        public DbSet<BusinessDirectory> BusinessDirectories { get; set; } = null!;
        public DbSet<DirectoryCategory> DirectoryCategories { get; set; } = null!;

        public MyLocalPagesContext(DbContextOptions<MyLocalPagesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guids = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            modelBuilder.Entity<BusinessDirectory>()
                .HasData(
               new BusinessDirectory()
               {
                   Id = guids[0],
                   Name = "Accommodation, Travel & Tours"
               },
               new BusinessDirectory()
               {
                   Id = guids[1],
                   Name = "Animals & Pets"
               },
               new BusinessDirectory()
               {
                   Id = guids[2],
                   Name = "Arts, Crafts & Collectables"                
               });

            modelBuilder.Entity<DirectoryCategory>()
               .HasData(
                    new DirectoryCategory()
                    {
                        BusinessDirectoryId = guids[0],
                        Name = "Accommodation Booking & Inquiry Services"
                    },
                    new DirectoryCategory()
                    {
                        BusinessDirectoryId = guids[0],
                        Name = "Adventure Tours & Holidays Packages"
                    },
                    new DirectoryCategory()
                    {
                        BusinessDirectoryId = guids[1],
                        Name = "Animal Welfare"
                    },
                    new DirectoryCategory()
                    {
                        BusinessDirectoryId = guids[1],
                        Name = "Aquaponics"
                    },
                    new DirectoryCategory()
                    {
                        BusinessDirectoryId = guids[2],
                        Name = "Aboriginal Art & Crafts"
                    },
                    new DirectoryCategory()
                    {
                        BusinessDirectoryId = guids[2],
                        Name = "Antiques Auctions & Dealers"
                    }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
