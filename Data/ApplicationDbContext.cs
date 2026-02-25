using DairyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyApp.Data
{
    public class ApplicationDbContext : DbContext
        {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 

        }
       public DbSet<DiaryEntry> DiaryEntries { get; set; } 
    }

    }
