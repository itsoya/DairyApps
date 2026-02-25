using DairyApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DairyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the DiaryEntry entity
            modelBuilder.Entity<DiaryEntry>().HasData(
            
                new DiaryEntry { Id = 1, Title = "Went Hiking", Content = "Went hiking with Joe", Created = DateTime.Now },
                new DiaryEntry { Id = 2, Title = "Had a great day", Content = "Had a great day with family", Created = DateTime.Now },
                new DiaryEntry { Id = 3, Title = "Learned C#", Content = "Learned about Entity Framework Core", Created = DateTime.Now }

            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings
                    .Ignore(RelationalEventId.PendingModelChangesWarning)); // Suppresses the warning
        }
    }

}
