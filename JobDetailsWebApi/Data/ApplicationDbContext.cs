using JobDetailsWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace JobDetailsWebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<JobDetails>JobDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure precision and scale for decimal properties
            modelBuilder.Entity<JobDetails>(entity =>
            {
                entity.Property(e => e.CurrentCtc).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ExpectedCtc).HasColumnType("decimal(18,2)");
            });
        }

    }
}
